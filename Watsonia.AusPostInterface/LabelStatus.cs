using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// The status of the label generation request.
	/// </summary>
	public enum LabelStatus
	{
		/// <summary>
		/// Labels haven't been generated.
		/// </summary>
		None,
		/// <summary>
		/// Labels are being generated.
		/// </summary>
		[JsonEnumName("PENDING")]
		Pending,
		/// <summary>
		/// Label generation failed.
		/// </summary>
		[JsonEnumName("ERROR")]
		Error,
		/// <summary>
		/// Label generation has completed.
		/// </summary>
		[JsonEnumName("AVAILABLE")]
		Available
	}
}
