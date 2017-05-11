﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface.Tests
{
	[TestClass]
	public class CreateLabelsTests
	{
		[TestMethod]
		public async Task CreateLabels()
		{
			AusPost.Testing = true;

			string accountNumber = ConfigurationManager.AppSettings["AusPostAccountNumber"];
			string username = ConfigurationManager.AppSettings["AusPostUsername"];
			string password = ConfigurationManager.AppSettings["AusPostPassword"];

			var createShipmentsRequest = CreateCreateShipmentsRequest();

			CreateShipmentsResponse createShipmentsResponse = await AusPost.CreateShipmentsAsync(accountNumber, username, password, createShipmentsRequest);

			Assert.AreEqual(true, createShipmentsResponse.Succeeded);
			Assert.AreEqual(1, createShipmentsResponse.Shipments.Count);
			Assert.AreEqual(1, createShipmentsResponse.Shipments[0].Items.Count);

			var updateRequest = CreateCreateLabelsRequest(createShipmentsResponse.Shipments[0].ShipmentID);

			CreateLabelsResponse createLabelsResponse = await AusPost.CreateLabelsAsync(accountNumber, username, password, updateRequest);

			Assert.AreEqual(true, createLabelsResponse.Succeeded);
			Assert.AreEqual(1, createLabelsResponse.Labels.Count);
			Assert.AreEqual(LabelStatus.Pending, createLabelsResponse.Labels[0].Status);
			Assert.AreEqual(0, createLabelsResponse.Errors.Count);
			Assert.AreEqual(0, createLabelsResponse.Warnings.Count);
		}

		[TestMethod]
		public async Task CreateLabelsWithError()
		{
			AusPost.Testing = true;

			string accountNumber = ConfigurationManager.AppSettings["AusPostAccountNumber"];
			string username = ConfigurationManager.AppSettings["AusPostUsername"];
			string password = ConfigurationManager.AppSettings["AusPostPassword"];

			var createShipmentsRequest = CreateCreateShipmentsRequest();

			CreateShipmentsResponse createShipmentsResponse = await AusPost.CreateShipmentsAsync(accountNumber, username, password, createShipmentsRequest);

			Assert.AreEqual(true, createShipmentsResponse.Succeeded);
			Assert.AreEqual(1, createShipmentsResponse.Shipments.Count);
			Assert.AreEqual(1, createShipmentsResponse.Shipments[0].Items.Count);

			var createLabelsRequest = CreateCreateLabelsRequest(createShipmentsResponse.Shipments[0].ShipmentID);

			// Make a shipment ID incorrect
			createLabelsRequest.Shipments[0].ShipmentID = "Incorrect";

			CreateLabelsResponse createLabelsResponse = await AusPost.CreateLabelsAsync(accountNumber, username, password, createLabelsRequest);

			Assert.AreEqual(false, createLabelsResponse.Succeeded);
			Assert.AreEqual(0, createLabelsResponse.Labels.Count);
			Assert.AreEqual(1, createLabelsResponse.Errors.Count);
			Assert.AreEqual(0, createLabelsResponse.Warnings.Count);
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

		private CreateLabelsRequest CreateCreateLabelsRequest(string shipmentID)
		{
			var preferences = new List<LabelPreference>();
			preferences.Add(new LabelPreference());
			preferences[0].Groups.Add(new LabelAttributes()
			{
				Group = LabelGroup.ParcelPost,
				Layout = LabelLayout.A4_4pp,
				Branded = true,
				LeftOffset = 0,
				TopOffset = 0
			});
			preferences[0].Groups.Add(new LabelAttributes()
			{
				Group = LabelGroup.ExpressPost,
				Layout = LabelLayout.A4_1pp,
				Branded = false,
				LeftOffset = 0,
				TopOffset = 0
			});

			var shipments = new List<ShipmentReference>();
			shipments.Add(new ShipmentReference(shipmentID));

			return new CreateLabelsRequest(preferences, shipments);
		}
	}
}
