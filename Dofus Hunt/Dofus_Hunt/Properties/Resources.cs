using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Dofus_Hunt.Properties
{
	// Token: 0x02000019 RID: 25
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000093 RID: 147 RVA: 0x000021AC File Offset: 0x000003AC
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000094 RID: 148 RVA: 0x000024D0 File Offset: 0x000006D0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Dofus_Hunt.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000095 RID: 149 RVA: 0x000024FC File Offset: 0x000006FC
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00002503 File Offset: 0x00000703
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000097 RID: 151 RVA: 0x0000250B File Offset: 0x0000070B
		internal static Bitmap logo
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("logo", Resources.resourceCulture);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00002526 File Offset: 0x00000726
		internal static Bitmap logo_64x64
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("logo 64x64", Resources.resourceCulture);
			}
		}

		// Token: 0x04000135 RID: 309
		private static ResourceManager resourceMan;

		// Token: 0x04000136 RID: 310
		private static CultureInfo resourceCulture;
	}
}
