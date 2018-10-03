using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client.Tests
{
	[TestClass]
	public class GetAccountsTests
	{
		[TestMethod]
		public async Task GetAccounts()
		{
			string accountNumber = AppConfiguration.AusPostAccountNumber;
			string username = AppConfiguration.AusPostUsername;
			string password = AppConfiguration.AusPostPassword;
			
			var client = new ShippingClient(accountNumber, username, password);
			client.Testing = true;

			var getAccountsResponse = await client.GetAccountsAsync();

			Assert.AreEqual(true, getAccountsResponse.Succeeded, string.Join(", ", getAccountsResponse.Errors.Select(e => e.Message)));
			Assert.AreEqual(1, getAccountsResponse.Addresses.Count);
			Assert.AreEqual(0, getAccountsResponse.Errors.Count);
			Assert.AreEqual(0, getAccountsResponse.Warnings.Count);
		}

		[TestMethod]
		public async Task GetAccountsWithError()
		{
			string accountNumber = "Invalid";
			string username = AppConfiguration.AusPostUsername;
			string password = AppConfiguration.AusPostPassword;

			var client = new ShippingClient(accountNumber, username, password);
			client.Testing = true;

			var getAccountsResponse = await client.GetAccountsAsync();

			Assert.AreEqual(false, getAccountsResponse.Succeeded);
			Assert.AreEqual(0, getAccountsResponse.Addresses.Count);
			Assert.AreEqual(1, getAccountsResponse.Errors.Count);
			Assert.AreEqual(0, getAccountsResponse.Warnings.Count);
		}
	}
}
