namespace Acme.Packages.Menu
{
	partial class MyEditor
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox.EnableAutoDragDrop = true;
			this.textBox.Location = new System.Drawing.Point(0, 0);
			this.textBox.Name = "richTextBox1";
			this.textBox.ShowSelectionMargin = true;
			this.textBox.Size = new System.Drawing.Size(150, 150);
			this.textBox.TabIndex = 0;
			this.textBox.Text = "";
			// 
			// MyEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textBox);
			this.Name = "MyEditor";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox textBox;
	}
}
