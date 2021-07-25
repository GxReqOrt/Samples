using Artech.Architecture.UI.Framework.Helper;
using Artech.Architecture.UI.Framework.Services;
using Artech.Common.Framework.Commands;

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

            AddCommand(CommandKeys.createdataprovidercommand, new ExecHandler(ExecCreateDataProviderCommand));

            AddCommand(CommandKeys.createsdtcommand, new ExecHandler(ExecCreateSDTCommand));

            AddCommand(CommandKeys.createtransactioncommand, new ExecHandler(ExecCreateTransactionCommand));
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

        public bool ExecCreateSDTCommand(CommandData commandData)
        {
            IKBObjectService service = new SDTService();

            var sdt = service.BuildEmpty("sdt_Countries");

            service.Save(sdt);

            return true;
        }

        public bool ExecCreateDataProviderCommand(CommandData commandData)
        {
            IKBObjectService service = new DataProviderService();

            var dataProvider = service.BuildEmpty("DPRV_Countries");

            service.Save(dataProvider);

            return true;
        }

        public bool ExecCreateTransactionCommand(CommandData commandData)
        {
            IKBObjectService service = new TransactionService();

            var transaction = service.BuildEmpty("User");

            service.Save(transaction);

            return true;
        }
    }
}
