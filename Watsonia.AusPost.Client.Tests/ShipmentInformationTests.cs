using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Watsonia.AusPost.Client.Tests
{
	[TestClass]
	public class ShipmentInformationTests
	{
		[TestMethod]
		public void ShipmentInformationFromJson()
		{
			var json = @"
{
  ""shipment_id"": ""9lesEAOvOm4AAAFI3swaDRYB"",
  ""shipment_reference"": ""XYZ-001-01"",
  ""shipment_creation_date"": ""2014-08-27T15:48:09+10:00"",
  ""customer_reference_1"": ""Order 001"",
  ""customer_reference_2"": ""SKU-1, SKU-2, SKU-3"",
  ""sender_references"": [
    ""Order 001"",
    ""SKU-1, SKU-2, SKU-3""
  ],
  ""email_tracking_enabled"": true,
  ""items"": [
    {
      ""item_id"": ""LDCsEAOvU_oAAAFI6MwaDRYB"",
      ""item_reference"": ""SKU-1"",
      ""tracking_details"": {
        ""article_id"": ""ABC000128B4C5"",
        ""consignment_id"": ""ABC000128""
      },
      ""product_id"": ""7E55"",
      ""item_summary"": {
        ""total_cost"": 5,
        ""total_gst"": 0.45,
        ""status"": ""Created""
      }
    },
    {
      ""item_id"": ""ynesEAOvnlAAAAFI88waDRYB"",
      ""item_reference"": ""SKU-3"",
      ""tracking_details"": {
        ""article_id"": ""ABC000128B4C6"",
        ""consignment_id"": ""ABC000128""
      },
      ""product_id"": ""7E55"",
      ""item_summary"": {
        ""total_cost"": 4,
        ""total_gst"": 0.36,
        ""status"": ""Created""
      }
    },
    {
      ""item_id"": ""TkGsEAOv9.4AAAFI8MwaDRYB"",
      ""item_reference"": ""SKU-2"",
      ""tracking_details"": {
        ""article_id"": ""ABC000128B4C7"",
        ""consignment_id"": ""ABC000128""
      },
      ""product_id"": ""7E55"",
      ""item_summary"": {
        ""total_cost"": 4,
        ""total_gst"": 0.36,
        ""status"": ""Created""
      }
    }
  ],
  ""shipment_summary"": {
      ""total_cost"": 13,
      ""total_gst"": 1.18,
      ""status"": ""Created"",
      ""number_of_items"": 3,
      ""tracking_summary"": {
        ""Initiated"": 3
      },
  }
}".Trim();
			
			var serializer = new ApiSerializer();
			var item = serializer.FromJson<ShipmentInformation>(json);

			Assert.AreEqual("9lesEAOvOm4AAAFI3swaDRYB", item.ShipmentID);
			Assert.AreEqual("XYZ-001-01", item.ShipmentReference);
			Assert.AreEqual(new DateTime(2014, 8, 27, 15, 48, 9), item.ShipmentCreationDate);
			// TODO: Are these part of the spec?
			//Assert.AreEqual("Order 001", item.CustomerReference1);
			//Assert.AreEqual("SKU-1, SKU-2, SKU-3", item.CustomerReference2);
			//Assert.AreEqual(2, item.SenderReferences.Count);
			//Assert.AreEqual("Order 001", item.SenderReferences[0]);
			//Assert.AreEqual("SKU-1, SKU-2, SKU-3", item.SenderReferences[1]);
			Assert.AreEqual(true, item.EmailTrackingEnabled);

			Assert.AreEqual(3, item.Items.Count);

			Assert.AreEqual("LDCsEAOvU_oAAAFI6MwaDRYB", item.Items[0].ItemID);
			Assert.AreEqual("SKU-1", item.Items[0].ItemReference);
			Assert.IsNotNull(item.Items[0].TrackingDetails);
			Assert.AreEqual("ABC000128B4C5", item.Items[0].TrackingDetails.ArticleID);
			Assert.AreEqual("ABC000128", item.Items[0].TrackingDetails.ConsignmentID);
			Assert.AreEqual("7E55", item.Items[0].ProductID);
			Assert.IsNotNull(item.Items[0].ItemSummary);
			Assert.AreEqual(5, item.Items[0].ItemSummary.TotalCost);
			Assert.AreEqual(0.45m, item.Items[0].ItemSummary.TotalGst);
			Assert.AreEqual("Created", item.Items[0].ItemSummary.Status);

			Assert.AreEqual("ynesEAOvnlAAAAFI88waDRYB", item.Items[1].ItemID);
			Assert.AreEqual("SKU-3", item.Items[1].ItemReference);
			Assert.IsNotNull(item.Items[1].TrackingDetails);
			Assert.AreEqual("ABC000128B4C6", item.Items[1].TrackingDetails.ArticleID);
			Assert.AreEqual("ABC000128", item.Items[1].TrackingDetails.ConsignmentID);
			Assert.AreEqual("7E55", item.Items[1].ProductID);
			Assert.IsNotNull(item.Items[1].ItemSummary);
			Assert.AreEqual(4, item.Items[1].ItemSummary.TotalCost);
			Assert.AreEqual(0.36m, item.Items[1].ItemSummary.TotalGst);
			Assert.AreEqual("Created", item.Items[1].ItemSummary.Status);

			Assert.AreEqual("TkGsEAOv9.4AAAFI8MwaDRYB", item.Items[2].ItemID);
			Assert.AreEqual("SKU-2", item.Items[2].ItemReference);
			Assert.IsNotNull(item.Items[2].TrackingDetails);
			Assert.AreEqual("ABC000128B4C7", item.Items[2].TrackingDetails.ArticleID);
			Assert.AreEqual("ABC000128", item.Items[2].TrackingDetails.ConsignmentID);
			Assert.AreEqual("7E55", item.Items[2].ProductID);
			Assert.IsNotNull(item.Items[2].ItemSummary);
			Assert.AreEqual(4, item.Items[2].ItemSummary.TotalCost);
			Assert.AreEqual(0.36m, item.Items[2].ItemSummary.TotalGst);
			Assert.AreEqual("Created", item.Items[2].ItemSummary.Status);

			Assert.IsNotNull(item.ShipmentSummary);
			Assert.AreEqual(13, item.ShipmentSummary.TotalCost);
			Assert.AreEqual(1.18m, item.ShipmentSummary.TotalGst);
			Assert.AreEqual("Created", item.ShipmentSummary.Status);
			Assert.AreEqual(3, item.ShipmentSummary.NumberOfItems);
			Assert.AreEqual(1, item.ShipmentSummary.TrackingSummary.Count);
			Assert.AreEqual(3, item.ShipmentSummary.TrackingSummary["Initiated"]);
		}
	}
}
