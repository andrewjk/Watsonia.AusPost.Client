using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	/// <summary>
	/// The required preferences to be applied.
	/// </summary>
	/// <seealso cref="Watsonia.AusPost.Client.ApiItem" />
	public sealed class LabelPreference : ApiItem
	{
		/// <summary>
		/// For printing preferences the type is "PRINT".
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		[Required]
		public string Type { get; set; } = "PRINT";

		/// <summary>
		/// The required page format for the labels.
		/// </summary>
		/// <value>
		/// The attributes.
		/// </value>
		public List<LabelAttributes> Groups { get; set; } = new List<LabelAttributes>();

		/// <summary>
		/// Loads a LabelPreference from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static LabelPreference FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<LabelPreference>(json);
		}
	}
}
