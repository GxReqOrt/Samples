using Artech.Architecture.Common.Packages;
using Artech.Architecture.Common.Services;
using Artech.Architecture.UI.Framework.Controls;
using Artech.Architecture.UI.Framework.Packages;
using Artech.Packages.Definition;
using System;
using System.Runtime.InteropServices;

[assembly: Package(typeof(Acme.Packages.ToolWindow.ToolWindowPackage))]
namespace Acme.Packages.ToolWindow
{
    [Guid("efd9a280-6fea-4139-afb5-5da16e757bcf")]
	public class ToolWindowPackage : AbstractPackageUI
	{
		public static Guid guid = typeof(ToolWindowPackage).GUID;

		public override string Name
		{
			get { return "ToolWindow"; }
		}

		public override void Initialize(IGxServiceProvider services)
		{
			base.Initialize(services);
		}

		private ToolWindow toolWindow;

		public override IToolWindow CreateToolWindow(System.Guid toolWindowId)
		{
			if (toolWindowId.Equals(ToolWindow.guid))
			{
				if (toolWindow == null)
					toolWindow = new ToolWindow();
				return toolWindow;
			}

			return base.CreateToolWindow(toolWindowId);
		}
	}
}
