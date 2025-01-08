using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Dof_Hunt
{
	// Token: 0x02000004 RID: 4
	[NullableContext(1)]
	[Nullable(0)]
	public class HuntData
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002FCC File Offset: 0x000011CC
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002FD4 File Offset: 0x000011D4
		public string startX { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002FDD File Offset: 0x000011DD
		// (set) Token: 0x0600001E RID: 30 RVA: 0x00002FE5 File Offset: 0x000011E5
		public string startY { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002FEE File Offset: 0x000011EE
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00002FF6 File Offset: 0x000011F6
		public string direction { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002FFF File Offset: 0x000011FF
		// (set) Token: 0x06000022 RID: 34 RVA: 0x00003007 File Offset: 0x00001207
		public List<IndiceData> data { get; set; }
	}
}
