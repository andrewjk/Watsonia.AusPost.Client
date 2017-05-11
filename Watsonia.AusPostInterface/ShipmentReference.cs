using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// Shipment information must be supplied for each shipment to be included in the order.
	/// </summary>
	/// <seealso cref="Watsonia.AusPostInterface.ApiItem" />
	public sealed class ShipmentReference : ApiItem
	{
		/// <summary>
		/// Australia Post's unique reference for the shipment. This must reference a shipment previously created but not yet contained in an order. 
		/// </summary>
		/// <value>
		/// The shipment identifier.
		/// </value>
		[StringLength(50)]
		public string ShipmentID { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ShipmentReference"/> class.
		/// </summary>
		/// <param name="shipmentID">The shipment identifier.</param>
		public ShipmentReference(string shipmentID)
		{
			this.ShipmentID = shipmentID;
		}
	}
}
