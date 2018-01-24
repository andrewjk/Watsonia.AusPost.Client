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
	public class DownloadLabelsTests
	{
		[TestMethod]
		public async Task DownloadLabels()
		{
			AusPost.Testing = true;

			// Delete files from previous runs
			string folder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Labels";
			if (!System.IO.Directory.Exists(folder))
			{
				System.IO.Directory.CreateDirectory(folder);
			}
			foreach (string file in System.IO.Directory.GetFiles(folder))
			{
				System.IO.File.Delete(file);
			}

			string accountNumber = ConfigurationManager.AppSettings["AusPostAccountNumber"];
			string username = ConfigurationManager.AppSettings["AusPostUsername"];
			string password = ConfigurationManager.AppSettings["AusPostPassword"];

			var createShipmentsRequest = CreateCreateShipmentsRequest();

			CreateShipmentsResponse createShipmentsResponse = await AusPost.CreateShipmentsAsync(accountNumber, username, password, createShipmentsRequest);

			Assert.AreEqual(true, createShipmentsResponse.Succeeded);
			Assert.AreEqual(1, createShipmentsResponse.Shipments.Count);
			Assert.AreEqual(1, createShipmentsResponse.Shipments[0].Items.Count);

			var updateRequest = CreateCreateLabelsRequest(createShipmentsResponse.Shipments[0].ShipmentID);

			CreateLabelsResponse updateResponse = await AusPost.CreateLabelsAsync(accountNumber, username, password, updateRequest);

			Assert.AreEqual(true, updateResponse.Succeeded);
			Assert.AreEqual(1, updateResponse.Labels.Count);
			Assert.AreEqual(LabelStatus.Pending, updateResponse.Labels[0].Status);
			Assert.AreEqual(0, createShipmentsResponse.Errors.Count);
			Assert.AreEqual(0, createShipmentsResponse.Warnings.Count);

			// HACK: Wait for the labels to be generated...
			System.Threading.Thread.Sleep(5000);

			var getShipmentsRequest = CreateGetShipmentsRequest(createShipmentsResponse);

			GetShipmentsResponse getShipmentsResponse = await AusPost.GetShipmentsAsync(accountNumber, username, password, getShipmentsRequest);

			Assert.AreEqual(true, getShipmentsResponse.Succeeded);
			Assert.AreEqual(1, getShipmentsResponse.Shipments.Count);
			Assert.IsTrue(!string.IsNullOrEmpty(getShipmentsResponse.Shipments[0].Items[0].Label.LabelUrl));
			Assert.AreEqual(0, getShipmentsResponse.Errors.Count);
			Assert.AreEqual(0, getShipmentsResponse.Warnings.Count);

			// Download the PDF
			string pdfFile = folder + "\\labels.pdf";
			Assert.IsFalse(System.IO.File.Exists(pdfFile));
			DownloadLabelsResponse downloadResponse = await AusPost.DownloadLabelsAsync(getShipmentsResponse.Shipments[0].Items[0].Label.LabelUrl);
			Assert.AreEqual(true, downloadResponse.Succeeded);

			downloadResponse.SaveToFile(pdfFile);
			Assert.IsTrue(System.IO.File.Exists(pdfFile));
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

		private GetShipmentsRequest CreateGetShipmentsRequest(CreateShipmentsResponse createShipmentsResponse)
		{
			var shipmentIDs = createShipmentsResponse.Shipments.Select(s => s.ShipmentID).ToArray();
			return new GetShipmentsRequest(shipmentIDs);
		}
	}
}
