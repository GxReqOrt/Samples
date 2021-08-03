using Artech.Architecture.Common.Objects;
using Artech.Architecture.UI.Framework.Services;
using Artech.Genexus.Common;
using Artech.Genexus.Common.Objects;
using Artech.Genexus.Common.Parts;

namespace ArmandoCardoso.Packages.Community
{
    public class TransactionService : IKBObjectService
    {
        public TransactionService() { }
      
        public KBObject BuildEmpty(string name)
        {
            KBModel model = UIServices.KB.CurrentModel;

            string attName = $"{name}Id";

            Attribute att = Attribute.Get(model, attName) ?? Attribute.Create(model);
            if (att.Mode == Artech.Common.Mode.Inserted)
            {
                att.Name = attName;
                att.Type = eDBType.CHARACTER;
                att.Length = 30;
                att.Save();
            }

            string att2Name = $"{name}Name";

            Attribute att2 = Attribute.Get(model, att2Name) ?? Attribute.Create(model);
            if (att2.Mode == Artech.Common.Mode.Inserted)
            {
                att2.Name = att2Name;
                att2.Type = eDBType.CHARACTER;
                att2.Length = 30;
                att2.Save();
            }

            Transaction trn = Transaction.Get(model, new QualifiedName(name)) ?? Transaction.Create(model);
            if (trn.Mode == Artech.Common.Mode.Inserted)
            {
                trn.Name = name;
                trn.Structure.Root.AddAttribute(new TransactionAttribute(trn.Structure, att) { IsKey = true });
                trn.Structure.Root.AddAttribute(new TransactionAttribute(trn.Structure, att2) { IsKey = false });
            }

            return trn;
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
