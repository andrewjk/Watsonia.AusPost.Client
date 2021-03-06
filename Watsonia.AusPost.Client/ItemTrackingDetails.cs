﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	/// <summary>
	/// The unique identifiers for the item. If these values have not been provided when creating the order or labels, then they will have been generated by Australia Post. 
	/// </summary>
	/// <seealso cref="Watsonia.AusPost.Client.ApiItem" />
	public sealed class ItemTrackingDetails : ApiItem
	{
		/// <summary>
		/// The consignment ID assigned to the item.
		/// </summary>
		/// <value>
		/// The consignment identifier.
		/// </value>
		[StringLength(100)]
		public string ConsignmentID { get; set; }

		/// <summary>
		/// The article ID assigned to the item.
		/// </summary>
		/// <value>
		/// The article identifier.
		/// </value>
		[StringLength(100)]
		public string ArticleID { get; set; }

		/// <summary>
		/// The barcode ID assigned to the item.
		/// </summary>
		/// <value>
		/// The barcode identifier.
		/// </value>
		public string BarcodeID { get; set; }

		/// <summary>
		/// Loads a ItemTrackingDetails from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static ItemTrackingDetails FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<ItemTrackingDetails>(json);
		}
	}
}
