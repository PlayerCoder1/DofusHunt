using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Dofus_Hunt.Properties;

namespace Dofus_Hunt
{
	// Token: 0x0200001F RID: 31
	public partial class FormProcess : XtraForm
	{
		// Token: 0x060000AB RID: 171 RVA: 0x00002717 File Offset: 0x00000917
		public FormProcess()
		{
			this.InitializeComponent();
			this._dofusHunt = new DofusHunt(0, 70);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000274A File Offset: 0x0000094A
		private void SelectProcess()
		{
			if (this.listBoxControl_process.SelectedItem != null)
			{
				new FormHome(this.listBoxControl_process.SelectedItem.ToString()).Show();
				base.Hide();
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000CCEC File Offset: 0x0000AEEC
		private void ActuProcess()
		{
			string selectedItem = this.listBoxControl_process.SelectedItem as string;
			this.listBoxControl_process.Items.Clear();
			this._dofusHunt.ListRunningPrograms(this.listBoxControl_process);
			if (selectedItem != null && this.listBoxControl_process.Items.Contains(selectedItem))
			{
				this.listBoxControl_process.SelectedItem = selectedItem;
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000CD50 File Offset: 0x0000AF50
		private void LicenceIsOk()
		{
			this.panelControl_Licence.Visible = false;
			this.panelControl_Process.Visible = true;
			this.listBoxControl_process.Items.Clear();
			this._dofusHunt.ListRunningPrograms(this.listBoxControl_process);
			this.timer_process.Start();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00002779 File Offset: 0x00000979
		private void ValidateLicence()
		{
			if (!this._dofusHunt.checkLicence())
			{
				MessageBox.Show("La licence n'est pas valide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			this.LicenceIsOk();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000CDA4 File Offset: 0x0000AFA4
		private void FormProcess_Load(object sender, EventArgs e)
		{
			if (this._dofusHunt.SkinIsDark() == "False")
			{
				UserLookAndFeel.Default.SkinName = "Metropolis";
			}
			else
			{
				UserLookAndFeel.Default.SkinName = "Metropolis Dark";
			}
			if (!this._dofusHunt.checkLicence())
			{
				this.panelControl_Licence.Visible = true;
				this.panelControl_Process.Visible = false;
				return;
			}
			this.LicenceIsOk();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000027A2 File Offset: 0x000009A2
		private void simpleButton_getCode_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this._dofusHunt.GetPcIdentifier());
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000027B4 File Offset: 0x000009B4
		private void simpleButton_setLicence_Click(object sender, EventArgs e)
		{
			this.LicenceIsOk();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000027BC File Offset: 0x000009BC
		private void simpleButton_actu_Click(object sender, EventArgs e)
		{
			this.ActuProcess();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000027BC File Offset: 0x000009BC
		private void timer_process_Tick(object sender, EventArgs e)
		{
			this.ActuProcess();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000027C4 File Offset: 0x000009C4
		private void listBoxControl_process_DoubleClick(object sender, EventArgs e)
		{
			this.SelectProcess();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000027C4 File Offset: 0x000009C4
		private void simpleButton_select_Click(object sender, EventArgs e)
		{
			this.SelectProcess();
		}

		// Token: 0x040000CD RID: 205
		private DofusHunt _dofusHunt;

		// Token: 0x040000CE RID: 206
		private readonly string _keyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt");
	}
}
