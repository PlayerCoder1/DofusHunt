using System;
using System.Windows.Forms;

namespace Dofus_Hunt
{
	// Token: 0x02000018 RID: 24
	internal static class Program
	{
		// Token: 0x06000092 RID: 146 RVA: 0x000024B9 File Offset: 0x000006B9
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormProcess());
		}
	}
}
