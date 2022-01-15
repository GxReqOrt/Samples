using Artech.Architecture.Common.Descriptors;
using Artech.Architecture.Common.Objects;
using Artech.Genexus.Common.Parts;
using System.Runtime.InteropServices;

namespace Acme.Packages.NewObject
{
    [Guid("89283150-9b94-410a-955c-92a1eef442aa")]
	[KBObjectDescriptor("ef0f3552-a93d-4f10-9b94-4442e32ea719", "New Object Type", "NewObjectType", "Acme.Packages.NewObject.Resources, Object")]
	[KBObjectComposition(true, typeof(NewPartTypePart), typeof(DocumentationPart))]
	class NewObjectType : KBObject
	{
		public NewObjectType(KBModel model)
			: base(model, typeof(NewObjectType).GUID)
		{
		} 
	}
}
