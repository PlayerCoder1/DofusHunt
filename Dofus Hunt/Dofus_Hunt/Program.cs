using System;
using System.Windows.Forms;

namespace Dofus_Hunt
{
	// Token: 0x02000020 RID: 32
	internal static class Program
	{
		// Token: 0x060000B9 RID: 185 RVA: 0x000027EB File Offset: 0x000009EB
		[STAThread]
		private static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormProcess());
		}
	}
}
