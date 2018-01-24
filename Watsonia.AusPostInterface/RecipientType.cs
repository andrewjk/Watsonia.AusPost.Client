using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// The type of address.
	/// </summary>
	public enum RecipientType
	{
		/// <summary>
		/// Not set.
		/// </summary>
		[JsonEnumName("NONE")]
		None,
		/// <summary>
		/// An Australia Post Parcel Locker.
		/// </summary>
		[JsonEnumName("PARCEL_LOCKER")]
		ParcelLocker,
		/// <summary>
		/// An Australia Post Parcel Collection location.
		/// </summary>
		[JsonEnumName("PARCEL_COLLECT")]
		ParcelCollect,
		/// <summary>
		/// A normal delivery address.
		/// </summary>
		[JsonEnumName("STANDARD_ADDRESS")]
		StandardAddress
	}
}
