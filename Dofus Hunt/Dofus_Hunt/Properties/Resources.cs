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
		// Token: 0x06000099 RID: 153 RVA: 0x000021AC File Offset: 0x000003AC
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600009A RID: 154 RVA: 0x000024ED File Offset: 0x000006ED
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
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00002519 File Offset: 0x00000719
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00002520 File Offset: 0x00000720
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
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00002528 File Offset: 0x00000728
		internal static Bitmap discord_brands_solid__1_
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("discord-brands-solid (1)", Resources.resourceCulture);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00002543 File Offset: 0x00000743
		internal static Bitmap logo
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("logo", Resources.resourceCulture);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600009F RID: 159 RVA: 0x0000255E File Offset: 0x0000075E
		internal static Bitmap logo_64x64
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("logo 64x64", Resources.resourceCulture);
			}
		}

		// Token: 0x04000149 RID: 329
		private static ResourceManager resourceMan;

		// Token: 0x0400014A RID: 330
		private static CultureInfo resourceCulture;
	}
}
