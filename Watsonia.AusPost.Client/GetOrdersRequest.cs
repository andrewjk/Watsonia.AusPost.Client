using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public sealed class GetOrdersRequest : ApiItem
	{
		// HACK: I don't think this works, but I'm not 100% sure:
		///// <summary>
		///// A list of order ids
		///// </summary>
		///// <value>
		///// The order IDs.
		///// </value>
		//public List<string> OrderIDs { get; set; } = new List<string>();

		/// <summary>
		/// The offset parameter value specifies the numeric value of the first record to be returned in the result, beginning at 0. If you specify the offset parameter, you must also specify the number_of_orders parameter.
		/// </summary>
		/// <value>
		/// The offset.
		/// </value>
		public int Offset { get; set; }

		/// <summary>
		/// The number_of_orders parameter specifies the number of records to return in the result. If you specify the number_of_orders parameter, you must also specify the offset parameter.
		/// </summary>
		/// <value>
		/// The number of orders.
		/// </value>
		public int NumberOfOrders { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GetOrdersRequest"/> class.
		/// </summary>
		public GetOrdersRequest()
		{
		}

		///// <summary>
		///// Initializes a new instance of the <see cref="GetOrdersRequest"/> class.
		///// </summary>
		///// <param name="orders">The orders.</param>
		//public GetOrdersRequest(params string[] orderIDs)
		//{
		//	this.OrderIDs.AddRange(orderIDs);
		//}

		/// <summary>
		/// Loads a GetOrdersRequest from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static GetOrdersRequest FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<GetOrdersRequest>(json);
		}
	}
}
