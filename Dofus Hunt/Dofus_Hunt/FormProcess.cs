using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Dofus_Hunt.Properties;
using Dof_Hunt;

namespace Dofus_Hunt
{
	// Token: 0x02000016 RID: 22
	public partial class FormProcess : XtraForm
	{
		// Token: 0x06000087 RID: 135 RVA: 0x000023F8 File Offset: 0x000005F8
		public FormProcess()
		{
			this.InitializeComponent();
			this._Dofus_Hunt = new Dofus_Hunt();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00002433 File Offset: 0x00000633
		private void simpleButton_Process_CodeLicence_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.DofusHuntLicence.GetPcIdentifier());
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00002445 File Offset: 0x00000645
		private void simpleButton_Process_SetLicence_Click(object sender, EventArgs e)
		{
			this.LicenceIsOk();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000F45C File Offset: 0x0000D65C
		private void ListRunningPrograms(ListBoxControl listBoxControl)
		{
			foreach (Process process in from p in Process.GetProcesses()
				where p.MainWindowHandle != IntPtr.Zero && !string.IsNullOrWhiteSpace(p.MainWindowTitle)
				select p)
			{
				string windowTitle = process.MainWindowTitle;
				listBoxControl.Items.Add(windowTitle);
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000244D File Offset: 0x0000064D
		private void SelectProcess()
		{
			if (this.listBoxControl_Process_Process.SelectedItem != null)
			{
				new FormHome(this.listBoxControl_Process_Process.SelectedItem.ToString()).Show();
				base.Hide();
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000F4D8 File Offset: 0x0000D6D8
		private void ActuProcess()
		{
			string selectedItem = this.listBoxControl_Process_Process.SelectedItem as string;
			this.listBoxControl_Process_Process.Items.Clear();
			this.ListRunningPrograms(this.listBoxControl_Process_Process);
			if (selectedItem != null && this.listBoxControl_Process_Process.Items.Contains(selectedItem))
			{
				this.listBoxControl_Process_Process.SelectedItem = selectedItem;
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000F534 File Offset: 0x0000D734
		private void LicenceIsOk()
		{
			this.panelControl_Process_Licence.Visible = false;
			this.panelControl_Process_List.Visible = true;
			this.timer_Process_Process.Start();
			this.listBoxControl_Process_Process.Items.Clear();
			this.ListRunningPrograms(this.listBoxControl_Process_Process);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000F580 File Offset: 0x0000D780
		private void FormProcess_Load(object sender, EventArgs e)
		{
			if (this._Dofus_Hunt.SkinIsDark() == "False")
			{
				UserLookAndFeel.Default.SkinName = "Metropolis";
			}
			else
			{
				UserLookAndFeel.Default.SkinName = "Metropolis Dark";
			}
			if (!this.DofusHuntLicence.checkLicence())
			{
				this.panelControl_Process_Licence.Visible = true;
				this.panelControl_Process_List.Visible = false;
				return;
			}
			this.LicenceIsOk();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000247C File Offset: 0x0000067C
		private void simpleButton_Process_Actu_Click(object sender, EventArgs e)
		{
			this.ActuProcess();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000247C File Offset: 0x0000067C
		private void timer_Process_Process_Tick(object sender, EventArgs e)
		{
			this.ActuProcess();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00002484 File Offset: 0x00000684
		private void simpleButton_Process_Select_Click(object sender, EventArgs e)
		{
			this.SelectProcess();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00002484 File Offset: 0x00000684
		private void listBoxControl_Process_Process_DoubleClick(object sender, EventArgs e)
		{
			this.SelectProcess();
		}

		// Token: 0x04000139 RID: 313
		private Licence DofusHuntLicence = new Licence();

		// Token: 0x0400013A RID: 314
		private Dofus_Hunt _Dofus_Hunt;

		// Token: 0x0400013B RID: 315
		private readonly string _keyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt");
	}
}
