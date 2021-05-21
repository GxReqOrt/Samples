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

namespace Acme.Packages.RTFText
{
	public partial class MyEditor : BaseEditor
	{
		public MyEditor()
		{
			InitializeComponent();
		}

		public TextPart TextPart
		{
			get
			{
				return base.Part as TextPart;
			}
		}

		public string RtfText
		{
			get { return TextPart.RtfText; }
			set { TextPart.RtfText = value; }
		}

		protected override void OnLoad(EventArgs e)
		{
			base.Initialize();
			textBox.Rtf = RtfText;
			AttachToEvents();
		}

		private void AttachToEvents()
		{
			textBox.TextChanged += new EventHandler(textBox_TextChanged);
			textBox.SelectionChanged += new EventHandler(textBox_SelectionChanged);
		}

		void textBox_TextChanged(object sender, EventArgs e)
		{
			RtfText = textBox.Rtf;
			this.DocumentChanged(null);
		}

		void textBox_SelectionChanged(object sender, EventArgs e)
		{
			// We don't actually have a proper 'object' to be bound to the Property Inspector
			// so we use this SelectionProxy just for illustration purposes
			List<object> selection = new List<object>(1);
			selection.Add(new SelectionProxy(textBox));
			SetSelection(selection , null);
		}

		public override void UpdateView()
		{
		}

		protected override void LoadDocument(object data)
		{
		}

		#region SelectionProxy class

		public class SelectionProxy : IDescriptive
		{
			private RichTextBox container;

			public SelectionProxy(RichTextBox container)
			{
				this.container = container;
			}

			public Font SelectionFont
			{
				get { return container.SelectionFont; }
				set
				{
					container.SelectionFont = value;
				}
			}

			public Color SelectionColor
			{
				get { return container.SelectionColor; }
				set
				{
					container.SelectionColor = value;
				}
			}

			public Color SelectionBackColor
			{
				get { return container.SelectionBackColor; }
				set
				{
					container.SelectionBackColor = value;
				}
			}

			public HorizontalAlignment SelectionAlignment
			{
				get { return container.SelectionAlignment; }
				set
				{
					container.SelectionAlignment = value;
				}
			}

			#region IDescriptive Members

			[Browsable(false)]
			public string Description
			{
				get { return string.Empty; }
			}

			[Browsable(false)]
			public string Type
			{
				get { return "Selected text"; }
			}

			bool IDescriptive.IsReadOnly { get { return false; } }
			#endregion
		}

		#endregion
	}
}
