using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Dofus_Hunt.Properties
{
	// Token: 0x0200001A RID: 26
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00002579 File Offset: 0x00000779
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400014B RID: 331
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
