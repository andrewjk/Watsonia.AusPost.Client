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
	public class GetOrderSummaryTests
	{
		[TestMethod]
		public async Task GetOrderSummary()
		{
			AusPost.Testing = true;

			// Delete files from previous runs
			string folder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Summary";
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

			var createOrderRequest = CreateCreateOrderRequest();

			CreateOrderIncludingShipmentsResponse createOrderResponse = await AusPost.CreateOrderIncludingShipmentsAsync(accountNumber, username, password, createOrderRequest);

			Assert.AreEqual(true, createOrderResponse.Succeeded);
			Assert.AreEqual(true, !string.IsNullOrEmpty(createOrderResponse.Order.OrderID));
			Assert.AreEqual(0, createOrderResponse.Errors.Count);
			Assert.AreEqual(0, createOrderResponse.Warnings.Count);

			var getOrderSummaryRequest = new GetOrderSummaryRequest(createOrderResponse.Order.OrderID);

			GetOrderSummaryResponse getOrderSummaryResponse = await AusPost.GetOrderSummaryAsync(accountNumber, username, password, getOrderSummaryRequest);

			Assert.AreEqual(true, getOrderSummaryResponse.Succeeded);
			Assert.IsNotNull(getOrderSummaryResponse.Stream);
			Assert.AreEqual(0, getOrderSummaryResponse.Errors.Count);
			Assert.AreEqual(0, getOrderSummaryResponse.Warnings.Count);

			// Download the PDF
			string pdfFile = folder + "\\summary.pdf";
			Assert.IsFalse(System.IO.File.Exists(pdfFile));
			using (var fileStream = System.IO.File.Create(pdfFile))
			{
				getOrderSummaryResponse.Stream.Seek(0, System.IO.SeekOrigin.Begin);
				getOrderSummaryResponse.Stream.CopyTo(fileStream);
			}
			Assert.IsTrue(System.IO.File.Exists(pdfFile));
		}

		[TestMethod]
		public async Task GetOrderSummaryWithError()
		{
			AusPost.Testing = true;

			string accountNumber = ConfigurationManager.AppSettings["AusPostAccountNumber"];
			string username = ConfigurationManager.AppSettings["AusPostUsername"];
			string password = ConfigurationManager.AppSettings["AusPostPassword"];

			var getOrderSummaryRequest = new GetOrderSummaryRequest("Invalid");

			GetOrderSummaryResponse getOrderSummaryResponse = await AusPost.GetOrderSummaryAsync(accountNumber, username, password, getOrderSummaryRequest);

			Assert.AreEqual(false, getOrderSummaryResponse.Succeeded);
			Assert.AreEqual(null, getOrderSummaryResponse.Stream);
			Assert.AreEqual(1, getOrderSummaryResponse.Errors.Count);
			Assert.AreEqual(0, getOrderSummaryResponse.Warnings.Count);
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
			item1.ProductID = "T28S";
			item1.Length = 10;
			item1.Height = 10;
			item1.Width = 10;
			item1.Weight = 1;
			item1.AuthorityToLeave = false;
			item1.AllowPartialDelivery = true;
			item1.Features.Add("TRANSIT_COVER", new ItemFeature());
			item1.Features["TRANSIT_COVER"].Attributes.CoverAmount = 1000;
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
			item2.ProductID = "T28S";
			item2.Length = 10;
			item2.Height = 10;
			item2.Width = 10;
			item2.Weight = 1;
			item2.AuthorityToLeave = false;
			item2.AllowPartialDelivery = true;
			shipment2.Items.Add(item2);

			var item3 = new Item();
			item3.ItemReference = "SKU-3";
			item3.ProductID = "T28S";
			item3.Length = 10;
			item3.Height = 10;
			item3.Width = 10;
			item3.Weight = 1;
			item3.AuthorityToLeave = false;
			item3.AllowPartialDelivery = true;
			shipment2.Items.Add(item3);

			return new CreateOrderIncludingShipmentsRequest(shipment1, shipment2);
		}
	}
}
