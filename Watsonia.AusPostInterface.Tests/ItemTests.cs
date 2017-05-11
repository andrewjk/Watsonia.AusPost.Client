using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Watsonia.AusPostInterface.Tests
{
	[TestClass]
	public class ItemTests
	{
		[TestMethod]
		public void ItemToJson()
		{
			var item = new Item();
			item.ItemReference = "SKU-1";
			item.ProductID = "T28S";
			item.Length = 10;
			item.Width = 10;
			item.Height = 10;
			item.Weight = 1;
			item.AuthorityToLeave = false;
			item.AllowPartialDelivery = true;
			item.Features.Add("TRANSIT_COVER", new ItemFeature());
			item.Features["TRANSIT_COVER"].Attributes.CoverAmount = 1000;

			var expected = @"
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
}".Trim();

			Assert.AreEqual(expected, item.ToJson());
		}
	}
}
