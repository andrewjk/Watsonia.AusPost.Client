using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public class ApiItem
	{
		/// <summary>
		/// Returns a JSON string that represents the supplied item.
		/// </summary>
		/// <returns>
		/// A JSON string that represents the supplied item.
		/// </returns>
		public string ToJson()
		{
			var serializer = new ApiSerializer();
			return serializer.ToJson(this);
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return this.ToJson();
		}
	}
}
