using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
		[DataMember(Name = "QLD")]
		Queensland,
		SA,
		[DataMember(Name = "TAS")]
		Tasmania,
		[DataMember(Name = "VIC")]
		Victoria,
		WA
	}
}
