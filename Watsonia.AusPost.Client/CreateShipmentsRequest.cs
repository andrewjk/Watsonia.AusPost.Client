using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
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

		/// <summary>
		/// Loads a CreateShipmentsRequest from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static CreateShipmentsRequest FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<CreateShipmentsRequest>(json);
		}
	}
}
