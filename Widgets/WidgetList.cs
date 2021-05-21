using System;
using System.ComponentModel;
using Artech.Common.Helpers.Events;

namespace Acme.Packages.Widgets
{
	public class WidgetList : BindingList<Widget>
	{
		public WidgetList()
		{
			AllowNew = true;
			AllowRemove = true;
			AllowEdit = true;
		}

		private bool _isModified;

		public bool IsModified
		{
			get
			{
				if (_isModified)
					return true;

				foreach (Widget widget in Items)
				{
					if (widget.IsModified)
						return true;
				}

				return false; 
			}

			set
			{
				_isModified = value;
				if (!_isModified)
				{
					foreach (Widget widget in Items)
					{
						widget.IsModified = false;
					}
				}
			}
		}

		protected override void OnListChanged(ListChangedEventArgs e)
		{
			base.OnListChanged(e);
			IsModified = true;
		}

		protected override void OnAddingNew(AddingNewEventArgs e)
		{
			base.OnAddingNew(e);
			e.NewObject = new Widget("New Widget", 1);
		}
	}
}
