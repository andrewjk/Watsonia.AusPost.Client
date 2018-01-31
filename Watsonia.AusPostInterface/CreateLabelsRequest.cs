using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	public sealed class CreateLabelsRequest : ApiItem
	{
		/// <summary>
		/// The required preferences to be applied.
		/// </summary>
		public List<LabelPreference> Preferences { get; set; } = new List<LabelPreference>();

		/// <summary>
		/// Each shipment to have labels generated will be listed. The print preferences will be applied to the items in the shipments.
		/// </summary>
		/// <value>
		/// The shipments.
		/// </value>
		public List<ShipmentReference> Shipments { get; set; } = new List<ShipmentReference>();

		/// <summary>
		/// Initializes a new instance of the <see cref="CreateLabelsRequest" /> class.
		/// </summary>
		/// <param name="preferences">The preferences.</param>
		/// <param name="shipments">The shipments.</param>
		public CreateLabelsRequest(List<LabelPreference> preferences, List<ShipmentReference> shipments)
		{
			this.Preferences.AddRange(preferences);
			this.Shipments.AddRange(shipments);
		}

		/// <summary>
		/// Loads a CreateLabelsRequest from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static CreateLabelsRequest FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<CreateLabelsRequest>(json);
		}
	}
}
