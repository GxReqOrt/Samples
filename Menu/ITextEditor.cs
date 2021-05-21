using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Packages.Menu
{
	public interface ITextEditor
	{
		string Content
		{
			get;
			set;
		}

		bool IsDirty
		{
			get;
			set;
		}
	}
}
