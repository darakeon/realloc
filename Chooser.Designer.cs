
using System;
using System.Collections.Generic;

namespace realloc
{
	partial class Chooser
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Image = new System.Windows.Forms.PictureBox();
			this.Delete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
			this.SuspendLayout();
			// 
			// Image
			// 
			this.Image.Location = new System.Drawing.Point(12, 12);
			this.Image.Name = "Image";
			this.Image.Size = new System.Drawing.Size(340, 255);
			this.Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Image.TabIndex = 0;
			this.Image.TabStop = false;
			// 
			// Delete
			// 
			this.Delete.Location = new System.Drawing.Point(358, 12);
			this.Delete.Name = "Delete";
			this.Delete.Size = new System.Drawing.Size(156, 23);
			this.Delete.TabIndex = 1;
			this.Delete.Text = "EXCLUIR";
			this.Delete.UseVisualStyleBackColor = true;
			// 
			// Chooser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(526, 279);
			this.Controls.Add(this.Delete);
			this.Controls.Add(this.Image);
			this.Name = "Chooser";
			this.Text = "Choose";
			((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox Image;
		private System.Windows.Forms.Button Delete;
	}
}

