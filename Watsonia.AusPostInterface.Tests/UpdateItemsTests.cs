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
	public class UpdateItemsTests
	{
		[TestMethod]
		public async Task UpdateItems()
		{
			AusPost.Testing = true;

			string accountNumber = ConfigurationManager.AppSettings["AusPostAccountNumber"];
			string username = ConfigurationManager.AppSettings["AusPostUsername"];
			string password = ConfigurationManager.AppSettings["AusPostPassword"];

			var createRequest = CreateCreateShipmentsRequest();

			CreateShipmentsResponse createResponse = await AusPost.CreateShipmentsAsync(accountNumber, username, password, createRequest);
			
			Assert.AreEqual(true, createResponse.Succeeded);
			Assert.AreEqual(1, createResponse.Shipments.Count);
			Assert.AreEqual(1, createResponse.Shipments[0].Items.Count);

			var updateRequest = CreateUpdateItemsRequest();

			UpdateItemsResponse updateResponse = await AusPost.UpdateItemsAsync(accountNumber, username, password, createResponse.Shipments[0].ShipmentID, updateRequest);

			// NOTE: This doesn't return anything other than a general success or fail
			Assert.AreEqual(true, updateResponse.Succeeded);
			Assert.AreEqual(0, createResponse.Errors.Count);
			Assert.AreEqual(0, createResponse.Warnings.Count);
		}

		[TestMethod]
		public async Task UpdateItemsWithError()
		{
			AusPost.Testing = true;

			var createRequest = CreateCreateShipmentsRequest();

			string accountNumber = ConfigurationManager.AppSettings["AusPostAccountNumber"];
			string username = ConfigurationManager.AppSettings["AusPostUsername"];
			string password = ConfigurationManager.AppSettings["AusPostPassword"];

			CreateShipmentsResponse createResponse = await AusPost.CreateShipmentsAsync(accountNumber, username, password, createRequest);

			Assert.AreEqual(true, createResponse.Succeeded);
			Assert.AreEqual(1, createResponse.Shipments.Count);
			Assert.AreEqual(1, createResponse.Shipments[0].Items.Count);

			var updateRequest = CreateUpdateItemsRequest();

			// Make an item way too big
			updateRequest.Items[1].Width = 20000;

			UpdateItemsResponse updateResponse = await AusPost.UpdateItemsAsync(accountNumber, username, password, createResponse.Shipments[0].ShipmentID, updateRequest);

			// NOTE: This doesn't return anything other than a general success or fail
			Assert.AreEqual(false, updateResponse.Succeeded);
			Assert.AreEqual(0, createResponse.Errors.Count);
			Assert.AreEqual(0, createResponse.Warnings.Count);
		}

		private CreateShipmentsRequest CreateCreateShipmentsRequest()
		{
			var shipment = new Shipment();

			shipment.ShipmentReference = "XYZ-001-01";
			shipment.CustomerReference1 = "Order 001";
			shipment.CustomerReference2 = "SKU-1, SKU-2, SKU-3";
			shipment.EmailTrackingEnabled = true;
			shipment.From.Name = "John Citizen";
			shipment.From.Line1 = "1 Main Street";
			shipment.From.Suburb = "MELBOURNE";
			shipment.From.State = State.Victoria;
			shipment.From.Postcode = "3000";
			shipment.From.Phone = "0401234567";
			shipment.From.Email = "john.citizen@citizen.com";

			shipment.To.Name = "Jane Smith";
			shipment.To.BusinessName = "Smith Pty Ltd";
			shipment.To.Line1 = "123 Centre Road";
			shipment.To.Suburb = "Sydney";
			shipment.To.State = State.NSW;
			shipment.To.Postcode = "2000";
			shipment.To.Phone = "0412345678";
			shipment.To.Email = "jane.smith@smith.com";

			var item1 = new Item();
			item1.ItemReference = "SKU-1";
			item1.ProductID = "T28S";
			item1.Length = 10;
			item1.Height = 10;
			item1.Width = 10;
			item1.Weight = 1;
			item1.AuthorityToLeave = false;
			item1.AllowPartialDelivery = true;
			item1.Features.Add("TRANSIT_COVER", new ItemFeature());
			item1.Features["TRANSIT_COVER"].Attributes.CoverAmount = 1000;
			shipment.Items.Add(item1);

			return new CreateShipmentsRequest(shipment);
		}

		private UpdateItemsRequest CreateUpdateItemsRequest()
		{
			var item2 = new Item();
			item2.ItemReference = "SKU-2";
			item2.ProductID = "T28S";
			item2.Length = 10;
			item2.Height = 10;
			item2.Width = 10;
			item2.Weight = 1;
			item2.AuthorityToLeave = false;
			item2.AllowPartialDelivery = true;

			var item3 = new Item();
			item3.ItemReference = "SKU-3";
			item3.ProductID = "T28S";
			item3.Length = 10;
			item3.Height = 10;
			item3.Width = 10;
			item3.Weight = 1;
			item3.AuthorityToLeave = false;
			item3.AllowPartialDelivery = true;

			return new UpdateItemsRequest(item2, item3);
		}
	}
}
