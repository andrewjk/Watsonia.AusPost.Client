using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	internal sealed class ApiSerializer
	{
		/// <summary>
		/// Returns a JSON string that represents the supplied item.
		/// </summary>
		/// <returns>
		/// A JSON string that represents the supplied item.
		/// </returns>
		public string ToJson(object item)
		{
			var settings = new JsonSerializerSettings();
			//settings.DateFormatString = "YYYY-MM-DD";
			settings.ContractResolver = new ApiPropertyContractResolver();
			settings.Converters.Add(new ApiEnumNameConverter());
			settings.Formatting = Formatting.Indented;
			settings.NullValueHandling = NullValueHandling.Ignore;
			return JsonConvert.SerializeObject(item, settings);
		}

		/// <summary>
		/// Loads this instance's values from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public T FromJson<T>(string json)
		{
			var settings = new JsonSerializerSettings();
			//settings.DateFormatString = "YYYY-MM-DD";
			settings.ContractResolver = new ApiPropertyContractResolver();
			settings.Converters.Add(new ApiEnumNameConverter());
			settings.Formatting = Formatting.Indented;
			settings.NullValueHandling = NullValueHandling.Ignore;
			return (T)JsonConvert.DeserializeObject(json, typeof(T), settings);
		}
	}
}
