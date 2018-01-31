﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// The layout specifies the number of labels per page and the size of the page. The layout must be valid for the product types of the items in the shipment.
	/// </summary>
	public enum LabelLayout
	{
		None,
		[DataMember(Name = "A4-1pp")]
		A4_1pp,
		[DataMember(Name = "A4-3pp")]
		A4_3pp,
		[DataMember(Name = "A4-4pp")]
		A4_4pp,
		[DataMember(Name = "A6-1pp")]
		A6_1pp,
		/// <summary>
		/// Only available with StarTrack products.
		/// </summary>
		[DataMember(Name = "A4-2pp")]
		A4_2pp,
		/// <summary>
		/// Only available with StarTrack products.
		/// </summary>
		[DataMember(Name = "A4-1pp landscape")]
		A4_1pp_Landscape,
		/// <summary>
		/// Only available with StarTrack products.
		/// </summary>
		[DataMember(Name = "A4-2pp landscape")]
		A4_2pp_Landscape
	}
}
