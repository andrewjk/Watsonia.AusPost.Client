using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	public sealed class OrderSummary : ApiItem
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
		/// The number of shipments included in the order.
		/// </summary>
		/// <value>
		/// The number of items.
		/// </value>
		public int NumberOfShipments { get; set; }

		/// <summary>
		/// The number of items in the shipment for each delivery status. The delivery status will be listed with the number of items in the shipment where the delivery status has been applied. 
		/// </summary>
		/// <value>
		/// The tracking summary.
		/// </value>
		public Dictionary<string, int> TrackingSummary { get; set; } = new Dictionary<string, int>();
	}
}
