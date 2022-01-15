using Artech.Common.Helpers;
using System;

namespace GXextensions.ConsoleTool
{
    class CommandParser : CommandLineParser
	{
		[ValueUsage("Uri of Knowledge Base", Optional = false, AlternateName1 = "kb")]
		public string KB = "";

		public bool ParseArguments(string[] args)
		{
			try
			{
				Parse(args);
			}
			catch
			{
				Console.Error.WriteLine(GetUsage());
				return false;
			}
			return true;
		}
	}
}
