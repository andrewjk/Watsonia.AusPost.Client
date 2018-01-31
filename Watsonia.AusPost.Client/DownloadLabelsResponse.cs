﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public sealed class DownloadLabelsResponse : ApiItem
	{
		/// <summary>
		/// Gets or sets a value indicating whether the request succeeded.
		/// </summary>
		/// <value>
		///   <c>true</c> if the request succeeded; otherwise, <c>false</c>.
		/// </value>
		public bool Succeeded { get; set; }

		/// <summary>
		/// Gets a value indicating whether any errors occurred during the request.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance has errors; otherwise, <c>false</c>.
		/// </value>
		public bool HasErrors
		{
			get
			{
				return this.Errors.Count > 0;
			}
		}

		/// <summary>
		/// Gets a value indicating whether any warnings occurred during the request.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance has warnings; otherwise, <c>false</c>.
		/// </value>
		public bool HasWarnings
		{
			get
			{
				return this.Warnings.Count > 0;
			}
		}

		/// <summary>
		/// Gets or sets any errors that occurred during the request.
		/// </summary>
		/// <value>
		/// The errors.
		/// </value>
		public List<ShipmentErrorResponse> Errors { get; set; } = new List<ShipmentErrorResponse>();

		/// <summary>
		/// Gets or sets any warnings that occurred during the request.
		/// </summary>
		/// <value>
		/// The errors.
		/// </value>
		public List<ShipmentErrorResponse> Warnings { get; set; } = new List<ShipmentErrorResponse>();

		/// <summary>
		/// Gets or sets the PDF stream.
		/// </summary>
		/// <value>
		/// The stream.
		/// </value>
		public System.IO.Stream Stream { get; set; }

		/// <summary>
		/// Saves the PDF stream to a file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		public void SaveToFile(string fileName)
		{
			using (var fileStream = System.IO.File.Create(fileName))
			{
				this.Stream.Seek(0, System.IO.SeekOrigin.Begin);
				this.Stream.CopyTo(fileStream);
			}
		}

		/// <summary>
		/// Loads a DownloadLabelsResponse from a JSON string.
		/// </summary>
		/// <param name="json">The json.</param>
		public static DownloadLabelsResponse FromJson(string json)
		{
			var serializer = new ApiSerializer();
			return serializer.FromJson<DownloadLabelsResponse>(json);
		}
	}
}
