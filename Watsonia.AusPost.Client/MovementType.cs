using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public enum MovementType
	{
		[DataMember(Name = "DESPATCH")]
		Despatch,
		[DataMember(Name = "RETURN")]
		Return
	}
}
