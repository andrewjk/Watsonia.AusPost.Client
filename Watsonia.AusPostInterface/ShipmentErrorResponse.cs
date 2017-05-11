using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	/// <summary>
	/// The error code and description related to the action attempted.
	/// </summary>
	public sealed class ShipmentErrorResponse : ApiItem
	{
		/// <summary>
		/// The code associated with the error.
		/// </summary>
		/// <value>
		/// The code.
		/// </value>
		public string Code { get; set; }

		/// <summary>
		/// The name category for the error.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// The human readable error message.
		/// </summary>
		/// <value>
		/// The message.
		/// </value>
		public string Message { get; set; }
		
		/// <summary>
		/// A map of values that attempts to highlight important information that may have caused the error. This may or may not be populated depending on the type of error. 
		/// </summary>
		/// <value>
		/// The context.
		/// </value>
		public Dictionary<string, string> Context { get; set; } = new Dictionary<string, string>();
	}
}
