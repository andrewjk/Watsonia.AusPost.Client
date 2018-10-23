using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	/// <summary>
	/// Additional features for an item.
	/// </summary>
	/// <seealso cref="Watsonia.AusPost.Client.ApiItem" />
	public sealed class ItemFeature : ApiItem
	{
		/// <summary>
		/// Name of additional feature. Eg: DELIVERY_DATE, DELIVERY_TIMES, PICKUP_DATE, PICKUP_TIME COMMERCIAL_CLEARANCE.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Additional information about the feature. Please note that attributes depend on the feature. Please refer to Shipment Features.
		/// </summary>
		/// <value>
		/// The attributes.
		/// </value>
		public ItemFeatureAttribute Attributes { get; set; } = new ItemFeatureAttribute();

		/// <summary>
		/// Loads a ItemFeature from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static ItemFeature FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<ItemFeature>(json);
		}
	}
}
