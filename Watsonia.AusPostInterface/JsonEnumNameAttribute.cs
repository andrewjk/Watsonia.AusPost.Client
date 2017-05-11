using System;

namespace Watsonia.AusPostInterface
{
	internal class JsonEnumNameAttribute : Attribute
	{
		public string Name { get; set; }

		public JsonEnumNameAttribute(string name)
		{
			this.Name = name;
		}
	}
}