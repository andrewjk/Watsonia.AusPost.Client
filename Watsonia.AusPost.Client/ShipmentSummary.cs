using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public sealed class ShipmentSummary : ApiItem
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
		/// The number of items within the shipment.
		/// </summary>
		/// <value>
		/// The number of items.
		/// </value>
		public int NumberOfItems { get; set; }

		/// <summary>
		/// The number of items in the shipment for each delivery status. The delivery status will be listed with the number of items in the shipment where the delivery status has been applied. 
		/// </summary>
		/// <value>
		/// The tracking summary.
		/// </value>
		public Dictionary<string, int> TrackingSummary { get; set; } = new Dictionary<string, int>();

		/// <summary>
		/// The freight charge for this shipment. 
		/// </summary>
		/// <value>
		/// The freight charge.
		/// </value>
		public decimal FreightCharge { get; set; }

		/// <summary>
		/// The discount for this shipment. 
		/// </summary>
		/// <value>
		/// The discount.
		/// </value>
		public decimal Discount { get; set; }

		/// <summary>
		/// The transit cover charge for this shipment.
		/// This field may be used to specify Transit Cover, Extra Cover or Transit Warranty for Contract, Non-Contract or StarTrack products respectively.
		/// </summary>
		/// <value>
		/// The transit cover.
		/// </value>
		public decimal TransitCover { get; set; }

		/// <summary>
		/// The security surcharge for this shipment. 
		/// </summary>
		/// <value>
		/// The security surcharge.
		/// </value>
		public decimal SecuritySurcharge { get; set; }

		/// <summary>
		/// The fuel surcharge for this shipment. 
		/// </summary>
		/// <value>
		/// The fuel surcharge.
		/// </value>
		public decimal FuelSurcharge { get; set; }

		/// <summary>
		/// Loads a ShipmentSummary from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static ShipmentSummary FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<ShipmentSummary>(json);
		}
	}
}
