using Artech.Architecture.Common.Packages;
using Artech.Architecture.Common.Services;
using Artech.Architecture.UI.Framework.Objects;
using Artech.Architecture.UI.Framework.Packages;
using System;
using System.Runtime.InteropServices;
using Artech.Packages.Definition;
using Artech.Architecture.Common.Descriptors;

[assembly: PackageAttribute(typeof(ArmandoCardoso.Packages.Community.CommunityPackage), IsUIPackage=true)]

namespace ArmandoCardoso.Packages.Community
{
	[Guid("0471ba29-8a43-4927-8699-58ce02f4688a")]
	public class CommunityPackage : AbstractPackageUI	
    {
        public static Guid guid = typeof(CommunityPackage).GUID;

		public override string Name
		{
			get { return "Community"; }
		}

        public override void Initialize(IGxServiceProvider services)
        {
            base.Initialize(services);

            LoadCommandTargets();
        }

        private void LoadCommandTargets()
        {
            AddCommandTarget(new CommandManager());
        }
	}
}
