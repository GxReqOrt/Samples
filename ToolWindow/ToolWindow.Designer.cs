namespace Acme.Packages.ToolWindow
{
	partial class ToolWindow
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
			this.selectionLabel = new System.Windows.Forms.Label();
			this.button = new System.Windows.Forms.Button();
			this.textBox = new System.Windows.Forms.TextBox();
			this.label = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// selectionLabel
			// 
			this.selectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.selectionLabel.Location = new System.Drawing.Point(15, 113);
			this.selectionLabel.Name = "selectionLabel";
			this.selectionLabel.Size = new System.Drawing.Size(163, 278);
			this.selectionLabel.TabIndex = 7;
			// 
			// button
			// 
			this.button.Location = new System.Drawing.Point(18, 59);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(75, 23);
			this.button.TabIndex = 6;
			this.button.Text = "ShowText";
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler(this.button_Click);
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.Location = new System.Drawing.Point(18, 32);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(160, 20);
			this.textBox.TabIndex = 5;
			// 
			// label
			// 
			this.label.AutoSize = true;
			this.label.Location = new System.Drawing.Point(15, 15);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(80, 13);
			this.label.TabIndex = 4;
			this.label.Text = "Enter some text";
			// 
			// ToolWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.selectionLabel);
			this.Controls.Add(this.button);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.label);
			this.Name = "ToolWindow";
			this.Size = new System.Drawing.Size(196, 405);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label selectionLabel;
		private System.Windows.Forms.Button button;
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.Label label;
	}
}
