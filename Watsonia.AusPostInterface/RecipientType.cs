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
		None,
		/// <summary>
		/// An Australia Post Parcel Locker.
		/// </summary>
		ParcelLocker,
		/// <summary>
		/// An Australia Post Parcel Collection location.
		/// </summary>
		ParcelCollect,
		/// <summary>
		/// A normal delivery address.
		/// </summary>
		StandardAddress
	}
}
