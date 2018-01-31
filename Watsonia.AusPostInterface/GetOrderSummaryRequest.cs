using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	public sealed class GetOrderSummaryRequest : ApiItem
	{
		/// <summary>
		/// Numeric id of the charge account to query. Note this is a parameter to the request in addition to the account-number header field.
		/// </summary>
		/// <value>
		/// The order id you wish to retrieve the summary for.
		/// </value>
		public string AccountNumber { get; set; }

		/// <summary>
		/// The order id you wish to retrieve the summary for.
		/// </summary>
		/// <value>
		/// The order identifier.
		/// </value>
		public string OrderID { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="CreateLabelsRequest" /> class.
		/// </summary>
		/// <param name="orderID">The order id you wish to retrieve the summary for.</param>
		public GetOrderSummaryRequest(string orderID)
		{
			this.OrderID = orderID;
		}

		/// <summary>
		/// Loads a GetOrderSummaryRequest from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static GetOrderSummaryRequest FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<GetOrderSummaryRequest>(json);
		}
	}
}
