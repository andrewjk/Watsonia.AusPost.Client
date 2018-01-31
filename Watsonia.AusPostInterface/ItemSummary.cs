using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// Summary pricing information for each item in the shipment.
	/// </summary>
	/// <seealso cref="Watsonia.AusPostInterface.ApiItem" />
	public sealed class ItemSummary : ApiItem
	{
		/// <summary>
		/// The total price of the shipment, including goods and services tax (G.S.T).
		/// </summary>
		/// <value>
		/// The total cost.
		/// </value>
		public decimal TotalCost { get; set; }

		/// <summary>
		/// The goods and services tax amount included in the total cost.
		/// </summary>
		/// <value>
		/// The total GST.
		/// </value>
		public decimal TotalGst { get; set; }

		/// <summary>
		/// The status of the item.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		public string Status { get; set; }

		/// <summary>
		/// Loads a ItemSummary from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static ItemSummary FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<ItemSummary>(json);
		}
	}
}
