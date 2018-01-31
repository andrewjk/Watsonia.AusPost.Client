using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

// Adapted from http://pablissimo.com/572/getting-newtonsoft-json-net-to-respect-the-datamember-name-property

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// A JsonConverter that respects the Name property of DataMember attributes
	/// applied to enumeration members, falling back to the enumeration member
	/// name where no DataMember attribute exists (or where a name has not
	/// been supplied). Entirely experimental, use at your own risk.
	/// 
	/// Paul O'Neill, paul@pablissimo.com, 31/07/13
	/// </summary>
	internal class ApiEnumNameConverter : JsonConverter
	{
		private static Dictionary<Type, IEnumerable<Tuple<object, string>>> _typeNameCache =
			new Dictionary<Type, IEnumerable<Tuple<object, string>>>();

		public override bool CanConvert(Type objectType)
		{
			return objectType.IsEnum;
		}

		public override object ReadJson(JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
		{
			return GetOutputValue(reader.Value.ToString(), type);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize(writer, GetOutputName(value));
		}

		private static string GetOutputName(object value)
		{
			Type type = value.GetType();
			if (!type.IsEnum)
			{
				throw new InvalidOperationException("Type is not an enumeration");
			}

			var map = GetOutputMap(type);
			var match = map.FirstOrDefault(x => x.Item1.Equals(value));
			if (match != null)
			{
				return match.Item2;
			}
			else
			{
				// We're buggered if this is a flags enum so just return the string representation
				return value.ToString();
			}
		}

		private static object GetOutputValue(string serialised, Type type)
		{
			if (!type.IsEnum)
			{
				throw new InvalidOperationException("Type is not an enumeration");
			}

			var map = GetOutputMap(type);
			var match = map.FirstOrDefault(x => x.Item2.Equals(serialised));
			if (match != null)
			{
				// Immediate hit, just use it
				return match.Item1;
			}
			else
			{
				// No hit, which suggests a straight Enum.Parse should work 
				// (or fail because we've been supplied nonsense)
				return Enum.Parse(type, serialised);
			}
		}

		private static IEnumerable<Tuple<object, string>> GetOutputMap(Type type)
		{
			IEnumerable<Tuple<object, string>> enumOutputLookup = null;
			if (!_typeNameCache.TryGetValue(type, out enumOutputLookup))
			{
				// Index the type naively - it's unlikely we'll have more than a handful of
				// enum values per type
				List<Tuple<object, string>> outputNames = new List<Tuple<object, string>>();
				foreach (var field in type.GetFields(BindingFlags.Static | BindingFlags.Public))
				{
					var dataMemberAttribute = Attribute.GetCustomAttribute(field, typeof(DataMemberAttribute)) as DataMemberAttribute;
					if (dataMemberAttribute != null && !string.IsNullOrWhiteSpace(dataMemberAttribute.Name))
					{
						outputNames.Add(new Tuple<object, string>(field.GetValue(null), dataMemberAttribute.Name));
					}
					else
					{
						// No attribute, so go with the string representation of the field
						outputNames.Add(new Tuple<object, string>(field.GetValue(null), field.Name));
					}
				}

				enumOutputLookup = outputNames;
				_typeNameCache[type] = outputNames;
			}

			return enumOutputLookup;
		}
	}
}
