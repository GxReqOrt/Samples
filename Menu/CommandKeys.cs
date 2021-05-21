using Artech.Common.Framework.Commands;

namespace Acme.Packages.Menu
{
	public class CommandKeys
	{
		private static CommandKey myFirstCommand = new CommandKey(MenuPackage.guid, "MyFirstCommand");
		private static CommandKey mySecondCommand = new CommandKey(MenuPackage.guid, "MySecondCommand");
		private static CommandKey yetAnotherCommand = new CommandKey(MenuPackage.guid, "YetAnotherCommand");
		private static CommandKey whyNotAnotherCommand = new CommandKey(MenuPackage.guid, "WhyNotAnotherCommand");

		public static CommandKey MyFirstCommand { get { return myFirstCommand; } }
		public static CommandKey MySecondCommand { get { return mySecondCommand; } }
		public static CommandKey YetAnotherCommand { get { return yetAnotherCommand; } }
		public static CommandKey WhyNotAnotherCommand { get { return whyNotAnotherCommand; } }
	}
}
