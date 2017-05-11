using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watsonia.AusPostInterface
{
	public sealed class ItemLabel : ApiItem
	{
		public string LabelUrl { get; set; }

		public LabelStatus Status { get; set; }

		public string[] Errors { get; set; }

		public string LabelCreationDate { get; set; }
	}
}
