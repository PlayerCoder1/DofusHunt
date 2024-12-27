namespace Dofus_Hunt
{
	// Token: 0x0200001F RID: 31
	public partial class FormProcess : global::DevExpress.XtraEditors.XtraForm
	{
		// Token: 0x060000B7 RID: 183 RVA: 0x000027CC File Offset: 0x000009CC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000CE14 File Offset: 0x0000B014
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Dofus_Hunt.FormProcess));
			this.panelControl_Licence = new global::DevExpress.XtraEditors.PanelControl();
			this.simpleButton_setLicence = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_getCode = new global::DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new global::DevExpress.XtraEditors.LabelControl();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.panelControl_Process = new global::DevExpress.XtraEditors.PanelControl();
			this.simpleButton_select = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_actu = new global::DevExpress.XtraEditors.SimpleButton();
			this.listBoxControl_process = new global::DevExpress.XtraEditors.ListBoxControl();
			this.timer_process = new global::System.Windows.Forms.Timer(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Licence).BeginInit();
			this.panelControl_Licence.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Process).BeginInit();
			this.panelControl_Process.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.listBoxControl_process).BeginInit();
			base.SuspendLayout();
			this.panelControl_Licence.BorderStyle = global::DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl_Licence.Controls.Add(this.simpleButton_setLicence);
			this.panelControl_Licence.Controls.Add(this.simpleButton_getCode);
			this.panelControl_Licence.Controls.Add(this.labelControl1);
			this.panelControl_Licence.Controls.Add(this.pictureBox1);
			this.panelControl_Licence.Location = new global::System.Drawing.Point(12, 12);
			this.panelControl_Licence.Name = "panelControl_Licence";
			this.panelControl_Licence.Size = new global::System.Drawing.Size(262, 230);
			this.panelControl_Licence.TabIndex = 0;
			this.simpleButton_setLicence.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.simpleButton_setLicence.Location = new global::System.Drawing.Point(40, 184);
			this.simpleButton_setLicence.Name = "simpleButton_setLicence";
			this.simpleButton_setLicence.Size = new global::System.Drawing.Size(183, 26);
			this.simpleButton_setLicence.TabIndex = 3;
			this.simpleButton_setLicence.Text = "Clique clique";
			this.simpleButton_setLicence.Click += new global::System.EventHandler(this.simpleButton_setLicence_Click);
			this.simpleButton_getCode.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.simpleButton_getCode.Location = new global::System.Drawing.Point(40, 152);
			this.simpleButton_getCode.Name = "simpleButton_getCode";
			this.simpleButton_getCode.Size = new global::System.Drawing.Size(183, 26);
			this.simpleButton_getCode.TabIndex = 2;
			this.simpleButton_getCode.Text = "Obtenir le code de licence";
			this.simpleButton_getCode.Click += new global::System.EventHandler(this.simpleButton_getCode_Click);
			this.labelControl1.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.labelControl1.Appearance.Options.UseFont = true;
			this.labelControl1.Location = new global::System.Drawing.Point(40, 130);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new global::System.Drawing.Size(183, 16);
			this.labelControl1.TabIndex = 1;
			this.labelControl1.Text = "Discord: picwarior381";
			this.pictureBox1.Image = global::Dofus_Hunt.Properties.Resources._54ee5425_005f_4c80_b417_3018c0c05f2e;
			this.pictureBox1.Location = new global::System.Drawing.Point(81, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(100, 100);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.panelControl_Process.BorderStyle = global::DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl_Process.Controls.Add(this.simpleButton_select);
			this.panelControl_Process.Controls.Add(this.simpleButton_actu);
			this.panelControl_Process.Controls.Add(this.listBoxControl_process);
			this.panelControl_Process.Location = new global::System.Drawing.Point(12, 12);
			this.panelControl_Process.Name = "panelControl_Process";
			this.panelControl_Process.Size = new global::System.Drawing.Size(262, 230);
			this.panelControl_Process.TabIndex = 4;
			this.simpleButton_select.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.simpleButton_select.Location = new global::System.Drawing.Point(156, 203);
			this.simpleButton_select.Name = "simpleButton_select";
			this.simpleButton_select.Size = new global::System.Drawing.Size(103, 24);
			this.simpleButton_select.TabIndex = 5;
			this.simpleButton_select.Text = "Sélectionner";
			this.simpleButton_select.Click += new global::System.EventHandler(this.simpleButton_select_Click);
			this.simpleButton_actu.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.simpleButton_actu.Location = new global::System.Drawing.Point(3, 203);
			this.simpleButton_actu.Name = "simpleButton_actu";
			this.simpleButton_actu.Size = new global::System.Drawing.Size(103, 24);
			this.simpleButton_actu.TabIndex = 4;
			this.simpleButton_actu.Text = "Actualiser";
			this.simpleButton_actu.Click += new global::System.EventHandler(this.simpleButton_actu_Click);
			this.listBoxControl_process.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.listBoxControl_process.Location = new global::System.Drawing.Point(3, 3);
			this.listBoxControl_process.Name = "listBoxControl_process";
			this.listBoxControl_process.Size = new global::System.Drawing.Size(256, 194);
			this.listBoxControl_process.TabIndex = 0;
			this.listBoxControl_process.DoubleClick += new global::System.EventHandler(this.listBoxControl_process_DoubleClick);
			this.timer_process.Interval = 2000;
			this.timer_process.Tick += new global::System.EventHandler(this.timer_process_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(286, 254);
			base.Controls.Add(this.panelControl_Process);
			base.Controls.Add(this.panelControl_Licence);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.IconOptions.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("FormProcess.IconOptions.Icon");
			base.MaximizeBox = false;
			base.Name = "FormProcess";
			this.Text = "Dofus Hunt - Processus";
			base.Load += new global::System.EventHandler(this.FormProcess_Load);
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Licence).EndInit();
			this.panelControl_Licence.ResumeLayout(false);
			this.panelControl_Licence.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Process).EndInit();
			this.panelControl_Process.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.listBoxControl_process).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000CF RID: 207
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000D0 RID: 208
		private global::DevExpress.XtraEditors.PanelControl panelControl_Licence;

		// Token: 0x040000D1 RID: 209
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_setLicence;

		// Token: 0x040000D2 RID: 210
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_getCode;

		// Token: 0x040000D3 RID: 211
		private global::DevExpress.XtraEditors.LabelControl labelControl1;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040000D5 RID: 213
		private global::DevExpress.XtraEditors.PanelControl panelControl_Process;

		// Token: 0x040000D6 RID: 214
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_select;

		// Token: 0x040000D7 RID: 215
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_actu;

		// Token: 0x040000D8 RID: 216
		private global::DevExpress.XtraEditors.ListBoxControl listBoxControl_process;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.Timer timer_process;
	}
}
