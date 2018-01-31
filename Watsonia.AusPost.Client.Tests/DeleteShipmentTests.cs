﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client.Tests
{
	[TestClass]
	public class DeleteShipmentTests
	{
		[TestMethod]
		public async Task DeleteShipment()
		{
			string accountNumber = ConfigurationManager.AppSettings["AusPostAccountNumber"];
			string username = ConfigurationManager.AppSettings["AusPostUsername"];
			string password = ConfigurationManager.AppSettings["AusPostPassword"];

			var client = new ShippingClient(accountNumber, username, password);
			client.Testing = true;

			var createRequest = CreateCreateShipmentsRequest();

			var createResponse = await client.CreateShipmentsAsync(createRequest);
			
			Assert.AreEqual(true, createResponse.Succeeded);
			Assert.AreEqual(1, createResponse.Shipments.Count);
			Assert.AreEqual(1, createResponse.Shipments[0].Items.Count);

			var updateResponse = await client.DeleteShipmentAsync(createResponse.Shipments[0].ShipmentID);

			// NOTE: This doesn't return anything other than a general success or fail
			Assert.AreEqual(true, updateResponse.Succeeded);
			Assert.AreEqual(0, createResponse.Errors.Count);
			Assert.AreEqual(0, createResponse.Warnings.Count);
		}

		[TestMethod]
		public async Task DeleteShipmentWithError()
		{
			string accountNumber = ConfigurationManager.AppSettings["AusPostAccountNumber"];
			string username = ConfigurationManager.AppSettings["AusPostUsername"];
			string password = ConfigurationManager.AppSettings["AusPostPassword"];

			var client = new ShippingClient(accountNumber, username, password);
			client.Testing = true;

			var createRequest = CreateCreateShipmentsRequest();

			var createResponse = await client.CreateShipmentsAsync(createRequest);

			Assert.AreEqual(true, createResponse.Succeeded);
			Assert.AreEqual(1, createResponse.Shipments.Count);
			Assert.AreEqual(1, createResponse.Shipments[0].Items.Count);
			
			var updateResponse = await client.DeleteShipmentAsync("Invalid Shipment ID");

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
			shipment.From.Lines = new string[] { "1 Main Street" };
			shipment.From.Suburb = "MELBOURNE";
			shipment.From.State = State.Victoria;
			shipment.From.Postcode = "3000";
			shipment.From.Phone = "0401234567";
			shipment.From.Email = "john.citizen@citizen.com";

			shipment.To.Name = "Jane Smith";
			shipment.To.BusinessName = "Smith Pty Ltd";
			shipment.To.Lines = new string[] { "123 Centre Road" };
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

		private GetShipmentsRequest CreateGetShipmentsRequest(CreateShipmentsResponse createShipmentsResponse)
		{
			var shipmentIDs = createShipmentsResponse.Shipments.Select(s => s.ShipmentID).ToArray();
			return new GetShipmentsRequest(shipmentIDs);
		}
	}
}
