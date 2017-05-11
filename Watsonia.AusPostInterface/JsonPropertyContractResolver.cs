using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// Resolves property names to the underscored version expected by the Australia Post API.
	/// </summary>
	/// <seealso cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
	public sealed class JsonPropertyContractResolver : DefaultContractResolver
	{
		/// <summary>
		/// Resolves the name of the property.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>
		/// Resolved name of the property.
		/// </returns>
		protected override string ResolvePropertyName(string propertyName)
		{
			// This should catch most things, others can be specified explicitly with JsonProperty
			return Regex.Replace(propertyName, @"(\p{Ll})([\p{Lu},\d])", "$1_$2").ToLowerInvariant();
		}

		/// <summary>
		/// Resolves the key of the dictionary. By default <see cref="M:Newtonsoft.Json.Serialization.DefaultContractResolver.ResolvePropertyName(System.String)" /> is used to resolve dictionary keys.
		/// </summary>
		/// <param name="dictionaryKey">Key of the dictionary.</param>
		/// <returns>
		/// Resolved key of the dictionary.
		/// </returns>
		protected override string ResolveDictionaryKey(string dictionaryKey)
		{
			// Pass it through as-is
			return dictionaryKey;
		}

		/// <summary>
		/// Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.MemberInfo" />.
		/// </summary>
		/// <param name="member">The member to create a <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for.</param>
		/// <param name="memberSerialization">The member's parent <see cref="T:Newtonsoft.Json.MemberSerialization" />.</param>
		/// <returns>
		/// A created <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given <see cref="T:System.Reflection.MemberInfo" />.
		/// </returns>
		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			JsonProperty property = base.CreateProperty(member, memberSerialization);

			// Don't serialize default enum values
			if (property.PropertyType.IsEnum)
			{
				property.ShouldSerialize =
					instance =>
					{
						// HACK: I must be missing an easier way here...
						var prop = instance.GetType().GetProperty(property.UnderlyingName);
						int e = (int)prop.GetValue(instance);
						return e != 0;
					};
			}

			// Don't serialize empty collections
			if (typeof(ICollection).IsAssignableFrom(property.PropertyType))
			{
				property.ShouldSerialize =
					instance =>
					{
						// HACK: I must be missing an easier way here...
						var prop = instance.GetType().GetProperty(property.UnderlyingName);
						ICollection e = (ICollection)prop.GetValue(instance);
						return e.Count > 0;
					};
			}

			return property;
		}
	}
}
