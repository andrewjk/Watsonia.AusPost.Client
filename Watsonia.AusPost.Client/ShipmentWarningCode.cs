using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public enum ShipmentWarningCode
	{
		/// <summary>
		/// No warning.
		/// </summary>
		None,
		/// <summary>
		/// Your account currently does not have a contracted rate for this product, "from" and "to" lane combination in shipment SHIPMENT ID - please contact your account manager for further information. 
		/// </summary>
		NoContractPricingAvailableForShipment,
		/// <summary>
		/// Incomplete dimensions supplied - price will be calculated on weight.
		/// </summary>
		PartialDimensionsInShipmentWarning,
		/// <summary>
		/// Partial delivery is not applicable for this product.
		/// </summary>
		PartialDeliveryNotApplicableWarning,
		/// <summary>
		/// An unknown warning occurred.
		/// </summary>
		Unknown
	}
}
