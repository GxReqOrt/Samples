using Artech.Architecture.Common.Descriptors;
using Artech.Architecture.Common.Objects;
using Artech.Genexus.Common.Parts;
using System.Runtime.InteropServices;

namespace Acme.Packages.Menu
{
    [Guid("3d716d8a-3304-4ca3-8bac-1b1ef65997c8")]
	[KBObjectDescriptor("997a04e3-9163-4c7b-a77a-7ba9ea9fd5da", "My Type", "MyType", "Acme.Packages.Menu.Resources, Object")]
	[KBObjectComposition(true, typeof(MyDataPart), typeof(DocumentationPart))]
	class MyType : KBObject
	{
		public MyType(KBModel model)
			: base(model, typeof(MyType).GUID)
		{
		} 
	}
}
