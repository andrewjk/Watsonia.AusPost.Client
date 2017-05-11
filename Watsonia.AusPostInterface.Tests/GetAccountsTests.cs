using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface.Tests
{
	[TestClass]
	public class GetAccountsTests
	{
		[TestMethod]
		public async Task GetAccounts()
		{
			AusPost.Testing = true;

			string accountNumber = ConfigurationManager.AppSettings["AusPostAccountNumber"];
			string username = ConfigurationManager.AppSettings["AusPostUsername"];
			string password = ConfigurationManager.AppSettings["AusPostPassword"];
			
			GetAccountsResponse getAccountsResponse = await AusPost.GetAccountsAsync(accountNumber, username, password);

			Assert.AreEqual(true, getAccountsResponse.Succeeded);
			Assert.AreEqual(1, getAccountsResponse.Addresses.Count);
			Assert.AreEqual(0, getAccountsResponse.Errors.Count);
			Assert.AreEqual(0, getAccountsResponse.Warnings.Count);
		}

		[TestMethod]
		public async Task GetAccountsWithError()
		{
			AusPost.Testing = true;

			string accountNumber = "Invalid";
			string username = ConfigurationManager.AppSettings["AusPostUsername"];
			string password = ConfigurationManager.AppSettings["AusPostPassword"];

			GetAccountsResponse getAccountsResponse = await AusPost.GetAccountsAsync(accountNumber, username, password);

			Assert.AreEqual(false, getAccountsResponse.Succeeded);
			Assert.AreEqual(0, getAccountsResponse.Addresses.Count);
			Assert.AreEqual(1, getAccountsResponse.Errors.Count);
			Assert.AreEqual(0, getAccountsResponse.Warnings.Count);
		}
	}
}
