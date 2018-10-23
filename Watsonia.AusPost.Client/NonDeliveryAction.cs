using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public enum NonDeliveryAction
	{
		[DataMember(Name = "RETURN")]
		Return,
		[DataMember(Name = "ABANDONED")]
		Abandoned
	}
}
