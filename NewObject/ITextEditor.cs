using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Packages.NewObject
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
