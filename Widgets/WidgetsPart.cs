using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

using Artech.Common;
using Artech.Common.Helpers.Generics;
using Artech.Architecture.Common.Objects;
using Artech.Architecture.UI.Framework.Objects;
using Artech.Architecture.Common.Descriptors;

namespace Acme.Packages.Widgets
{
	[Guid("20dd82f3-ada4-4278-a992-6a2375cfe5b6")]
	[KBObjectPartDescriptor("Widgets", "Acme.Packages.Widgets.Resources, document")]
	public class WidgetsPart : KBObjectPart
	{
		public WidgetsPart(KBObject kbObject)
			: base(typeof(WidgetsPart).GUID, kbObject)
		{
		}

		public override string Name
		{
			get
			{
				return "WidgetsPart";
			}
			set
			{
			}
		}

		private WidgetList widgetList;
		public WidgetList WidgetList
		{
			get
			{
				base.EnsureDeserialization();
				if (widgetList == null)
				{
					widgetList = new WidgetList();
					widgetList.AddNew();
				}
				return widgetList;
			}
		}
		
		public override Mode Mode
		{
			get
			{
				Mode baseMode = base.Mode;
				if (baseMode == Mode.Inserted)
					return Mode.Inserted;

				if (widgetList != null)
					return widgetList.IsModified ? Mode.Modified : Mode.Unchanged;

				return baseMode;
			}
			set
			{
				base.Mode = value;
				if (value == Mode.Unchanged)
					WidgetList.IsModified = false;
			}
		}
		
		#region Serialization

		protected override byte[] SerializeData()
		{
			string listAsText = XmlSerializer<WidgetList>.ToString(WidgetList);
			return Artech.Common.Helpers.Convert.ToByteArray(listAsText);
		}
		
		protected override void DeserializeData(byte[] data)
		{
			string listAsText = Artech.Common.Helpers.Convert.ToString(data, this);
			widgetList = XmlSerializer<WidgetList>.DeserializeFromString(listAsText);
		}

		#endregion
	}
}
