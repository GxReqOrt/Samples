using Acme.Packages.RTFText;
using Artech.Architecture.Common.Descriptors;
using Artech.Architecture.Common.Packages;
using Artech.Architecture.Common.Services;
using Artech.Architecture.UI.Framework.Packages;
using RTFText;
using System;
using System.Runtime.InteropServices;

[assembly: Package(typeof(Package))]
[assembly: KBObjectsDeclaration(typeof(Acme.Packages.RTFText.RTFText))]
[assembly: KBObjectPartsDeclaration(typeof(TextPart))]
namespace Acme.Packages.RTFText
{
    [Guid("ff1bf963-850a-4d9f-8dc4-80cf32a98487")]
	public class Package : AbstractPackageUI
	{
		public override string Name
		{
			get { return "RTFText"; }
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
			KBObjectCategoryDescriptor myCategory = new KBObjectCategoryDescriptor(new Guid("086d64ca-f841-4eb8-8777-48ca68339495"), "RTF", Resources.Folder);
			this.AddCategory(myCategory.Id, myCategory.Name, myCategory.Icon);
		}

		private void LoadObjectTypes()
		{
			this.AddObjectType<RTFText>();
		}

		private void LoadPartTypes()
		{
			this.AddPart<TextPart>();
		}

		private void LoadEditors()
		{
			this.AddEditor<MyEditor>(typeof(TextPart).GUID);
		}
	}
}
