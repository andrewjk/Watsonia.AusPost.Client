using System;
using System.Collections.Generic;
using System.Text;

namespace Watsonia.AusPost.Client.Tests
{
	// HACK: How are you supposed to have config settings in .NET Core now?
	internal static class AppConfiguration
	{
		public static string AusPostAccountNumber { get; }
		public static string AusPostUsername { get; }
		public static string AusPostPassword { get; }

		static AppConfiguration()
		{
			string fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\App.secret.config";
			string[] settings = System.IO.File.ReadAllLines(fileName);
			AusPostAccountNumber = settings[0];
			AusPostUsername = settings[1];
			AusPostPassword = settings[2];
		}
	}
}
