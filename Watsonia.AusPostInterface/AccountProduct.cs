using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// The postage products and services that can be used for this location.
	/// </summary>
	/// <seealso cref="Watsonia.AusPostInterface.ApiItem" />
	public sealed class AccountProduct : ApiItem
	{
		/// <summary>
		/// The name for the postage product.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public string Type { get; set; }

		/// <summary>
		/// The product group name. Used for generating labels for items that reference the postage product. 
		/// </summary>
		/// <value>
		/// The group.
		/// </value>
		public string Group { get; set; }

		/// <summary>
		/// The code that Australia Post uses to reference the postage product.
		/// </summary>
		/// <value>
		/// The product identifier.
		/// </value>
		public string ProductID { get; set; }

		// TODO: Options

		// TODO: Contract

		// TODO: AuthorityToLeaveThreshold

		// TODO: Features

		/// <summary>
		/// Loads a AccountProduct from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static AccountProduct FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<AccountProduct>(json);
		}
	}
}
