using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Watsonia.AusPost.Client.Tests
{
	[TestClass]
	public class ItemTests
	{
		[TestMethod]
		public void ItemToJson()
		{
			var item = new Item();
			item.ItemReference = "SKU-1";
			item.ProductID = "7E55";
			item.Length = 10;
			item.Width = 10;
			item.Height = 10;
			item.Weight = 1;
			item.AuthorityToLeave = false;
			item.AllowPartialDelivery = true;
			item.Features.Add("TRANSIT_COVER", new ItemFeature());
			item.Features["TRANSIT_COVER"].Attributes.CoverAmount = 500;

			var expected = @"
{
  ""item_reference"": ""SKU-1"",
  ""product_id"": ""7E55"",
  ""length"": 10.0,
  ""width"": 10.0,
  ""height"": 10.0,
  ""weight"": 1.0,
  ""authority_to_leave"": false,
  ""allow_partial_delivery"": true,
  ""features"": {
    ""TRANSIT_COVER"": {
      ""attributes"": {
        ""cover_amount"": 500.0
      }
    }
  }
}".Trim();

			var serializer = new ApiSerializer();
			var result = serializer.ToJson(item);
			Assert.AreEqual(expected, result);
		}
	}
}
