using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Watsonia.AusPost.Client.Tests
{
	[TestClass]
	public class SenderTests
	{
		[TestMethod]
		public void SenderToJson()
		{
			var item = new Sender();
			item.Name = "John Citizen";
			item.Lines = new string[] { "1 Main Street" };
			item.Suburb = "MELBOURNE";
			item.State = State.Victoria;
			item.Postcode = "3000";
			item.Phone = "0401234567";
			item.Email = "john.citizen@citizen.com";

			var expected = @"
{
  ""name"": ""John Citizen"",
  ""lines"": [
    ""1 Main Street""
  ],
  ""suburb"": ""MELBOURNE"",
  ""state"": ""VIC"",
  ""postcode"": ""3000"",
  ""phone"": ""0401234567"",
  ""email"": ""john.citizen@citizen.com""
}".Trim();

			var serializer = new ApiSerializer();
			var result = serializer.ToJson(item);
			Assert.AreEqual(expected, result);
		}
	}
}
