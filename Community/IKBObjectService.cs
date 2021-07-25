using Artech.Architecture.Common.Objects;

namespace ArmandoCardoso.Packages.Community
{
    public interface IKBObjectService
    {
        KBObject BuildEmpty(string name);

        void Save(KBObject obj);

        void Save(KBObject obj, KBObjectSavePreferences preferences);
    }
}
