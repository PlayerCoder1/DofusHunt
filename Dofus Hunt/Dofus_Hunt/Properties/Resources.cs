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
	// Token: 0x02000006 RID: 6
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000055 RID: 85 RVA: 0x0000C246 File Offset: 0x0000A446
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000056 RID: 86 RVA: 0x0000C24E File Offset: 0x0000A44E
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
		// (get) Token: 0x06000057 RID: 87 RVA: 0x0000C27A File Offset: 0x0000A47A
		// (set) Token: 0x06000058 RID: 88 RVA: 0x0000C281 File Offset: 0x0000A481
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
		// (get) Token: 0x06000059 RID: 89 RVA: 0x0000C289 File Offset: 0x0000A489
		internal static Bitmap discord_brands_solid__1_
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("discord-brands-solid (1)", Resources.resourceCulture);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000C2A4 File Offset: 0x0000A4A4
		internal static Bitmap logo
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("logo", Resources.resourceCulture);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600005B RID: 91 RVA: 0x0000C2BF File Offset: 0x0000A4BF
		internal static Bitmap logo_64x64
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("logo 64x64", Resources.resourceCulture);
			}
		}

		// Token: 0x040000E8 RID: 232
		private static ResourceManager resourceMan;

		// Token: 0x040000E9 RID: 233
		private static CultureInfo resourceCulture;
	}
}
