using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	public sealed class CreateShipmentsRequest : ApiItem
	{
		/// <summary>
		/// Shipment information to be supplied for each delivery of items to a physical address.
		/// </summary>
		/// <value>
		/// The shipments.
		/// </value>
		public List<Shipment> Shipments { get; set; } = new List<Shipment>();

		/// <summary>
		/// Initializes a new instance of the <see cref="CreateShipmentsRequest"/> class.
		/// </summary>
		/// <param name="shipments">The shipments.</param>
		public CreateShipmentsRequest(params Shipment[] shipments)
		{
			this.Shipments.AddRange(shipments);
		}
	}
}
