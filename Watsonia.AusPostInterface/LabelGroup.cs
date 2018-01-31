using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
		[DataMember(Name = "Parcel Post")]
		ParcelPost,
		[DataMember(Name = "Express Post")]
		ExpressPost,
		StarTrack
	}
}
