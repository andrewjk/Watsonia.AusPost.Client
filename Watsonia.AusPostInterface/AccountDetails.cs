using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// Additional information associated with the location.
	/// </summary>
	/// <seealso cref="Watsonia.AusPostInterface.ApiItem" />
	public sealed class AccountDetails : ApiItem
	{
		/// <summary>
		/// The postcode where parcels for the location will be lodged.
		/// </summary>
		/// <value>
		/// The lodgement postcode.
		/// </value>
		public string LodgementPostcode { get; set; }

		/// <summary>
		/// The merchant's Australian Business Number (ABN).
		/// </summary>
		/// <value>
		/// The abn.
		/// </value>
		public string Abn { get; set; }

		/// <summary>
		/// The merchant's Australian Company Number (ACN).
		/// </summary>
		/// <value>
		/// The acn.
		/// </value>
		public string Acn { get; set; }

		/// <summary>
		/// The phone number for the merchant at the location.
		/// </summary>
		/// <value>
		/// The contact number.
		/// </value>
		public string ContactNumber { get; set; }

		/// <summary>
		/// The email address for the merchant at the location.
		/// </summary>
		/// <value>
		/// The email address.
		/// </value>
		public string EmailAddress { get; set; }

		/// <summary>
		/// Loads a AccountDetails from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static AccountDetails FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<AccountDetails>(json);
		}
	}
}
