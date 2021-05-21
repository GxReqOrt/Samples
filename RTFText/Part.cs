using System;
using System.Runtime.InteropServices;

using Artech.Common;
using Artech.Architecture.Common.Objects;
using Artech.Architecture.UI.Framework.Objects;
using Artech.Architecture.Common.Descriptors;

namespace Acme.Packages.RTFText
{
	[Guid("bbeca468-8802-4d79-b252-148ce367ba7b")]
	[KBObjectPartDescriptor("Text", "Acme.Packages.RTFText.Resources, document")]
	public class TextPart : KBObjectPart
	{
		public TextPart(KBObject kbObject)
			: base(typeof(TextPart).GUID, kbObject)
		{
		}

		public override string Name
		{
			get
			{
				return "TextPart";
			}
			set
			{
			}
		}

		private string _rtfText;

		public string RtfText
		{
			get
			{
				base.EnsureDeserialization();
				if (_rtfText == null)
				{
					_rtfText = "";
				}
				return _rtfText;
			}
			set
			{
				_rtfText = value;
				SetModeModified(Modification.Data, null);
			}
		}

		#region Serialization

		protected override byte[] SerializeData()
		{
			return Artech.Common.Helpers.Convert.ToByteArray(RtfText, this);
		}
		
		protected override void DeserializeData(byte[] data)
		{
			_rtfText = Artech.Common.Helpers.Convert.ToString(data, this);
		}

		#endregion
	}
}
