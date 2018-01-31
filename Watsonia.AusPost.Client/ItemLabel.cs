using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public sealed class ItemLabel : ApiItem
	{
		public string LabelUrl { get; set; }

		public LabelStatus Status { get; set; }

		public string[] Errors { get; set; }

		public string LabelCreationDate { get; set; }

		/// <summary>
		/// Loads a ItemLabel from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static ItemLabel FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<ItemLabel>(json);
		}
	}
}
