using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Dofus_Hunt.Properties
{
	// Token: 0x02000022 RID: 34
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00002988 File Offset: 0x00000B88
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040000DC RID: 220
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
