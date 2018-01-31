using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public sealed class GetAccountsResponse : ApiItem
	{
		/// <summary>
		/// Gets or sets a value indicating whether the request succeeded.
		/// </summary>
		/// <value>
		///   <c>true</c> if the request succeeded; otherwise, <c>false</c>.
		/// </value>
		public bool Succeeded { get; set; }

		/// <summary>
		/// Gets a value indicating whether any errors occurred during the request.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance has errors; otherwise, <c>false</c>.
		/// </value>
		public bool HasErrors
		{
			get
			{
				return this.Errors.Count > 0;
			}
		}

		/// <summary>
		/// Gets a value indicating whether any warnings occurred during the request.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance has warnings; otherwise, <c>false</c>.
		/// </value>
		public bool HasWarnings
		{
			get
			{
				return this.Warnings.Count > 0;
			}
		}

		/// <summary>
		/// Gets or sets any errors that occurred during the request.
		/// </summary>
		/// <value>
		/// The errors.
		/// </value>
		public List<ShipmentErrorResponse> Errors { get; set; } = new List<ShipmentErrorResponse>();

		/// <summary>
		/// Gets or sets any warnings that occurred during the request.
		/// </summary>
		/// <value>
		/// The errors.
		/// </value>
		public List<ShipmentErrorResponse> Warnings { get; set; } = new List<ShipmentErrorResponse>();

		/// <summary>
		/// The charge account for the location.
		/// </summary>
		/// <value>
		/// The account number.
		/// </value>
		public string AccountNumber { get; set; }

		/// <summary>
		/// The name for the location.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// The beginning validity date when the charge account can be used.
		/// </summary>
		/// <value>
		/// The valid from.
		/// </value>
		public string ValidFrom { get; set; }

		/// <summary>
		/// The ending validity date when the charge account can be used.
		/// </summary>
		/// <value>
		/// The valid to.
		/// </value>
		public string ValidTo { get; set; }

		/// <summary>
		/// Whether the charge account has an expired contract.
		/// </summary>
		/// <value>
		///   <c>true</c> if expired; otherwise, <c>false</c>.
		/// </value>
		public bool Expired { get; set; }

		/// <summary>
		/// One or more addresses associated with the location.
		/// </summary>
		/// <value>
		/// The addresses.
		/// </value>
		public List<AccountAddress> Addresses { get; set; } = new List<AccountAddress>();

		/// <summary>
		/// Additional information associated with the location.
		/// </summary>
		/// <value>
		/// The details.
		/// </value>
		public AccountDetails Details { get; set; } = new AccountDetails();

		/// <summary>
		/// The postage products and services that can be used for this location.
		/// </summary>
		/// <value>
		/// The postage products.
		/// </value>
		public List<AccountProduct> PostageProducts { get; set; } = new List<AccountProduct>();

		/// <summary>
		/// The ID issued to a merchant as part of the setup process.
		/// </summary>
		/// <value>
		/// The merchant location identifier.
		/// </value>
		public string MerchantLocationID { get; set; }

		/// <summary>
		/// Whether the merchant's account is credit blocked. Any account with this status will be forbidden from creating shipments or orders 
		/// </summary>
		/// <value>
		///   <c>true</c> if [credit blocked]; otherwise, <c>false</c>.
		/// </value>
		public bool CreditBlocked { get; set; }

		/// <summary>
		/// Loads a GetAccountsResponse from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static GetAccountsResponse FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<GetAccountsResponse>(json);
		}
	}
}
