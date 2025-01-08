using System;
using System.Windows.Forms;

namespace Dofus_Hunt
{
	// Token: 0x02000005 RID: 5
	internal static class Program
	{
		// Token: 0x06000054 RID: 84 RVA: 0x0000C22F File Offset: 0x0000A42F
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormProcess());
		}
	}
}
