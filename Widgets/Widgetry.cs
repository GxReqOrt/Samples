using Artech.Architecture.Common.Descriptors;
using Artech.Architecture.Common.Objects;
using Artech.Genexus.Common.Parts;
using System.Runtime.InteropServices;

namespace Acme.Packages.Widgets
{
    [Guid("ec1df3b5-de08-465f-ae34-b0e08c6d22e0")]
	[KBObjectDescriptor("2bb97b99-4280-44a4-a41d-f97b50e8fc90", "Widgetry", "Widgetry", "Acme.Packages.Widgets.Resources, Object")]
	[KBObjectComposition(extensible: true, typeof(WidgetsPart), typeof(DocumentationPart))]
	class Widgetry : KBObject
	{
		public Widgetry(KBModel model)
			: base(model, typeof(Widgetry).GUID)
		{
		} 
	}
}
