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
		// Token: 0x06000081 RID: 129 RVA: 0x000023DB File Offset: 0x000005DB
		public FormProcess()
		{
			this.InitializeComponent();
			this._Dofus_Hunt = new Dofus_Hunt();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00002416 File Offset: 0x00000616
		private void simpleButton_Process_CodeLicence_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.DofusHuntLicence.GetPcIdentifier());
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00002428 File Offset: 0x00000628
		private void simpleButton_Process_SetLicence_Click(object sender, EventArgs e)
		{
			this.LicenceIsOk();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000E524 File Offset: 0x0000C724
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

		// Token: 0x06000085 RID: 133 RVA: 0x00002430 File Offset: 0x00000630
		private void SelectProcess()
		{
			if (this.listBoxControl_Process_Process.SelectedItem != null)
			{
				new FormHome(this.listBoxControl_Process_Process.SelectedItem.ToString()).Show();
				base.Hide();
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000E5A0 File Offset: 0x0000C7A0
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

		// Token: 0x06000087 RID: 135 RVA: 0x0000E5FC File Offset: 0x0000C7FC
		private void LicenceIsOk()
		{
			this.panelControl_Process_Licence.Visible = false;
			this.panelControl_Process_List.Visible = true;
			this.timer_Process_Process.Start();
			this.listBoxControl_Process_Process.Items.Clear();
			this.ListRunningPrograms(this.listBoxControl_Process_Process);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000E648 File Offset: 0x0000C848
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

		// Token: 0x06000089 RID: 137 RVA: 0x0000245F File Offset: 0x0000065F
		private void simpleButton_Process_Actu_Click(object sender, EventArgs e)
		{
			this.ActuProcess();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000245F File Offset: 0x0000065F
		private void timer_Process_Process_Tick(object sender, EventArgs e)
		{
			this.ActuProcess();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00002467 File Offset: 0x00000667
		private void simpleButton_Process_Select_Click(object sender, EventArgs e)
		{
			this.SelectProcess();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00002467 File Offset: 0x00000667
		private void listBoxControl_Process_Process_DoubleClick(object sender, EventArgs e)
		{
			this.SelectProcess();
		}

		// Token: 0x04000125 RID: 293
		private Licence DofusHuntLicence = new Licence();

		// Token: 0x04000126 RID: 294
		private Dofus_Hunt _Dofus_Hunt;

		// Token: 0x04000127 RID: 295
		private readonly string _keyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt");
	}
}
