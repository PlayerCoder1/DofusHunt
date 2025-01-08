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
	// Token: 0x02000004 RID: 4
	public partial class FormProcess : XtraForm
	{
		// Token: 0x06000046 RID: 70 RVA: 0x0000B85D File Offset: 0x00009A5D
		public FormProcess()
		{
			this.InitializeComponent();
			this._Dofus_Hunt = new Dofus_Hunt();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000B898 File Offset: 0x00009A98
		private void simpleButton_Process_CodeLicence_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.DofusHuntLicence.GetPcIdentifier());
		}

		// Token: 0x06000048 RID: 72
		private void simpleButton_Process_SetLicence_Click(object sender, EventArgs e)
		{
			this.LicenceIsOk();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000B9BC File Offset: 0x00009BBC
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

		// Token: 0x0600004A RID: 74 RVA: 0x0000BA38 File Offset: 0x00009C38
		private void SelectProcess()
		{
			if (this.listBoxControl_Process_Process.SelectedItem != null)
			{
				new FormHome(this.listBoxControl_Process_Process.SelectedItem.ToString()).Show();
				base.Hide();
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000BA68 File Offset: 0x00009C68
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

		// Token: 0x0600004C RID: 76 RVA: 0x0000BAC4 File Offset: 0x00009CC4
		private void LicenceIsOk()
		{
			this.panelControl_Process_Licence.Visible = false;
			this.panelControl_Process_List.Visible = true;
			this.timer_Process_Process.Start();
			this.listBoxControl_Process_Process.Items.Clear();
			this.ListRunningPrograms(this.listBoxControl_Process_Process);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000BB10 File Offset: 0x00009D10
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

		// Token: 0x0600004E RID: 78 RVA: 0x0000BB80 File Offset: 0x00009D80
		private void simpleButton_Process_Actu_Click(object sender, EventArgs e)
		{
			this.ActuProcess();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000BB88 File Offset: 0x00009D88
		private void timer_Process_Process_Tick(object sender, EventArgs e)
		{
			this.ActuProcess();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000BB90 File Offset: 0x00009D90
		private void simpleButton_Process_Select_Click(object sender, EventArgs e)
		{
			this.SelectProcess();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000BB98 File Offset: 0x00009D98
		private void listBoxControl_Process_Process_DoubleClick(object sender, EventArgs e)
		{
			this.SelectProcess();
		}

		// Token: 0x040000DA RID: 218
		private Licence DofusHuntLicence = new Licence();

		// Token: 0x040000DB RID: 219
		private Dofus_Hunt _Dofus_Hunt;

		// Token: 0x040000DC RID: 220
		private readonly string _keyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt");
	}
}
