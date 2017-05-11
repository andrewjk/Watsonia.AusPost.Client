using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// The address where items will be delivered.
	/// </summary>
	public sealed class Recipient : ApiItem
	{
		/// <summary>
		/// The name of the receiver.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[Required]
		[StringLength(40)]
		public string Name { get; set; }

		/// <summary>
		/// The Australia Post customer number.
		/// </summary>
		/// <value>
		/// The apcn.
		/// </value>
		[StringLength(10)]
		public string Apcn { get; set; }

		/// <summary>
		/// The name of the business for the address.
		/// </summary>
		/// <value>
		/// The name of the business.
		/// </value>
		[StringLength(40)]
		public string BusinessName { get; set; }

		/// <summary>
		/// The type of address.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public RecipientType Type { get; set; }

		/// <summary>
		/// The address line 1 of the address.
		/// </summary>
		/// <value>
		/// The line1.
		/// </value>
		[Required]
		[StringLength(40)]
		[JsonIgnore]
		public string Line1 { get; set; }

		/// <summary>
		/// The address line 2 of the address.
		/// </summary>
		/// <value>
		/// The line2.
		/// </value>
		[StringLength(40)]
		[JsonIgnore]
		public string Line2 { get; set; }

		/// <summary>
		/// The address line 3 of the address.
		/// </summary>
		/// <value>
		/// The line1.
		/// </value>
		[StringLength(40)]
		[JsonIgnore]
		public string Line3 { get; set; }

		/// <summary>
		/// The address lines of the address.
		/// </summary>
		/// <value>
		/// The lines.
		/// </value>
		public string[] Lines
		{
			get
			{
				return string.Join("\n", this.Line1, this.Line2, this.Line3).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
			}
		}

		/// <summary>
		/// The suburb for the address.
		/// </summary>
		/// <value>
		/// The suburb.
		/// </value>
		[Required]
		[StringLength(30)]
		public string Suburb { get; set; }

		/// <summary>
		/// The state code for the address.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		[Required]
		public State State { get; set; }

		/// <summary>
		/// The postcode for the address. This is mandatory for domestic shipments and shipments to International Kahala Posts Group. It is optional for other International shipments. 
		/// </summary>
		/// <value>
		/// The postcode.
		/// </value>
		[Required]
		[StringLength(4)]
		public string Postcode { get; set; }

		/// <summary>
		/// The country code for the address. The country code must conform to ISO 3166-1 alpha-2 standard. 
		/// </summary>
		/// <value>
		/// The country.
		/// </value>
		[StringLength(2)]
		public string Country { get; set; }

		/// <summary>
		/// The sender's phone number.
		/// </summary>
		/// <value>
		/// The phone.
		/// </value>
		[StringLength(20)]
		public string Phone { get; set; }

		/// <summary>
		/// The sender's email address.
		/// </summary>
		/// <value>
		/// The email.
		/// </value>
		[StringLength(50)]
		public string Email { get; set; }

		/// <summary>
		/// Instructions to aid in prompt delivery of the item.
		/// </summary>
		/// <remarks>
		/// For StarTrack products, delivery instructions is an array of strings with a maximum of 3 lines, each with a maximum of 25 characters. Delivery instructions for StarTrack products will be printed as "Special instructions" on labels. 
		/// </remarks>
		/// <value>
		/// The delivery instructions.
		/// </value>
		[StringLength(128)]
		public string DeliveryInstructions { get; set; }
	}
}
