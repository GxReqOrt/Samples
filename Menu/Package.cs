using Artech.Architecture.Common.Packages;
using Artech.Architecture.Common.Services;
using Artech.Architecture.UI.Framework.Packages;
using System;
using System.Runtime.InteropServices;
using Artech.Architecture.Common.Descriptors;
using Menu;
using Acme.Packages.Menu;

[assembly: PackageAttribute(typeof(Acme.Packages.Menu.MenuPackage))]
[assembly: KBObjectsDeclarationAttribute(typeof(MyType))]
[assembly: KBObjectPartsDeclarationAttribute(typeof(MyDataPart))]
namespace Acme.Packages.Menu
{
    [Guid("163faefb-1d07-4a23-acca-5f287020bcac")]
	public class MenuPackage : AbstractPackageUI
	{
		public static Guid guid = typeof(MenuPackage).GUID;

		public override string Name
		{
			get { return "Menu"; }
		}

		public override void Initialize(IGxServiceProvider services)
		{
			base.Initialize(services);

			LoadCategories();
			LoadObjectTypes();
			LoadPartTypes();
			LoadEditors();
			LoadCommandTargets();
		}

		private void LoadCategories()
		{
			//Insert all categories here
			KBObjectCategoryDescriptor myCategory = new KBObjectCategoryDescriptor(new Guid("997a04e3-9163-4c7b-a77a-7ba9ea9fd5da"), "My Category", Resources.Folder);
			this.AddCategory(myCategory.Id, myCategory.Name, myCategory.Icon);
		}

		private void LoadObjectTypes()
		{
			this.AddObjectType<MyType>();
		}

		private void LoadPartTypes()
		{
			this.AddPart<MyDataPart>();
		}

		private void LoadEditors()
		{
			this.AddEditor<MyEditor>(typeof(MyDataPart).GUID);
		}

		private void LoadCommandTargets()
		{
			AddCommandTarget(new CommandManager());
		}
	}
}
