namespace Dofus_Hunt
{
	// Token: 0x02000016 RID: 22
	public partial class FormProcess : global::DevExpress.XtraEditors.XtraForm
	{
		// Token: 0x0600008D RID: 141 RVA: 0x0000246F File Offset: 0x0000066F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000E6B8 File Offset: 0x0000C8B8
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Dofus_Hunt.FormProcess));
			this.panelControl_Process_Licence = new global::DevExpress.XtraEditors.PanelControl();
			this.labelControl_Process_NoLicence = new global::DevExpress.XtraEditors.LabelControl();
			this.simpleButton_Process_SetLicence = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Process_CodeLicence = new global::DevExpress.XtraEditors.SimpleButton();
			this.pictureBox_Process_Logo = new global::System.Windows.Forms.PictureBox();
			this.panelControl_Process_List = new global::DevExpress.XtraEditors.PanelControl();
			this.simpleButton_Process_Select = new global::DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_Process_Actu = new global::DevExpress.XtraEditors.SimpleButton();
			this.listBoxControl_Process_Process = new global::DevExpress.XtraEditors.ListBoxControl();
			this.timer_Process_Process = new global::System.Windows.Forms.Timer(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Process_Licence).BeginInit();
			this.panelControl_Process_Licence.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Process_Logo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Process_List).BeginInit();
			this.panelControl_Process_List.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.listBoxControl_Process_Process).BeginInit();
			base.SuspendLayout();
			this.panelControl_Process_Licence.BorderStyle = global::DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl_Process_Licence.Controls.Add(this.labelControl_Process_NoLicence);
			this.panelControl_Process_Licence.Controls.Add(this.simpleButton_Process_SetLicence);
			this.panelControl_Process_Licence.Controls.Add(this.simpleButton_Process_CodeLicence);
			this.panelControl_Process_Licence.Controls.Add(this.pictureBox_Process_Logo);
			this.panelControl_Process_Licence.Location = new global::System.Drawing.Point(11, 9);
			this.panelControl_Process_Licence.Name = "panelControl_Process_Licence";
			this.panelControl_Process_Licence.Size = new global::System.Drawing.Size(264, 227);
			this.panelControl_Process_Licence.TabIndex = 0;
			this.labelControl_Process_NoLicence.Appearance.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Bold);
			this.labelControl_Process_NoLicence.Appearance.Options.UseFont = true;
			this.labelControl_Process_NoLicence.Location = new global::System.Drawing.Point(41, 126);
			this.labelControl_Process_NoLicence.Name = "labelControl_Process_NoLicence";
			this.labelControl_Process_NoLicence.Size = new global::System.Drawing.Size(183, 16);
			this.labelControl_Process_NoLicence.TabIndex = 3;
			this.labelControl_Process_NoLicence.Text = "Aucune licence détetectée !";
			this.simpleButton_Process_SetLicence.Location = new global::System.Drawing.Point(49, 190);
			this.simpleButton_Process_SetLicence.Name = "simpleButton_Process_SetLicence";
			this.simpleButton_Process_SetLicence.Size = new global::System.Drawing.Size(166, 23);
			this.simpleButton_Process_SetLicence.TabIndex = 2;
			this.simpleButton_Process_SetLicence.Text = "Intégrer la licence";
			this.simpleButton_Process_SetLicence.Click += new global::System.EventHandler(this.simpleButton_Process_SetLicence_Click);
			this.simpleButton_Process_CodeLicence.Location = new global::System.Drawing.Point(49, 161);
			this.simpleButton_Process_CodeLicence.Name = "simpleButton_Process_CodeLicence";
			this.simpleButton_Process_CodeLicence.Size = new global::System.Drawing.Size(166, 23);
			this.simpleButton_Process_CodeLicence.TabIndex = 1;
			this.simpleButton_Process_CodeLicence.Text = "Obtenir le code de licence";
			this.simpleButton_Process_CodeLicence.Click += new global::System.EventHandler(this.simpleButton_Process_CodeLicence_Click);
			this.pictureBox_Process_Logo.Image = global::Dofus_Hunt.Properties.Resources.logo;
			this.pictureBox_Process_Logo.Location = new global::System.Drawing.Point(82, 20);
			this.pictureBox_Process_Logo.Name = "pictureBox_Process_Logo";
			this.pictureBox_Process_Logo.Size = new global::System.Drawing.Size(100, 100);
			this.pictureBox_Process_Logo.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox_Process_Logo.TabIndex = 0;
			this.pictureBox_Process_Logo.TabStop = false;
			this.panelControl_Process_List.BorderStyle = global::DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl_Process_List.Controls.Add(this.simpleButton_Process_Select);
			this.panelControl_Process_List.Controls.Add(this.simpleButton_Process_Actu);
			this.panelControl_Process_List.Controls.Add(this.listBoxControl_Process_Process);
			this.panelControl_Process_List.Location = new global::System.Drawing.Point(11, 9);
			this.panelControl_Process_List.Name = "panelControl_Process_List";
			this.panelControl_Process_List.Size = new global::System.Drawing.Size(264, 227);
			this.panelControl_Process_List.TabIndex = 4;
			this.panelControl_Process_List.Visible = false;
			this.simpleButton_Process_Select.Location = new global::System.Drawing.Point(167, 201);
			this.simpleButton_Process_Select.Name = "simpleButton_Process_Select";
			this.simpleButton_Process_Select.Size = new global::System.Drawing.Size(94, 23);
			this.simpleButton_Process_Select.TabIndex = 5;
			this.simpleButton_Process_Select.Text = "Sélectionner";
			this.simpleButton_Process_Select.Click += new global::System.EventHandler(this.simpleButton_Process_Select_Click);
			this.simpleButton_Process_Actu.Location = new global::System.Drawing.Point(3, 201);
			this.simpleButton_Process_Actu.Name = "simpleButton_Process_Actu";
			this.simpleButton_Process_Actu.Size = new global::System.Drawing.Size(94, 23);
			this.simpleButton_Process_Actu.TabIndex = 4;
			this.simpleButton_Process_Actu.Text = "Actualiser";
			this.simpleButton_Process_Actu.Click += new global::System.EventHandler(this.simpleButton_Process_Actu_Click);
			this.listBoxControl_Process_Process.Location = new global::System.Drawing.Point(3, 3);
			this.listBoxControl_Process_Process.Name = "listBoxControl_Process_Process";
			this.listBoxControl_Process_Process.Size = new global::System.Drawing.Size(258, 192);
			this.listBoxControl_Process_Process.TabIndex = 0;
			this.listBoxControl_Process_Process.DoubleClick += new global::System.EventHandler(this.listBoxControl_Process_Process_DoubleClick);
			this.timer_Process_Process.Interval = 2000;
			this.timer_Process_Process.Tick += new global::System.EventHandler(this.timer_Process_Process_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(286, 244);
			base.Controls.Add(this.panelControl_Process_List);
			base.Controls.Add(this.panelControl_Process_Licence);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.IconOptions.Icon = (global::System.Drawing.Icon)resources.GetObject("FormProcess.IconOptions.Icon");
			base.MaximizeBox = false;
			base.Name = "FormProcess";
			this.Text = "Dofus Hunt - Processus";
			base.Load += new global::System.EventHandler(this.FormProcess_Load);
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Process_Licence).EndInit();
			this.panelControl_Process_Licence.ResumeLayout(false);
			this.panelControl_Process_Licence.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Process_Logo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.panelControl_Process_List).EndInit();
			this.panelControl_Process_List.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.listBoxControl_Process_Process).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000128 RID: 296
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000129 RID: 297
		private global::DevExpress.XtraEditors.PanelControl panelControl_Process_Licence;

		// Token: 0x0400012A RID: 298
		private global::DevExpress.XtraEditors.LabelControl labelControl_Process_NoLicence;

		// Token: 0x0400012B RID: 299
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Process_SetLicence;

		// Token: 0x0400012C RID: 300
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Process_CodeLicence;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.PictureBox pictureBox_Process_Logo;

		// Token: 0x0400012E RID: 302
		private global::DevExpress.XtraEditors.PanelControl panelControl_Process_List;

		// Token: 0x0400012F RID: 303
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Process_Select;

		// Token: 0x04000130 RID: 304
		private global::DevExpress.XtraEditors.SimpleButton simpleButton_Process_Actu;

		// Token: 0x04000131 RID: 305
		private global::DevExpress.XtraEditors.ListBoxControl listBoxControl_Process_Process;

		// Token: 0x04000132 RID: 306
		private global::System.Windows.Forms.Timer timer_Process_Process;
	}
}
