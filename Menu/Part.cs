using Artech.Architecture.Common.Descriptors;
using Artech.Architecture.Common.Objects;
using Artech.Common;
using System;
using System.Runtime.InteropServices;

namespace Acme.Packages.Menu
{
    [Guid("baf77006-36ce-4124-a869-9db6fa0c1073")]
    [KBObjectPartDescriptor("My Data", "Acme.Packages.Menu.Resources, document")]
    public class MyDataPart : KBObjectPart
    {
        public MyDataPart(KBObject kbObject)
            : base(typeof(MyDataPart).GUID, kbObject)
        {
        }

        public override string Name
        {
            get
            {
                return "MyDataPart";
            }
            set
            {
            }
        }

        private ITextEditor Editor;

        public void AttachEditor(ITextEditor editor)
        {
            if (Editor != null)
            {
                throw new Exception("MyDataPart cannot attach more than one editor at a time");
            }

            editor.Content = MyText;
            editor.IsDirty = false;
            Editor = editor;
        }

        public void DetachEditor(ITextEditor editor)
        {
            if (Editor == editor)
            {
                MyText = Editor.Content;
                if (Editor.IsDirty)
                    SetModeModified(Modification.Data, null);

                Editor = null;
            }
        }

        string text;
        private string MyText
        {
            get
            {
                base.EnsureDeserialization();
                return text;
            }
            set
            {
                text = value;
            }

        }

        public string Text
        {
            get
            {
                if (Editor != null)
                {
                    return Editor.Content;
                }

                return MyText;
            }

            set
            {
                if (Editor != null)
                {
                    Editor.Content = value;
                    return;
                }

                MyText = value;
                SetModeModified(Modification.Data, null);
            }
        }

        public override Mode Mode
        {
            get
            {
                if (base.Mode == Mode.Inserted)
                    return Mode.Inserted;

                if (Editor != null)
                {
                    return Editor.IsDirty ? Mode.Modified : Mode.Unchanged;
                }

                return base.Mode;
            }
            set
            {
                base.Mode = value;
            }
        }

        #region Serialization

        protected override byte[] SerializeData()
        {
            return Artech.Common.Helpers.Convert.ToByteArray(Text, this);
        }

        protected override void DeserializeData(byte[] data)
        {
            Text = Artech.Common.Helpers.Convert.ToString(data, this);
        }

        #endregion
    }
}
