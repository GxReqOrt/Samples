using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using Artech.FrameworkDE;
using Artech.Architecture.UI.Framework.Packages;
using Artech.Architecture.UI.Framework.Services;
using Artech.Common.Framework.Selection;

namespace Acme.Packages.ToolWindow
{
	[Guid("3C3DEAE0-66DD-48bd-866D-463C4075385A")]
	public partial class ToolWindow : AbstractToolWindow, ISelectionListener
	{
		public ToolWindow()
		{
			InitializeComponent();
			UIServices.TrackSelection.Subscribe(Guid.NewGuid(), this);
		}

		public static Guid guid = typeof(ToolWindow).GUID;

		private void button_Click(object sender, EventArgs e)
		{
			MessageBox.Show(textBox.Text);
		}

		#region ISelectionListener Members

		public bool OnSelectChange(ISelectionContainer sc)
		{
			if (sc == null)
				return false;

			StringBuilder builder = new StringBuilder();

			if (sc.Count == 1)
			{
				builder.AppendLine("One object selected:");
				builder.AppendLine(sc.SelectedObject.ToString());
			}
			else if (sc.Count > 1)
			{
				builder.AppendLine("Multiple objects are selected");
				foreach (object obj in sc.SelectedObjects)
				{
					builder.AppendLine(obj.ToString());
				}
			}

			string newText = builder.ToString();
			if (newText != selectionLabel.Text)
			{
				selectionLabel.Text = newText;
			}

			return true;
		}

		#endregion
	}
}
