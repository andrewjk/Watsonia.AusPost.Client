using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	/// <summary>
	/// The required page format for the labels.
	/// </summary>
	/// <seealso cref="Watsonia.AusPost.Client.ApiItem" />
	public sealed class LabelAttributes : ApiItem
	{
		/// <summary>
		/// The label group to apply the print preference. 
		/// </summary>
		/// <value>
		/// The group.
		/// </value>
		public LabelGroup Group { get; set; }

		/// <summary>
		/// The layout specifies the number of labels per page and the size of the page. The layout must be valid for the product types of the items in the shipment.
		/// </summary>
		/// <value>
		/// The layout.
		/// </value>
		public LabelLayout Layout { get; set; }

		/// <summary>
		/// Whether the Australia Post branding should be included on the labels. If you are using purchased stationary from Australia Post, then the generated labels should not include the branding. 
		/// </summary>
		/// <value>
		///   <c>true</c> if branded; otherwise, <c>false</c>.
		/// </value>
		public bool Branded { get; set; }

		/// <summary>
		/// Use this field to adjust the left margin of the page.
		/// </summary>
		/// <value>
		/// The left offset.
		/// </value>
		public int LeftOffset { get; set; }

		/// <summary>
		/// Use this field to adjust the top margin of the page.
		/// </summary>
		/// <value>
		/// The top offset.
		/// </value>
		public int TopOffset { get; set; }

		/// <summary>
		/// Each shipment to have labels generated will be listed. The print preferences will be applied to the items in the shipments. 
		/// </summary>
		/// <value>
		/// The shipments.
		/// </value>
		public List<ShipmentReference> Shipments { get; set; } = new List<ShipmentReference>();

		/// <summary>
		/// Loads a LabelAttributes from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static LabelAttributes FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<LabelAttributes>(json);
		}
	}
}
