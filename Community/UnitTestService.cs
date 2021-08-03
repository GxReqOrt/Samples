using Artech.Architecture.Common.Objects;
using Artech.Architecture.UI.Framework.Services;
using Artech.Genexus.Common.Objects;

namespace ArmandoCardoso.Packages.Community
{
    public class UnitTestService : IKBObjectService
    {
        public KBObject BuildEmpty(string name)
        {
            IKBService kbserv = UIServices.KB;
            KBModel kbmodel = kbserv.WorkingEnvironment.DesignModel;

            Procedure procedure = new Procedure(kbmodel)
            {
                Name = name
            };

            procedure.SetPropertyValue("IS_A_TEST", true);
            procedure.SetPropertyValue("IS_UNIT_TEST", true);

            return procedure;
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
