using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	/// <summary>
	/// The type of address.
	/// </summary>
	public enum RecipientType
	{
		/// <summary>
		/// Not set.
		/// </summary>
		[DataMember(Name = "NONE")]
		None,
		/// <summary>
		/// An Australia Post Parcel Locker.
		/// </summary>
		[DataMember(Name = "PARCEL_LOCKER")]
		ParcelLocker,
		/// <summary>
		/// An Australia Post Parcel Collection location.
		/// </summary>
		[DataMember(Name = "PARCEL_COLLECT")]
		ParcelCollect,
		/// <summary>
		/// A normal delivery address.
		/// </summary>
		[DataMember(Name = "STANDARD_ADDRESS")]
		StandardAddress
	}
}
