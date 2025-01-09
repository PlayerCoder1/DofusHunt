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
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002FF0 File Offset: 0x000011F0
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002FF8 File Offset: 0x000011F8
		public string startX { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00003001 File Offset: 0x00001201
		// (set) Token: 0x0600001E RID: 30 RVA: 0x00003009 File Offset: 0x00001209
		public string startY { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00003012 File Offset: 0x00001212
		// (set) Token: 0x06000020 RID: 32 RVA: 0x0000301A File Offset: 0x0000121A
		public string direction { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00003023 File Offset: 0x00001223
		// (set) Token: 0x06000022 RID: 34 RVA: 0x0000302B File Offset: 0x0000122B
		public List<IndiceData> data { get; set; }
	}
}
