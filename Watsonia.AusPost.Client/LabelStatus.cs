using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
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
		[DataMember(Name = "PENDING")]
		Pending,
		/// <summary>
		/// Label generation failed.
		/// </summary>
		[DataMember(Name = "ERROR")]
		Error,
		/// <summary>
		/// Label generation has completed.
		/// </summary>
		[DataMember(Name = "AVAILABLE")]
		Available,
		/// <summary>
		/// The labels have expired.
		/// </summary>
		[DataMember(Name = "EXPIRED")]
		Expired
	}
}
