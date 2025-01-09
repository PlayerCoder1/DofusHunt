using System;
using System.Windows.Forms;

namespace Dofus_Hunt
{
	// Token: 0x02000018 RID: 24
	internal static class Program
	{
		// Token: 0x06000098 RID: 152 RVA: 0x000024D6 File Offset: 0x000006D6
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormProcess());
		}
	}
}
