﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// Label information for each label created.
	/// </summary>
	/// <seealso cref="Watsonia.AusPostInterface.ApiItem" />
	public sealed class LabelInformation : ApiItem
	{
		/// <summary>
		/// The identifier for the request, generated and returned by the Create Labels service.
		/// </summary>
		/// <value>
		/// The request identifier.
		/// </value>
		public string RequestID { get; set; }

		/// <summary>
		/// The status of the label generation request.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		public LabelStatus Status { get; set; }

		/// <summary>
		/// The date and time that the request for this label creation was received by the system.
		/// </summary>
		/// <value>
		/// The request date.
		/// </value>
		public string RequestDate { get; set; }

		/// <summary>
		/// The list of Shipment IDs included in this request.
		/// </summary>
		/// <value>
		/// The shipments.
		/// </value>
		public List<string> Shipments { get; set; } = new List<string>();
	}
}
