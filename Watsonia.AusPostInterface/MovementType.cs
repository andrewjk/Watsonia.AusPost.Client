using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	public enum MovementType
	{
		[JsonEnumName("DESPATCH")]
		Despatch,
		[JsonEnumName("RETURN")]
		Return
	}
}
