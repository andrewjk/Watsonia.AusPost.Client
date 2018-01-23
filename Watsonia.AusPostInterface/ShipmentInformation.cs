﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// Shipment information for each shipment and items created.
	/// </summary>
	public sealed class ShipmentInformation : ApiItem
	{
		/// <summary>
		/// The identifier for the shipment generated by Australia Post.
		/// </summary>
		/// <value>
		/// The shipment identifier.
		/// </value>
		[StringLength(50)]
		public string ShipmentID { get; set; }

		/// <summary>
		/// The reference for the shipment, generated by the merchant and passed in the request.
		/// </summary>
		/// <value>
		/// The shipment reference.
		/// </value>
		[StringLength(50)]
		public string ShipmentReference { get; set; }

		/// <summary>
		/// The date and time that the shipment was created.
		/// </summary>
		/// <value>
		/// The shipment creation date.
		/// </value>
		public DateTime ShipmentCreationDate { get; set; }

		/// <summary>
		/// Whether the recipient of the shipment will receive tracking notification email.
		/// </summary>
		/// <value>
		/// <c>true</c> if [email tracking enabled]; otherwise, <c>false</c>.
		/// </value>
		public bool EmailTrackingEnabled { get; set; }

		/// <summary>
		/// The value of the consolidate flag for this shipment. 
		/// </summary>
		/// <value>
		///  <c>true</c> if consolidate; otherwise, <c>false</c>.
		/// </value>
		public bool Consolidate { get; set; }

		/// <summary>
		/// An item element is to be supplied for each parcel.
		/// </summary>
		/// <value>
		/// The items.
		/// </value>
		public List<ItemInformation> Items { get; set; } = new List<ItemInformation>();

		/// <summary>
		/// Value is "DESPATCH" to indicate an outbound or normal shipment or "RETURN" to indicate a returns shipment.
		/// </summary>
		/// <value>
		/// The type of the movement.
		/// </value>
		public MovementType MovementType { get; set; }

		/// <summary>
		/// The address where the items will be delivered.
		/// </summary>
		/// <value>
		/// To.
		/// </value>
		public Recipient To { get; set; } = new Recipient();

		/// <summary>
		/// Summary pricing information for the shipment.
		/// </summary>
		/// <value>
		/// The summary.
		/// </value>
		public ShipmentSummary ShipmentSummary { get; set; }

		/// <summary>
		/// The identifier for the order generated by Australia Post if this shipment belongs to an order.
		/// </summary>
		/// <value>
		/// The order identifier.
		/// </value>
		public string OrderID { get; set; }
	}
}
