using Artech.Architecture.Common.Objects;
using Artech.Architecture.UI.Framework.Services;
using Artech.Genexus.Common;
using Artech.Genexus.Common.Objects;
using Artech.Genexus.Common.Parts;
using Artech.Udm.Framework;
using System;

namespace ArmandoCardoso.Packages.Community
{
    public class TransactionService : IKBObjectService
    {
        public TransactionService() { }
      
        public KBObject BuildEmpty(string name)
        {
            var kbService = UIServices.KB;
            KBModel model = kbService.WorkingEnvironment.DesignModel;
            var transaction = Transaction.Create(model);

            var structure = transaction.Structure.Root;
            var attribute = new Artech.Genexus.Common.Objects.Attribute(model)
            {
                Name = $"{name}Id",
                Type = eDBType.CHARACTER,
                Length = 30,
                Decimals = 0,

            };
            structure.AddAttribute(new TransactionAttribute(new StructurePart(transaction), attribute) {
                IsKey = true
            });

            transaction.Name = name;

            return transaction;
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
