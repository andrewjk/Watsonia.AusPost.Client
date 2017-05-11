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
	}
}
