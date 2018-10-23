using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPost.Client
{
	public enum ClassificationType
	{
		[DataMember(Name = "OTHER")]
		Other,
		[DataMember(Name = "GIFT")]
		Gift,
		[DataMember(Name = "SAMPLE")]
		Sample,
		[DataMember(Name = "DOCUMENT")]
		Document,
		[DataMember(Name = "RETURN")]
		Return,
		[DataMember(Name = "SALE_OF_GOODS")]
		SaleOfGoods
	}
}
