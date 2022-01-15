using Artech.Architecture.Common.Packages;
using Artech.Architecture.Common.Services;
using Artech.Architecture.UI.Framework.Controls;
using Artech.Architecture.UI.Framework.Packages;
using System.Runtime.InteropServices;

[assembly: Package(typeof(Artech.Samples.DailyDilbert.Package))]
namespace Artech.Samples.DailyDilbert
{
    [Guid("db2834f8-22e1-4258-b56b-e2377002b3ef")]
	public class Package : AbstractPackageUI	{
		public override string Name
		{
			get { return "DailyDilbert"; }
		}

		public override void Initialize(IGxServiceProvider services)
		{
			base.Initialize(services);
		}

		private DilbertWindow toolWindow;

		public override IToolWindow CreateToolWindow(System.Guid toolWindowId)
		{
			if (toolWindowId.Equals(DilbertWindow.guid))
			{
				if (toolWindow == null)
					toolWindow = new DilbertWindow();
				return toolWindow;
			}

			return base.CreateToolWindow(toolWindowId);
		}
	}
}
