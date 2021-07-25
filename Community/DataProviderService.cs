using Artech.Architecture.Common.Objects;
using Artech.Architecture.UI.Framework.Services;
using Artech.Genexus.Common;
using Artech.Genexus.Common.Objects;

namespace ArmandoCardoso.Packages.Community
{
    public class DataProviderService : IKBObjectService
    {
        public KBObject BuildEmpty(string name)
        {
            IKBService kbserv = UIServices.KB;
            KBModel kbmodel = kbserv.WorkingEnvironment.DesignModel;

            DataProvider dp = new DataProvider(kbmodel)
            {
                Name = name
            };

            dp.SetPropertyValue(Properties.DPRV.CollectionName, "Countries");

            return dp;
        }

        public void Save(KBObject obj)
        {
            obj.Save();
        }

        public void Save(KBObject obj, KBObjectSavePreferences preferences)
        {
            obj.Save(preferences);
        }
    }
}
