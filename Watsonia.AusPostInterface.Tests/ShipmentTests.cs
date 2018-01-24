using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Watsonia.AusPostInterface.Tests
{
	[TestClass]
	public class ShipmentTests
	{
		[TestMethod]
		public void ShipmentToJson()
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
			item1.Width = 10;
			item1.Height = 10;
			item1.Weight = 1;
			item1.AuthorityToLeave = false;
			item1.AllowPartialDelivery = true;
			item1.Features.Add("TRANSIT_COVER", new ItemFeature());
			item1.Features["TRANSIT_COVER"].Attributes.CoverAmount = 1000;
			shipment.Items.Add(item1);

			var item2 = new Item();
			item2.ItemReference = "SKU-2";
			item2.ProductID = "T28S";
			item2.Length = 10;
			item2.Width = 10;
			item2.Height = 10;
			item2.Weight = 1;
			item2.AuthorityToLeave = false;
			item2.AllowPartialDelivery = true;
			shipment.Items.Add(item2);

			var item3 = new Item();
			item3.ItemReference = "SKU-3";
			item3.ProductID = "T28S";
			item3.Length = 10;
			item3.Width = 10;
			item3.Height = 10;
			item3.Weight = 1;
			item3.AuthorityToLeave = false;
			item3.AllowPartialDelivery = true;
			shipment.Items.Add(item3);

			string expected = @"
{
  ""shipment_reference"": ""XYZ-001-01"",
  ""customer_reference_1"": ""Order 001"",
  ""customer_reference_2"": ""SKU-1, SKU-2, SKU-3"",
  ""email_tracking_enabled"": true,
  ""from"": {
    ""name"": ""John Citizen"",
    ""lines"": [
      ""1 Main Street""
    ],
    ""suburb"": ""MELBOURNE"",
    ""state"": ""VIC"",
    ""postcode"": ""3000"",
    ""phone"": ""0401234567"",
    ""email"": ""john.citizen@citizen.com""
  },
  ""to"": {
    ""name"": ""Jane Smith"",
    ""business_name"": ""Smith Pty Ltd"",
    ""lines"": [
      ""123 Centre Road""
    ],
    ""suburb"": ""Sydney"",
    ""state"": ""NSW"",
    ""postcode"": ""2000"",
    ""phone"": ""0412345678"",
    ""email"": ""jane.smith@smith.com""
  },
  ""items"": [
    {
      ""item_reference"": ""SKU-1"",
      ""product_id"": ""T28S"",
      ""length"": 10.0,
      ""width"": 10.0,
      ""height"": 10.0,
      ""weight"": 1.0,
      ""authority_to_leave"": false,
      ""allow_partial_delivery"": true,
      ""features"": {
        ""TRANSIT_COVER"": {
          ""attributes"": {
            ""cover_amount"": 1000.0
          }
        }
      }
    },
    {
      ""item_reference"": ""SKU-2"",
      ""product_id"": ""T28S"",
      ""length"": 10.0,
      ""width"": 10.0,
      ""height"": 10.0,
      ""weight"": 1.0,
      ""authority_to_leave"": false,
      ""allow_partial_delivery"": true
    },
    {
      ""item_reference"": ""SKU-3"",
      ""product_id"": ""T28S"",
      ""length"": 10.0,
      ""width"": 10.0,
      ""height"": 10.0,
      ""weight"": 1.0,
      ""authority_to_leave"": false,
      ""allow_partial_delivery"": true
    }
  ]
}".Trim();
			Assert.AreEqual(expected, shipment.ToJson());
		}
	}
}
