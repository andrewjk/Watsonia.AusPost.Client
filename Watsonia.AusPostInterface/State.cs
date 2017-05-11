using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	public enum State
	{
		None,
		ACT,
		NSW,
		NT,
		[JsonEnumName("QLD")]
		Queensland,
		SA,
		[JsonEnumName("TAS")]
		Tasmania,
		[JsonEnumName("VIC")]
		Victoria,
		WA
	}
}
