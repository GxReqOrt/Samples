using Artech.Architecture.Common.Objects;
using Artech.Architecture.UI.Framework.Services;
using Artech.Genexus.Common.Objects;
using Artech.Genexus.Common.Parts.SDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmandoCardoso.Packages.Community
{
    public class SDTService : IKBObjectService
    {
        public KBObject BuildEmpty(string name)
        {
            IKBService kbserv = UIServices.KB;
            var kbmodel = kbserv.WorkingEnvironment.DesignModel;

            SDT sdt = new SDT(kbmodel)
            {
                Name = name
            };

            SDTLevel nivelSup = sdt.SDTStructure.Root;
            nivelSup.IsCollection = true;

            nivelSup.AddItem("CountryId", Artech.Genexus.Common.eDBType.NUMERIC, 4, 0);
            nivelSup.AddItem("CountryName", Artech.Genexus.Common.eDBType.VARCHAR, 30, 0);
         

            return sdt;
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
