using Artech.Architecture.Common.Descriptors;
using Artech.Architecture.Common.Objects;
using Artech.Genexus.Common.Parts;
using System.Runtime.InteropServices;

namespace Acme.Packages.RTFText
{
    [Guid("7f0ed40a-39a1-47c2-b8cf-0ca4c559bd4e")]
	[KBObjectDescriptor("086d64ca-f841-4eb8-8777-48ca68339495", "RTFText", "RTFText", "Acme.Packages.RTFText.Resources, Object")]
	[KBObjectComposition(extensible: true, typeof(TextPart), typeof(DocumentationPart))]
	class RTFText : KBObject
	{
		public RTFText(KBModel model)
			: base(model, typeof(RTFText).GUID)
		{
		} 
	}
}
