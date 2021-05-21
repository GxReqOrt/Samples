using Artech.Architecture.UI.Framework.Helper;
using Artech.Common.Framework.Commands;
using System.Windows.Forms;

namespace Acme.Packages.Menu
{
	class CommandManager : CommandDelegator
	{
		// We handle only two commands here, just for illustration purposes
		public CommandManager()
		{
			// The first command has both an exec and a query (status) handler
			AddCommand(CommandKeys.MyFirstCommand, new ExecHandler(ExecMyFirstCommand), new QueryHandler(QueryMyFirstCommand));

			// Commands with exec handler and without a query handler are enabled by default
			AddCommand(CommandKeys.MySecondCommand, new ExecHandler(ExecMySecondCommand));
		}

		// This is where you implement whatever you want to do
		// when this command is invoked
		public bool ExecMyFirstCommand(CommandData commandData)
		{
			// Do something in response to the command invocation
			MessageBox.Show("Wow! My first command was invoked and handled!");

			// return true to indicate you already handled the command;
			// otherwise the framework will try with its next registered
			// command target
			return true;
		}

		// This is where you implement whatever you want to do
		// when this command is invoked
		public bool ExecMySecondCommand(CommandData commandData)
		{
			// Do something in response to the command invocation
			MessageBox.Show("Wow! My second command was invoked and handled!");

			// return true to indicate you already handled the command;
			// otherwise the framework will try with its next registered
			// command target
			return true;
		}

		private bool QueryMyFirstCommand(CommandData commandData, ref CommandStatus status)
		{
			// This is where you have a chance to modify the status of
			// menu / toolbar items.

			status.State = CommandState.Disabled;

			if (/* some actual condition */ true)
				status.State = CommandState.Enabled;

			// return true to indicate you already resolved the command status;
			// otherwise the framework will try with its next registered
			// command target
			return true;
		}
	}
}
