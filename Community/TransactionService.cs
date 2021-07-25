using Artech.Architecture.Common.Objects;
using Artech.Architecture.UI.Framework.Services;
using Artech.Genexus.Common.Objects;
using Artech.Genexus.Common.Parts;
using Artech.Udm.Framework;
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
            //transaction.SetPropertyValue("Key", new EntityKey(transaction.Guid, transaction.Id));
            var structure = transaction.Structure.Root;
            var attribute = new Attribute(model)
            {
                Name = $"{name}Id",
                Type = Artech.Genexus.Common.eDBType.CHARACTER,
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
