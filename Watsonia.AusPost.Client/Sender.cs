using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	/// <summary>
	/// The address where items will be sent from. 
	/// </summary>
	public sealed class Sender : ApiItem
	{
		/// <summary>
		/// The name of the sender.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[Required]
		[StringLength(40)]
		public string Name { get; set; }

		///// <summary>
		///// The type of address. If this field is supplied, its value must be "MERCHANT_LOCATION".
		///// </summary>
		///// <value>
		///// The type.
		///// </value>
		//public string Type { get; set; }


		/// <summary>
		/// The address line 1 of the address.
		/// </summary>
		/// <value>
		/// The line1.
		/// </value>
		[Required]
		[StringLength(40)]
		[JsonIgnore]
		public string Line1
		{
			get
			{
				return this.Lines != null && this.Lines.Length > 0 ? this.Lines[0] : null;
			}
		}

		/// <summary>
		/// The address line 2 of the address.
		/// </summary>
		/// <value>
		/// The line2.
		/// </value>
		[StringLength(40)]
		[JsonIgnore]
		public string Line2
		{
			get
			{
				return this.Lines != null && this.Lines.Length > 1 ? this.Lines[1] : null;
			}
		}

		/// <summary>
		/// The address line 3 of the address.
		/// </summary>
		/// <value>
		/// The line1.
		/// </value>
		[StringLength(40)]
		[JsonIgnore]
		public string Line3
		{
			get
			{
				return this.Lines != null && this.Lines.Length > 2 ? this.Lines[2] : null;
			}
		}

		/// <summary>
		/// The address lines of the address.
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
		/// The postcode for the address.
		/// </summary>
		/// <value>
		/// The postcode.
		/// </value>
		[Required]
		[StringLength(4)]
		public string Postcode { get; set; }

		///// <summary>
		///// The country code for the address. If specified, it must be "AU".
		///// </summary>
		///// <value>
		///// The country.
		///// </value>
		//public string Country { get; set; }

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
		/// Loads a Sender from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static Sender FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<Sender>(json);
		}
	}
}
