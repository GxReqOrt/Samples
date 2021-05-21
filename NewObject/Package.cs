using System;
using System.Runtime.InteropServices;
using System.Xml.XPath;

using Artech.Architecture.Common.Descriptors;
using Artech.Architecture.Common.Objects;
using Artech.Architecture.Common.Packages;
using Artech.Architecture.Common.Services;
using Artech.Architecture.UI.Framework.Objects;
using Artech.Architecture.UI.Framework.Packages;
using Artech.Common.Diagnostics;

namespace Acme.Packages.NewObject
{
	[Guid("a24bc960-4cdb-42f6-bfa9-84ad8eb85221")]
	public class Package : AbstractPackageUI
	{
		public override string Name
		{
			get { return "NewObject"; }
		}

		public override void Initialize(IGxServiceProvider services)
		{
			base.Initialize(services);

			LoadCategories();
			LoadObjectTypes();
			LoadPartTypes();
			LoadEditors();

			IOutputService output = CommonServices.Output;
			output.Clear();
			output.StartSection("Sección de prueba");
			output.AddLine("Mando un mensaje");
			output.EndSection("Sección de prueba", true);
		}

		private void LoadCategories()
		{
			//Insert all categories here
			KBObjectCategoryDescriptor myCategory = new KBObjectCategoryDescriptor(new Guid("ef0f3552-a93d-4f10-9b94-4442e32ea719"), "New Category", Resources.Folder);
			this.AddCategory(myCategory.Id, myCategory.Name, myCategory.Icon);
		}

		private void LoadObjectTypes()
		{
			this.AddObjectType<NewObjectType>();
		}

		private void LoadPartTypes()
		{
			this.AddPart<NewPartTypePart>();
		}

		private void LoadEditors()
		{
			this.AddEditor<MyEditor>(typeof(NewPartTypePart).GUID);
		}

		public override void ReadPart(KBObjectPart part, XPathNavigator partData, ImportOptions options, IReferenceResolver resolver, OutputMessages output)
        {
			if (part is NewPartTypePart)
			{
				XPathNavigator partProps = partData.SelectSingleNode("Properties");
				if (partProps != null)
					Artech.Common.Properties.KmwProperties.Read(part, partProps.OuterXml, output);

				NewPartTypePart myPart = part as NewPartTypePart;
				XPathNavigator partText = partData.SelectSingleNode("Text");
				if (partText != null)
					myPart.Text = partText.InnerXml;
				else
					myPart.Text = "";
			}
		}
	}
}
