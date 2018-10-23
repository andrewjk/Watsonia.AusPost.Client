using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Watsonia.AusPost.Client
{
	/// <summary>
	/// An ItemContents element describes part of the contents of the item.
	/// </summary>
	/// <seealso cref="Watsonia.AusPost.Client.ApiItem" />
	public sealed class ItemContents : ApiItem
	{
		/// <summary>
		/// Description of the contents. This description is validated against a defined list of keywords, to determine whether the item can be carried by Australia Post and/or the item is prohibited in the destination country.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		[Required]
		[StringLength(40)]
		public string Description { get; set; }

		/// <summary>
		/// The quantity of this described content.
		/// </summary>
		/// <value>
		/// The quantity.
		/// </value>
		[Required]
		public int Quantity { get; set; }

		/// <summary>
		/// The weight in kilograms of this described content. If you provide a weight for one ItemContents element, you must provide weights for all ItemContents elements.
		/// </summary>
		/// <value>
		/// The weight.
		/// </value>
		public decimal Weight { get; set; }

		/// <summary>
		/// The value in Australian Dollars of this described content.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		[Required]
		public decimal Value { get; set; }

		/// <summary>
		/// The Harmonised Tariff number that indicates the type of this described content. It is only mandatory if CommercialValue is "true", otherwise it is optional. However, it is a recommended field to expedite the customs process in the receiving country.
		/// </summary>
		/// <value>
		/// The tariff code.
		/// </value>
		public int TariffCode { get; set; }

		/// <summary>
		/// The country in which this described content was manufactured. It is only mandatory if CommercialValue is "true", otherwise it is optional.
		/// </summary>
		/// <value>
		/// The country of origin.
		/// </value>
		[StringLength(2)]
		public string CountryOfOrigin { get; set; }

		/// <summary>
		/// HS Tariff Concession information for Customs.
		/// </summary>
		/// <value>
		/// The tariff concession.
		/// </value>
		[StringLength(20)]
		public string TariffConcession { get; set; }

		/// <summary>
		/// Whether this described content is free trade applicable.
		/// </summary>
		/// <value>
		/// The free trade application.
		/// </value>
		public bool? FreeTradeApplication { get; set; }
	}
}
