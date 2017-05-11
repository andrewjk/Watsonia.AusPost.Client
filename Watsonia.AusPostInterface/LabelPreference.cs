using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// The required preferences to be applied.
	/// </summary>
	/// <seealso cref="Watsonia.AusPostInterface.ApiItem" />
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
	}
}
