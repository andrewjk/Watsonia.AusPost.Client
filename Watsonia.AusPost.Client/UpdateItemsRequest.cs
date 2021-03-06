﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public sealed class UpdateItemsRequest : ApiItem
	{
		/// <summary>
		/// An item element to be supplied for each parcel.
		/// </summary>
		/// <value>
		/// The shipments.
		/// </value>
		public List<Item> Items { get; set; } = new List<Item>();

		/// <summary>
		/// Initializes a new instance of the <see cref="UpdateItemsRequest" /> class.
		/// </summary>
		/// <param name="items">The items.</param>
		public UpdateItemsRequest(params Item[] items)
		{
			this.Items.AddRange(items);
		}

		/// <summary>
		/// Loads a UpdateItemsRequest from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static UpdateItemsRequest FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<UpdateItemsRequest>(json);
		}
	}
}
