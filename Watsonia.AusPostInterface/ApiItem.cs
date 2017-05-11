using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	public class ApiItem
	{
		/// <summary>
		/// Returns a JSON string that represents this instance.
		/// </summary>
		/// <returns>
		/// A JSON string that represents this instance.
		/// </returns>
		public string ToJson()
		{
			var settings = new JsonSerializerSettings();
			//settings.DateFormatString = "YYYY-MM-DD";
			settings.ContractResolver = new JsonPropertyContractResolver();
			settings.Converters.Add(new JsonEnumNameConverter());
			settings.Formatting = Formatting.Indented;
			settings.NullValueHandling = NullValueHandling.Ignore;
			return JsonConvert.SerializeObject(this, settings);
		}

		/// <summary>
		/// Loads this instance's values from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public void FromJson(string json)
		{
			var settings = new JsonSerializerSettings();
			//settings.DateFormatString = "YYYY-MM-DD";
			settings.ContractResolver = new JsonPropertyContractResolver();
			settings.Converters.Add(new JsonEnumNameConverter());
			settings.Formatting = Formatting.Indented;
			settings.NullValueHandling = NullValueHandling.Ignore;
			var item = JsonConvert.DeserializeObject(json, this.GetType(), settings);

			foreach (var prop in item.GetType().GetProperties())
			{
				if (prop.SetMethod != null)
				{
					prop.SetValue(this, prop.GetValue(item));
				}
			}
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return ToJson();
		}
	}
}
