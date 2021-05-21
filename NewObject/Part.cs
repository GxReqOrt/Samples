using System;
using System.Runtime.InteropServices;

using Artech.Architecture.Common.Objects;
using Artech.Architecture.Common.Descriptors;
using Artech.Architecture.UI.Framework.Objects;
using Artech.Common;
using Artech.Common.Helpers.Kmw;

namespace Acme.Packages.NewObject
{
	[Guid("8c65640e-46d7-4c1d-ad27-56fe81f23485")]
	[KBObjectPartDescriptor("New Part Type", "Acme.Packages.NewObject.Resources, document")]
	public class NewPartTypePart : KBObjectPart
	{
		public NewPartTypePart(KBObject kbObject)
			: base(typeof(NewPartTypePart).GUID, kbObject)
		{
		}

		public override string Name
		{
			get
			{
				return "NewPartTypePart";
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
				throw new Exception("NewPartTypePart cannot attach more than one editor at a time");
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

		// Export
		[KmwElement(Name = "Text")]
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
					return Editor.IsDirty? Mode.Modified : Mode.Unchanged;
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
