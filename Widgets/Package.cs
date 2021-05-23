using Artech.Architecture.Common.Packages;
using Artech.Architecture.Common.Services;
using Artech.Architecture.UI.Framework.Objects;
using Artech.Architecture.Common.Descriptors;
using Artech.Architecture.UI.Framework.Packages;
using System;
using System.Runtime.InteropServices;
using Acme.Packages.Widgets;
using Widgets;

[assembly: PackageAttribute(typeof(Package))]
[assembly: KBObjectsDeclarationAttribute(typeof(Widgetry))]
[assembly: KBObjectPartsDeclarationAttribute(typeof(WidgetsPart))]
namespace Acme.Packages.Widgets
{
	[Guid("7dfe339e-5e65-4a83-ad59-611b707657bc")]
	public class Package : AbstractPackageUI
	{
		public override string Name
		{
			get { return "Widgets"; }
		}

		public override void Initialize(IGxServiceProvider services)
		{
			base.Initialize(services);

			LoadCategories();
			LoadObjectTypes();
			LoadPartTypes();
			LoadEditors();
		}

		private void LoadCategories()
		{
			//Insert all categories here
			KBObjectCategoryDescriptor myCategory = new KBObjectCategoryDescriptor(new Guid("2bb97b99-4280-44a4-a41d-f97b50e8fc90"), "Widgets", Resources.Folder);
			this.AddCategory(myCategory.Id, myCategory.Name, myCategory.Icon);
		}

		private void LoadObjectTypes()
		{
			this.AddObjectType<Widgetry>();
		}

		private void LoadPartTypes()
		{
			this.AddPart<WidgetsPart>();
		}

		private void LoadEditors()
		{
			this.AddEditor<WidgetEditor>(typeof(WidgetsPart).GUID);
		}
	}
}
