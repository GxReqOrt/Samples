using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using Artech.Architecture.Common.Objects;
using Artech.Architecture.UI.Framework.Editors;
using Artech.Common.Properties;

namespace Acme.Packages.Widgets
{
	public partial class WidgetEditor : BaseEditor
	{
		public WidgetEditor()
		{
			InitializeComponent();
		}

		public WidgetsPart WidgetPart
		{
			get
			{
				return base.Part as WidgetsPart;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.Initialize();

			if (WidgetPart != null)
			{
				dataGridView.DataSource = WidgetPart.WidgetList;
			}

			AttachToEvents();
		}

		private void AttachToEvents()
		{
			dataGridView.DataError += new DataGridViewDataErrorEventHandler(OnDataError);
			dataGridView.CellValidating += new DataGridViewCellValidatingEventHandler(OnCellValidating);
			dataGridView.CellValidated += new DataGridViewCellEventHandler(OnCellValidated);
			dataGridView.CellLeave += new DataGridViewCellEventHandler(OnCellLeave);
			dataGridView.CellEndEdit += new DataGridViewCellEventHandler(OnCellEndEdit);
			dataGridView.CellValueChanged += new DataGridViewCellEventHandler(OnCellValueChanged);

			WidgetPart.WidgetList.ListChanged += new ListChangedEventHandler(WidgetList_ListChanged);
		}

		void OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DocumentChanged(null);
		}

		void WidgetList_ListChanged(object sender, ListChangedEventArgs e)
		{
			DocumentChanged(null);
		}

		void OnCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			// We are only validating the first column
			if (e.ColumnIndex > 0)
				return;

			int newInteger;
			if (!int.TryParse(e.FormattedValue.ToString(), out newInteger)
				|| newInteger <= 0)
			{
				e.Cancel = true;
				dataGridView.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
			}
		}

		void OnCellValidated(object sender, DataGridViewCellEventArgs e)
		{
			RemoveErrorText(e.RowIndex);
		}

		void OnCellLeave(object sender, DataGridViewCellEventArgs e)
		{
			RemoveErrorText(e.RowIndex);
		}

		void OnCellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			RemoveErrorText(e.RowIndex);
		}

		void RemoveErrorText(int rowIndex)
		{
			dataGridView.Rows[rowIndex].ErrorText = null;
		}

		void OnDataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(e.Exception.Message);
		}

		public override void UpdateView()
		{
		}

		protected override void LoadDocument(object data)
		{
		}
	}
}
