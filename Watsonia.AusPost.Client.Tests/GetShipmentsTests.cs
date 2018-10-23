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
	public class GetShipmentsTests
	{
		[TestMethod]
		public async Task GetShipments()
		{
			string accountNumber = AppConfiguration.AusPostAccountNumber;
			string username = AppConfiguration.AusPostUsername;
			string password = AppConfiguration.AusPostPassword;

			var client = new ShippingClient(accountNumber, username, password);
			client.Testing = true;

			var createOrderRequest = CreateCreateOrderRequest();

			var createOrderResponse = await client.CreateOrderIncludingShipmentsAsync(createOrderRequest);

			Assert.AreEqual(true, createOrderResponse.Succeeded, string.Join(", ", createOrderResponse.Errors.Select(e => e.Message)));
			Assert.AreEqual(true, !string.IsNullOrEmpty(createOrderResponse.Order.OrderID));
			Assert.AreEqual(0, createOrderResponse.Errors.Count);
			Assert.AreEqual(0, createOrderResponse.Warnings.Count);

			var getShipmentsRequest = CreateGetShipmentsRequest(createOrderResponse);

			var getShipmentsResponse = await client.GetShipmentsAsync(getShipmentsRequest);

			Assert.AreEqual(true, getShipmentsResponse.Succeeded, string.Join(", ", getShipmentsResponse.Errors.Select(e => e.Message)));
			Assert.AreEqual(2, getShipmentsResponse.Shipments.Count);
			Assert.AreEqual(0, getShipmentsResponse.Errors.Count);
			Assert.AreEqual(0, getShipmentsResponse.Warnings.Count);
		}

		[TestMethod]
		public async Task GetShipmentsWithError()
		{
			string accountNumber = AppConfiguration.AusPostAccountNumber;
			string username = AppConfiguration.AusPostUsername;
			string password = AppConfiguration.AusPostPassword;

			var client = new ShippingClient(accountNumber, username, password);
			client.Testing = true;

			var createOrderRequest = CreateCreateOrderRequest();

			var createOrderResponse = await client.CreateOrderIncludingShipmentsAsync(createOrderRequest);

			Assert.AreEqual(true, createOrderResponse.Succeeded, string.Join(", ", createOrderResponse.Errors.Select(e => e.Message)));
			Assert.AreEqual(true, !string.IsNullOrEmpty(createOrderResponse.Order.OrderID));
			Assert.AreEqual(0, createOrderResponse.Errors.Count);
			Assert.AreEqual(0, createOrderResponse.Warnings.Count);

			var getShipmentsRequest = CreateGetShipmentsRequest(createOrderResponse);

			// Make a shipment ID incorrect
			getShipmentsRequest.ShipmentIDs[1] = "Invalid";

			var getShipmentsResponse = await client.GetShipmentsAsync(getShipmentsRequest);

			Assert.AreEqual(true, getShipmentsResponse.Succeeded, string.Join(", ", getShipmentsResponse.Errors.Select(e => e.Message)));
			Assert.AreEqual(1, getShipmentsResponse.Shipments.Count);
			Assert.AreEqual(1, getShipmentsResponse.Errors.Count);
			Assert.AreEqual("44013", getShipmentsResponse.Errors[0].Code);
			Assert.AreEqual(0, getShipmentsResponse.Warnings.Count);
		}

		private CreateOrderIncludingShipmentsRequest CreateCreateOrderRequest()
		{
			var shipment1 = new Shipment();

			shipment1.ShipmentReference = "XYZ-001-01";
			shipment1.CustomerReference1 = "Order 001";
			shipment1.CustomerReference2 = "SKU-1";
			shipment1.EmailTrackingEnabled = true;
			shipment1.From.Name = "John Citizen";
			shipment1.From.Lines = new string[] { "1 Main Street" };
			shipment1.From.Suburb = "MELBOURNE";
			shipment1.From.State = State.Victoria;
			shipment1.From.Postcode = "3000";
			shipment1.From.Phone = "0401234567";
			shipment1.From.Email = "john.citizen@citizen.com";

			shipment1.To.Name = "Jane Smith";
			shipment1.To.BusinessName = "Smith Pty Ltd";
			shipment1.To.Lines = new string[] { "123 Centre Road" };
			shipment1.To.Suburb = "Sydney";
			shipment1.To.State = State.NSW;
			shipment1.To.Postcode = "2000";
			shipment1.To.Phone = "0412345678";
			shipment1.To.Email = "jane.smith@smith.com";

			var item1 = new Item();
			item1.ItemReference = "SKU-1";
			item1.ProductID = "7E55";
			item1.Length = 10;
			item1.Height = 10;
			item1.Width = 10;
			item1.Weight = 1;
			item1.AuthorityToLeave = false;
			item1.AllowPartialDelivery = true;
			item1.Features.Add("TRANSIT_COVER", new ItemFeature());
			item1.Features["TRANSIT_COVER"].Attributes.CoverAmount = 500;
			shipment1.Items.Add(item1);

			var shipment2 = new Shipment();

			shipment2.ShipmentReference = "XYZ-001-01";
			shipment2.CustomerReference1 = "Order 001";
			shipment2.CustomerReference2 = "SKU-2, SKU-3";
			shipment2.EmailTrackingEnabled = true;
			shipment2.From.Name = "John Citizen";
			shipment2.From.Lines = new string[] { "1 Main Street" };
			shipment2.From.Suburb = "MELBOURNE";
			shipment2.From.State = State.Victoria;
			shipment2.From.Postcode = "3000";
			shipment2.From.Phone = "0401234567";
			shipment2.From.Email = "john.citizen@citizen.com";

			shipment2.To.Name = "Jane Smith";
			shipment2.To.BusinessName = "Smith Pty Ltd";
			shipment2.To.Lines = new string[] { "123 Centre Road" };
			shipment2.To.Suburb = "Sydney";
			shipment2.To.State = State.NSW;
			shipment2.To.Postcode = "2000";
			shipment2.To.Phone = "0412345678";
			shipment2.To.Email = "jane.smith@smith.com";

			var item2 = new Item();
			item2.ItemReference = "SKU-2";
			item2.ProductID = "7E55";
			item2.Length = 10;
			item2.Height = 10;
			item2.Width = 10;
			item2.Weight = 1;
			item2.AuthorityToLeave = false;
			item2.AllowPartialDelivery = true;
			shipment2.Items.Add(item2);

			var item3 = new Item();
			item3.ItemReference = "SKU-3";
			item3.ProductID = "7E55";
			item3.Length = 10;
			item3.Height = 10;
			item3.Width = 10;
			item3.Weight = 1;
			item3.AuthorityToLeave = false;
			item3.AllowPartialDelivery = true;
			shipment2.Items.Add(item3);

			return new CreateOrderIncludingShipmentsRequest(shipment1, shipment2);
		}

		private GetShipmentsRequest CreateGetShipmentsRequest(CreateOrderIncludingShipmentsResponse createOrderResponse)
		{
			var shipmentIDs = createOrderResponse.Order.Shipments.Select(s => s.ShipmentID).ToArray();
			return new GetShipmentsRequest(shipmentIDs);
		}
	}
}
