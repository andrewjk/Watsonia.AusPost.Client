using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// The label group to apply the print preference. 
	/// </summary>
	public enum LabelGroup
	{
		None,
		[JsonEnumName("Parcel Post")]
		ParcelPost,
		[JsonEnumName("Express Post")]
		ExpressPost,
		StarTrack
	}
}
