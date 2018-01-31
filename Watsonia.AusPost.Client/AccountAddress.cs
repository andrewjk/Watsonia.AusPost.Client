using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	/// <summary>
	/// One or more addresses associated with the location.
	/// </summary>
	/// <seealso cref="Watsonia.AusPost.Client.ApiItem" />
	public sealed class AccountAddress : ApiItem
	{
		/// <summary>
		/// The classification for the address. 
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public string Type { get; set; }

		/// <summary>
		/// The address lines for the address. Minimum of one address line, up to a maximum of three. The second address line can accommodate up to 60 characters. 
		/// </summary>
		/// <value>
		/// The lines.
		/// </value>
		public string[] Lines { get; set; }

		/// <summary>
		/// The suburb for the address.
		/// </summary>
		/// <value>
		/// The suburb.
		/// </value>
		public string Suburb { get; set; }

		/// <summary>
		/// The state code for the address. Valid values are: ACT, NSW, NT, QLD, SA, TAS, VIC, WA.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		public State State { get; set; }

		/// <summary>
		/// The postcode for the address.
		/// </summary>
		/// <value>
		/// The postcode.
		/// </value>
		public string Postcode { get; set; }

		/// <summary>
		/// The country code for the address.
		/// </summary>
		/// <value>
		/// The country.
		/// </value>
		public string Country { get; set; }

		/// <summary>
		/// Loads a AccountAddress from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static AccountAddress FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<AccountAddress>(json);
		}
	}
}
