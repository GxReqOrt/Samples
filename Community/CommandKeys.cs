using Artech.Common.Framework.Commands;

namespace ArmandoCardoso.Packages.Community
{
    public class CommandKeys
    {
        private static CommandKey GXsearchCommand = new CommandKey(CommunityPackage.guid, "GXSearch");
        private static CommandKey CommunityWikiCommand = new CommandKey(CommunityPackage.guid, "Community Wiki");
        private static CommandKey GXopenCommand = new CommandKey(CommunityPackage.guid, "GXOpen");
        private static CommandKey ForumsCommand = new CommandKey(CommunityPackage.guid, "GeneXus Forums");
        private static CommandKey AllCommunityResourcesCommand = new CommandKey(CommunityPackage.guid, "All Community Resources");
        private static CommandKey ContosoCommand = new CommandKey(CommunityPackage.guid, "Contoso");

        public static CommandKey gxsearchcommand { get { return GXsearchCommand; } }
        public static CommandKey communitywikicommand { get { return CommunityWikiCommand; } }
        public static CommandKey gxopencommand { get { return GXopenCommand; } }
        public static CommandKey forumscommand { get { return ForumsCommand; } }
        public static CommandKey allcommunityresourcescommand { get { return AllCommunityResourcesCommand; } }
        public static CommandKey contosocommand { get { return ContosoCommand; } }
    }
}
