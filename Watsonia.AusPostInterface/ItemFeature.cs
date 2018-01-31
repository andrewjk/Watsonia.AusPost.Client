using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// Additional features for an item.
	/// </summary>
	/// <seealso cref="Watsonia.AusPostInterface.ApiItem" />
	public sealed class ItemFeature : ApiItem
	{
		/// <summary>
		/// Additional information about the feature. Please note that attributes depend on the feature. 
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
