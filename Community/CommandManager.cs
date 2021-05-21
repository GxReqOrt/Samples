using Artech.Architecture.UI.Framework.Helper;
using Artech.Common.Framework.Commands;
using System.Windows.Forms;
using Artech.Architecture.UI.Framework.Services;
using Artech.Architecture.Common.Services;

namespace ArmandoCardoso.Packages.Community
{
    class CommandManager : CommandDelegator
    {
        // We handle only two commands here, just for illustration purposes
        public CommandManager()
        {
            // The first command has both an exec and a query (status) handler
            AddCommand(CommandKeys.gxsearchcommand, new ExecHandler(ExecGXsearchCommand));

            // Commands with exec handler and without a query handler are enabled by default
            AddCommand(CommandKeys.communitywikicommand, new ExecHandler(ExecCommunityWikiCommand));

            // Commands with exec handler and without a query handler are enabled by default
            AddCommand(CommandKeys.gxopencommand, new ExecHandler(ExecGXopenCommand));

            // Commands with exec handler and without a query handler are enabled by default
            AddCommand(CommandKeys.forumscommand, new ExecHandler(ExecForumsCommand));

            // Commands with exec handler and without a query handler are enabled by default
            AddCommand(CommandKeys.allcommunityresourcescommand, new ExecHandler(ExecAllCommunityResourcesCommand));
        }

        // This is where you implement whatever you want to do
        // when this command is invoked
        public bool ExecGXsearchCommand(CommandData commandData)
        {
            // Do something in response to the command invocation
            UIServices.StartPage.OpenPage("www.gxtechnical.com/gxsearch", "GXSearch");
            UIServices.ToolWindows.FocusToolWindow(UIServices.StartPage.ToolWindow.Id);

            // return true to indicate you already handled the command;
            // otherwise the framework will try with its next registered
            // command target
            return true;
        }

        // This is where you implement whatever you want to do
        // when this command is invoked
        public bool ExecCommunityWikiCommand(CommandData commandData)
        {
            // Do something in response to the command invocation
            UIServices.StartPage.OpenPage("www.gxtechnical.com/wiki", "GeneXus Community Wiki");
            UIServices.ToolWindows.FocusToolWindow(UIServices.StartPage.ToolWindow.Id);

            // return true to indicate you already handled the command;
            // otherwise the framework will try with its next registered
            // command target
            return true;
        }

        // This is where you implement whatever you want to do
        // when this command is invoked
        public bool ExecGXopenCommand(CommandData commandData)
        {
            // Do something in response to the command invocation
            UIServices.StartPage.OpenPage("www.gxopen.com", "GXOpen");
            UIServices.ToolWindows.FocusToolWindow(UIServices.StartPage.ToolWindow.Id);

            // return true to indicate you already handled the command;
            // otherwise the framework will try with its next registered
            // command target
            return true;
        }

        public bool ExecForumsCommand(CommandData commandData)
        {
            // Do something in response to the command invocation
            UIServices.StartPage.OpenPage("www.gxopen.com/forumsr/servlet/hsrmain", "GeneXus Forums");
            UIServices.ToolWindows.FocusToolWindow(UIServices.StartPage.ToolWindow.Id);
        
            // return true to indicate you already handled the command;
            // otherwise the framework will try with its next registered
            // command target
            return true;
        }

        public bool ExecAllCommunityResourcesCommand(CommandData commandData)
        {
            // Do something in response to the command invocation
            // UIServices.StartPage.OpenPage("www.gxtechnical.com/community", "Community Resources");
            // UIServices.ToolWindows.FocusToolWindow(UIServices.StartPage.ToolWindow.Id);
            IOutputService output = CommonServices.Output;
            output.Clear();
            output.StartSection("My section");
            output.AddLine("Sending a message to output window");
            output.EndSection("My section", true);

            // return true to indicate you already handled the command;
            // otherwise the framework will try with its next registered
            // command target
            return true;
        }
    }
}
