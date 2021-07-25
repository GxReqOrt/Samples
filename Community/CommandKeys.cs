using Artech.Common.Framework.Commands;

namespace ArmandoCardoso.Packages.Community
{
    public class CommandKeys
    {
        private static CommandKey GXsearchCommand = new CommandKey(CommunityPackage.guid, "GXSearch");
        private static CommandKey CommunityWikiCommand = new CommandKey(CommunityPackage.guid, "Community Wiki");
        private static CommandKey GXopenCommand = new CommandKey(CommunityPackage.guid, "GXOpen");
        private static CommandKey CreateDataProviderCommand = new CommandKey(CommunityPackage.guid, "Create Data Provider");
        private static CommandKey CreateSDTCommand = new CommandKey(CommunityPackage.guid, "Create SDT");
        private static CommandKey CreateTransactionCommand = new CommandKey(CommunityPackage.guid, "Create Transaction");

        public static CommandKey gxsearchcommand { get { return GXsearchCommand; } }
        public static CommandKey communitywikicommand { get { return CommunityWikiCommand; } }
        public static CommandKey gxopencommand { get { return GXopenCommand; } }
        public static CommandKey createdataprovidercommand { get { return CreateDataProviderCommand; } }
        public static CommandKey createsdtcommand { get { return CreateSDTCommand; } }
        public static CommandKey createtransactioncommand { get { return CreateTransactionCommand; } }
    }
}
