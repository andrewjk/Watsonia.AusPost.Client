using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public sealed class GetShipmentsRequest : ApiItem
	{
		/// <summary>
		/// A list of shipment ids
		/// </summary>
		/// <value>
		/// The shipment IDs.
		/// </value>
		public List<string> ShipmentIDs { get; set; } = new List<string>();

		/// <summary>
		/// The offset parameter value specifies the numeric value of the first record to be returned in the result, beginning at 0. If you specify the offset parameter, you must also specify the number_of_shipments parameter.
		/// </summary>
		/// <value>
		/// The offset.
		/// </value>
		public int Offset { get; set; }

		/// <summary>
		/// The number_of_shipments parameter specifies the number of records to return in the result. If you specify the number_of_shipments parameter, you must also specify the offset parameter.
		/// </summary>
		/// <value>
		/// The number of shipments.
		/// </value>
		public int NumberOfShipments { get; set; }

		/// <summary>
		/// Setting the status parameter will result in the list returned only containing shipments that are at the given status. The parameter will accept one or more status values separated by a comma. E.g. status=CREATED,INITIATED 
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		public string Status { get; set; }

		/// <summary>
		/// Setting the despatch_date parameter will result in the list returned only containing shipments that have one of the values as despatch_date. The parameter will accept one or more despatch_date values in the format of yyyy-MM-dd separated by a comma. E.g. despatch_date=2016-04-04,2015-12-31
		/// </summary>
		/// <value>
		/// The despatch date.
		/// </value>
		public string DespatchDate { get; set; }

		/// <summary>
		/// Setting the sender_reference parameter will result in the list returned only containing shipments that have one of the values as sender_reference. The parameter will accept one or more sender_reference values separated by a comma. E.g. sender_reference=MYREF-12345
		/// </summary>
		/// <value>
		/// The sender reference.
		/// </value>
		public string SenderReference { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GetShipmentsRequest"/> class.
		/// </summary>
		/// <param name="shipments">The shipments.</param>
		public GetShipmentsRequest(params string[] shipmentIDs)
		{
			this.ShipmentIDs.AddRange(shipmentIDs);
		}

		/// <summary>
		/// Loads a GetShipmentsRequest from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static GetShipmentsRequest FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<GetShipmentsRequest>(json);
		}
	}
}
