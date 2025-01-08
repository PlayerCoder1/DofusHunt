using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Animation;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.ToastNotifications;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using DevExpress.XtraWaitForm;
using Dofus_Hunt.Properties;
using Dof_Hunt;
using Newtonsoft.Json.Linq;

namespace Dofus_Hunt
{
	// Token: 0x02000003 RID: 3
	public partial class FormHome : XtraForm
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000208C File Offset: 0x0000028C
		public FormHome(string Dofus)
		{
			this.InitializeComponent();
			this._dofus = Dofus;
			this._Dofus_Hunt = new Dofus_Hunt();
			this._Hunt = new Hunt(this._dofus, "False", 0);
			this.tokenTimer = new Timer();
			this.tokenTimer.Interval = 3600000;
			this.tokenTimer.Tick += this.Timer_Tick;
			this.tokenTimer.Start();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002124 File Offset: 0x00000324
		private async void FormHome_Load(object sender, EventArgs e)
		{
			if (this._Dofus_Hunt.CreateDefaultConfigFileIfNotExists(FormHome._configPath + "/appSettings.xml"))
			{
				this._Dofus_Hunt.AddLog("Création de la configuration par défaut.");
			}
			else
			{
				this._Dofus_Hunt.AddLog("Chargement de la configuration.");
			}
			this.getConfig();
			this.initConfig();
			if (this._HuntAutoIndice_similarityThreshold == 0)
			{
				this._HuntAutoIndice_similarityThreshold = 70;
			}
			this._Hunt = new Hunt(this._dofus, this._advancedLog, this._HuntAutoIndice_similarityThreshold);
			if (this._notify == "True")
			{
				this.ConfigToastNotifications();
			}
			if (this._dark == "False")
			{
				UserLookAndFeel.Default.SkinName = "Metropolis";
			}
			else
			{
				UserLookAndFeel.Default.SkinName = "Metropolis Dark";
			}
			this._version = this._Dofus_Hunt.ReadVersionFromFile(FormHome.RevisionFilePath);
			this.labelControl_Hunt_Version.Text = "Version : " + this._version;
			if (this._Dofus_Hunt.GetVersion() != this._version)
			{
				this.accordionControlElement_SubMenu_Config_Update.Visible = true;
				if (this._notify == "True")
				{
					this.toastNotificationsManager.ShowNotification("App_Update");
				}
			}
			string _versionDHU = this._Dofus_Hunt.ReadVersionFromFile(FormHome.RevisionDHUFilePath);
			string versionUpdate = this._Dofus_Hunt.GetVersionUpdate();
			Application.DoEvents();
			if (versionUpdate != _versionDHU && this._updateDHU == "True")
			{
				try
				{
					Dofus_Hunt.UpdateInfo updateInfo = Dofus_Hunt.GetUpdateInfo();
					if (updateInfo != null)
					{
						string zipPath = await this._Dofus_Hunt.DownloadUpdateAsync(updateInfo.updateUrlUpdate);
						this._Dofus_Hunt.ApplyUpdate(zipPath);
						this._Dofus_Hunt.AddLog("Mise à jour de l'updateur effectuée.");
					}
				}
				catch (Exception ex)
				{
					this._Dofus_Hunt.AddLog("Erreur lors de la mise à jour de l'updateur : " + ex.Message);
				}
			}
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.Image = Image.FromFile("ressources/img/fleche_haut.png");
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.Image = Image.FromFile("ressources/img/fleche_droite.png");
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.Image = Image.FromFile("ressources/img/fleche_bas.png");
			this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.Image = Image.FromFile("ressources/img/fleche_gauche.png");
			this.pictureBox_Hunt_Config_Hunt_Template_Coche.Image = Image.FromFile("ressources/img/coche_blanche.png");
			this.pictureBox_Hunt_Config_Hunt_Template_Start.Image = Image.FromFile("ressources/img/depart_template.png");
			this.pictureBox_Hunt_Config_Hunt_Template_Level.Image = Image.FromFile("ressources/img/niveau.png");
			await Task.Run(delegate
			{
				this._Hunt.GetToken();
				this._token = this._Hunt.Token;
				this.tokenTimer.Start();
				if (this._googleVision == "True")
				{
					this._googleAPI = this._Hunt.GetGoogleAPIKey("google.xml");
				}
			});
			this.panelControl_Hunt_Init.Visible = false;
			this.panelControl_Home.Visible = true;
			this.accordionControl1.Enabled = true;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000215C File Offset: 0x0000035C
		public async Task<string> DownloadUpdateAsync(string updateUrl)
		{
			string tempPath = Path.Combine(Path.GetTempPath(), "update.zip");
			using (WebClient client = new WebClient())
			{
				TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
				client.DownloadFileCompleted += delegate([Nullable(2)] object s, AsyncCompletedEventArgs e)
				{
					if (e.Error != null)
					{
						tcs.SetException(new Exception("Erreur lors du téléchargement : " + e.Error.Message));
						return;
					}
					tcs.SetResult(true);
				};
				client.DownloadFileAsync(new Uri(updateUrl), tempPath);
				await tcs.Task;
			}
			WebClient client = null;
			return tempPath;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021A0 File Offset: 0x000003A0
		private void ConfigToastNotifications()
		{
			this.toastNotificationsManager.ApplicationId = "Dofus Hunt";
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("App_Update", Resources.logo_64x64, "Dofus Hunt", this._notify_App_Update, "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("App_Connect", Resources.logo_64x64, "Dofus Hunt", this._notify_App_Connect, "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("App_GetData", Resources.logo_64x64, "Dofus Hunt", this._notify_App_GetData, "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("App_Restart", Resources.logo_64x64, "Dofus Hunt", this._notify_App_Restart, "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("Hunt_NoData", Resources.logo_64x64, "Dofus Hunt", this._notify_Hunt_NoData, "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("Indice_OK", Resources.logo_64x64, "Dofus Hunt", this._notify_Indice_OK, "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("Indice_KO", Resources.logo_64x64, "Dofus Hunt", this._notify_Indice_KO, "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("Indice_Phorreur", Resources.logo_64x64, "Dofus Hunt", this._notify_Indice_Phorreur, "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("Indice_Correct", Resources.logo_64x64, "Dofus Hunt", this._notify_Indice_Correct, "", ToastNotificationTemplate.ImageAndText02));
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002376 File Offset: 0x00000576
		private void Timer_Tick(object sender, EventArgs e)
		{
			this._Hunt.GetToken();
			this._token = this._Hunt.Token;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002395 File Offset: 0x00000595
		private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.saveConfig();
			if (this._deleteLog == "True")
			{
				this._Dofus_Hunt.DeleteOldLogFiles(3);
			}
			Application.Exit();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000023C0 File Offset: 0x000005C0
		private void getConfig()
		{
			string configFilePath = FormHome._configPath + "/appSettings.xml";
			this._Dofus_Hunt.EnsureConfigParameters(configFilePath);
			this._opacity = this._Dofus_Hunt.GetConfigValue(configFilePath, "Opacity");
			if (string.IsNullOrEmpty(this._opacity))
			{
				this._opacity = "100";
			}
			this._alwaysonscreen = this._Dofus_Hunt.GetConfigValue(configFilePath, "AlwaysOnScreen");
			this._dark = this._Dofus_Hunt.GetConfigValue(configFilePath, "Dark");
			this._advancedLog = this._Dofus_Hunt.GetConfigValue(configFilePath, "AdvancedLog");
			this._deleteTempFiles = this._Dofus_Hunt.GetConfigValue(configFilePath, "DeleteTempFiles");
			this._deleteLog = this._Dofus_Hunt.GetConfigValue(configFilePath, "DeleteLogs");
			this._notify = this._Dofus_Hunt.GetConfigValue(configFilePath, "Notify");
			this._updateDHU = this._Dofus_Hunt.GetConfigValue(configFilePath, "UpdateDHU");
			this._googleVision = this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAuto_GoogleVision");
			this._modeOffline = this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAuto_Offline");
			this._notify_App_Connect = this._Dofus_Hunt.GetConfigValue(configFilePath, "Notify_App_Connect");
			this._notify_App_GetData = this._Dofus_Hunt.GetConfigValue(configFilePath, "Notify_App_GetData");
			this._notify_App_Restart = this._Dofus_Hunt.GetConfigValue(configFilePath, "Notify_App_Restart");
			this._notify_Hunt_NoData = this._Dofus_Hunt.GetConfigValue(configFilePath, "Notify_Hunt_NoData");
			this._notify_Indice_OK = this._Dofus_Hunt.GetConfigValue(configFilePath, "Notify_Indice_OK");
			this._notify_Indice_KO = this._Dofus_Hunt.GetConfigValue(configFilePath, "Notify_Indice_KO");
			this._notify_Indice_Phorreur = this._Dofus_Hunt.GetConfigValue(configFilePath, "Notify_Indice_Phorreur");
			this._notify_Indice_Correct = this._Dofus_Hunt.GetConfigValue(configFilePath, "Notify_Indice_Correct");
			this._notify_App_Update = this._Dofus_Hunt.GetConfigValue(configFilePath, "Notify_App_Update");
			this._HuntAutoPosition_X = int.Parse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoPosition_X"));
			this._HuntAutoPosition_Y = int.Parse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoPosition_Y"));
			this._HuntAutoPosition_Width = int.Parse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoPosition_width"));
			this._HuntAutoPosition_Height = int.Parse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoPosition_height"));
			this._HuntAutoPosition_largeurTexte = int.Parse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoPosition_largeurTexte"));
			this._HuntAutoPosition_hauteurTexte = int.Parse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoPosition_hauteurTexte"));
			double.TryParse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoPosition_threshold"), out this._HuntAutoPosition_Threshold);
			double.TryParse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoIndice_OCRStart"), out this._HuntAutoIndice_Threshold_Start);
			double.TryParse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoIndice_OCRCoche"), out this._HuntAutoIndice_Threshold_Coche);
			double.TryParse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoIndice_OCRArrow"), out this._HuntAutoIndice_Threshold_Arrow);
			this._HuntAutoIndice_largeurTexte_Start = int.Parse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoIndice_LStart"));
			this._HuntAutoIndice_hauteurTexte_Start = int.Parse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoIndice_HStart"));
			this._HuntAutoIndice_largeurTexte_Coche = int.Parse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoIndice_LIndice"));
			this._HuntAutoIndice_hauteurTexte_Coche = int.Parse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoIndice_HIndice"));
			this._HuntAutoIndice_similarityThreshold = int.Parse(this._Dofus_Hunt.GetConfigValue(configFilePath, "HuntAutoIndice_similarityThreshold"));
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002760 File Offset: 0x00000960
		private void initConfig()
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(this.initConfig));
				return;
			}
			double opacityDouble;
			double.TryParse(this._opacity, out opacityDouble);
			int opacityInt;
			int.TryParse(this._opacity, out opacityInt);
			if (opacityDouble >= 0.0 && opacityDouble <= 100.0)
			{
				base.Opacity = opacityDouble / 100.0;
				this.trackBarControl_Hunt_Config_Logiciel_Opacity.Value = opacityInt;
			}
			else
			{
				base.Opacity = 100.0;
				this.trackBarControl_Hunt_Config_Logiciel_Opacity.Value = 100;
			}
			if (this._alwaysonscreen == "True")
			{
				base.TopMost = true;
				this.checkEdit_Hunt_Config_Logiciel_Ecran.Checked = true;
			}
			else
			{
				base.TopMost = false;
			}
			if (this._advancedLog == "True")
			{
				this.checkEdit_Hunt_Config_Logiciel_LogAvance.Checked = true;
			}
			if (this._dark == "True")
			{
				this.checkEdit_Hunt_Config_Logiciel_Theme.Checked = true;
			}
			if (this._deleteTempFiles == "True")
			{
				this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Checked = true;
			}
			if (this._deleteLog == "True")
			{
				this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Checked = true;
			}
			if (this._notify == "True")
			{
				this.checkEdit_Hunt_Config_Logiciel_Notifications.Checked = true;
			}
			if (this._updateDHU == "True")
			{
				this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Checked = true;
			}
			if (this._googleVision == "True")
			{
				this.checkEdit_Hunt_Config_UseGoogleVision.Checked = true;
			}
			if (this._modeOffline == "True")
			{
				this.checkEdit_Hunt_Config_Offline.Checked = true;
			}
			this.textEdit_Indices_CorrectIndice.Text = this._notify_Indice_Correct;
			this.textEdit_Indices_IndiceKO.Text = this._notify_Indice_KO;
			this.textEdit_Indices_IndiceOK.Text = this._notify_Indice_OK;
			this.textEdit_Indices_Phorreur.Text = this._notify_Indice_Phorreur;
			this.textEdit_Notify_Hunt_NoData.Text = this._notify_Hunt_NoData;
			this.textEdit_Notify_App_PbCo.Text = this._notify_App_Connect;
			this.textEdit_Notify_App_PbData.Text = this._notify_App_GetData;
			this.textEdit_Notify_App_Restart.Text = this._notify_App_Restart;
			this.textEdit_Notify_App_Update.Text = this._notify_App_Update;
			this.textEdit_Hunt_Config_Hunt_Position_X.Text = this._HuntAutoPosition_X.ToString();
			this.textEdit_Hunt_Config_Hunt_Position_Y.Text = this._HuntAutoPosition_Y.ToString();
			this.textEdit_Hunt_Config_Hunt_Position_width.Text = this._HuntAutoPosition_Width.ToString();
			this.textEdit_Hunt_Config_Hunt_Position_height.Text = this._HuntAutoPosition_Height.ToString();
			this.textEdit_Hunt_Config_Hunt_Position_threshold.Text = this._HuntAutoPosition_Threshold.ToString();
			this.textEdit_Hunt_Config_Hunt_Position_largeurTexte.Text = this._HuntAutoPosition_largeurTexte.ToString();
			this.textEdit_Hunt_Config_Hunt_Position_hauteurTexte.Text = this._HuntAutoPosition_hauteurTexte.ToString();
			this.textEdit_Hunt_Config_Hunt_Position_threshold.Text = this._HuntAutoPosition_Threshold.ToString();
			this.textEdit_Hunt_Config_Hunt_Indice_OCRStart.Text = this._HuntAutoIndice_Threshold_Start.ToString();
			this.textEdit_Hunt_Config_Hunt_Indice_OCRCoche.Text = this._HuntAutoIndice_Threshold_Coche.ToString();
			this.textEdit_Hunt_Config_Hunt_Indice_OCRFleche.Text = this._HuntAutoIndice_Threshold_Arrow.ToString();
			this.textEdit_Hunt_Config_Hunt_Indice_LStart.Text = this._HuntAutoIndice_largeurTexte_Start.ToString();
			this.textEdit_Hunt_Config_Hunt_Indice_HStart.Text = this._HuntAutoIndice_hauteurTexte_Start.ToString();
			this.textEdit_Hunt_Config_Hunt_Indice_LIndice.Text = this._HuntAutoIndice_largeurTexte_Coche.ToString();
			this.textEdit_Hunt_Config_Hunt_Indice_HIndice.Text = this._HuntAutoIndice_hauteurTexte_Coche.ToString();
			this.textEdit_Hunt_Config_Hunt_Indice_Detection.Text = this._HuntAutoIndice_similarityThreshold.ToString();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002B10 File Offset: 0x00000D10
		private void saveConfig()
		{
			int opacityInt;
			int.TryParse(this._opacity, out opacityInt);
			if (opacityInt != this.trackBarControl_Hunt_Config_Logiciel_Opacity.Value)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Opacity", this.trackBarControl_Hunt_Config_Logiciel_Opacity.Value.ToString());
			}
			bool alwaysOnScreenValue;
			bool.TryParse(this._alwaysonscreen, out alwaysOnScreenValue);
			if (this.checkEdit_Hunt_Config_Logiciel_Ecran.Checked != alwaysOnScreenValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "AlwaysOnScreen", this.checkEdit_Hunt_Config_Logiciel_Ecran.Checked.ToString());
			}
			bool logAdvencedValue;
			bool.TryParse(this._advancedLog, out logAdvencedValue);
			if (this.checkEdit_Hunt_Config_Logiciel_LogAvance.Checked != logAdvencedValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "AdvancedLog", this.checkEdit_Hunt_Config_Logiciel_LogAvance.Checked.ToString());
			}
			bool darkValue;
			bool.TryParse(this._dark, out darkValue);
			if (this.checkEdit_Hunt_Config_Logiciel_Theme.Checked != darkValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Dark", this.checkEdit_Hunt_Config_Logiciel_Theme.Checked.ToString());
			}
			bool deleteTempFilesValue;
			bool.TryParse(this._deleteTempFiles, out deleteTempFilesValue);
			if (this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Checked != deleteTempFilesValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "DeleteTempFiles", this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Checked.ToString());
			}
			bool deleteLogValue;
			bool.TryParse(this._deleteLog, out deleteLogValue);
			if (this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Checked != deleteLogValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "DeleteLogs", this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Checked.ToString());
			}
			bool notifyValue;
			bool.TryParse(this._notify, out notifyValue);
			if (this.checkEdit_Hunt_Config_Logiciel_Notifications.Checked != notifyValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify", this.checkEdit_Hunt_Config_Logiciel_Notifications.Checked.ToString());
			}
			bool updateDHUValue;
			bool.TryParse(this._updateDHU, out updateDHUValue);
			if (this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Checked != updateDHUValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "UpdateDHU", this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Checked.ToString());
			}
			bool googleVisionValue;
			bool.TryParse(this._googleVision, out googleVisionValue);
			if (this.checkEdit_Hunt_Config_UseGoogleVision.Checked != googleVisionValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAuto_GoogleVision", this.checkEdit_Hunt_Config_UseGoogleVision.Checked.ToString());
			}
			bool modeOfflineValue;
			bool.TryParse(this._modeOffline, out modeOfflineValue);
			if (this.checkEdit_Hunt_Config_Offline.Checked != modeOfflineValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAuto_Offline", this.checkEdit_Hunt_Config_Offline.Checked.ToString());
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002E3C File Offset: 0x0000103C
		private void accordionControlElement_SubMenu_Config_Logiciel_Click(object sender, EventArgs e)
		{
			this.panelControl_Hunt_Indice.Visible = false;
			this.panelControl_Hunt_Init.Visible = false;
			this.panelControl_Hunt_Notifications.Visible = false;
			this.panelControl_Hunt_Config_Logiciel.Visible = true;
			this.panelControl_Hunt_Debug.Visible = false;
			this.panelControl_Hunt_ConfigHuntAuto.Visible = false;
			this.panelControl_Hunt_Hunt.Visible = false;
			this.panelControl_Hunt_HuntAuto.Visible = false;
			this.panelControl_Home.Visible = false;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002EB8 File Offset: 0x000010B8
		private void accordionControlElement_SubMenu_Config_Indice_Click(object sender, EventArgs e)
		{
			this.panelControl_Hunt_Config_Logiciel.Visible = false;
			this.panelControl_Hunt_Indice.Visible = true;
			this.panelControl_Hunt_Notifications.Visible = false;
			this.panelControl_Hunt_Init.Visible = false;
			this.panelControl_Hunt_Debug.Visible = false;
			this.panelControl_Hunt_ConfigHuntAuto.Visible = false;
			this.panelControl_Hunt_Hunt.Visible = false;
			this.panelControl_Hunt_HuntAuto.Visible = false;
			this.panelControl_Home.Visible = false;
			this.dataGridView_Hunt_Indice_List.Rows.Clear();
			try
			{
				foreach (Dofus_Hunt.Correction correction in this._Dofus_Hunt.LoadCorrections())
				{
					this.dataGridView_Hunt_Indice_List.Rows.Add(new object[] { correction.Erroneous, correction.Correct });
				}
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors du chargement de la correction des indices :\n" + ex.Message);
				MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002FFC File Offset: 0x000011FC
		private void accordionControlElement_SubMenu_Config_Notif_Click(object sender, EventArgs e)
		{
			this.panelControl_Hunt_Config_Logiciel.Visible = false;
			this.panelControl_Hunt_Indice.Visible = false;
			this.panelControl_Hunt_Notifications.Visible = true;
			this.panelControl_Hunt_Init.Visible = false;
			this.panelControl_Hunt_Debug.Visible = false;
			this.panelControl_Hunt_ConfigHuntAuto.Visible = false;
			this.panelControl_Hunt_Hunt.Visible = false;
			this.panelControl_Hunt_HuntAuto.Visible = false;
			this.panelControl_Home.Visible = false;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00003078 File Offset: 0x00001278
		private void accordionControlElement_SubMenu_Config_Debug_Click(object sender, EventArgs e)
		{
			this.panelControl_Hunt_Config_Logiciel.Visible = false;
			this.panelControl_Hunt_Indice.Visible = false;
			this.panelControl_Hunt_Notifications.Visible = false;
			this.panelControl_Hunt_Init.Visible = false;
			this.panelControl_Hunt_Debug.Visible = true;
			this.panelControl_Hunt_ConfigHuntAuto.Visible = false;
			this.panelControl_Hunt_Hunt.Visible = false;
			this.panelControl_Hunt_HuntAuto.Visible = false;
			this.panelControl_Home.Visible = false;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000030F4 File Offset: 0x000012F4
		private void accordionControlElement_SubMenu_Config_HuntAuto_Click(object sender, EventArgs e)
		{
			this.panelControl_Hunt_Config_Logiciel.Visible = false;
			this.panelControl_Hunt_Indice.Visible = false;
			this.panelControl_Hunt_Notifications.Visible = false;
			this.panelControl_Hunt_Init.Visible = false;
			this.panelControl_Hunt_Debug.Visible = false;
			this.panelControl_Hunt_ConfigHuntAuto.Visible = true;
			this.panelControl_Hunt_Hunt.Visible = false;
			this.panelControl_Hunt_HuntAuto.Visible = false;
			this.panelControl_Home.Visible = false;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003170 File Offset: 0x00001370
		private void accordionControlElement_SubMenu_Hunt_Click(object sender, EventArgs e)
		{
			this.panelControl_Hunt_Config_Logiciel.Visible = false;
			this.panelControl_Hunt_Indice.Visible = false;
			this.panelControl_Hunt_Notifications.Visible = false;
			this.panelControl_Hunt_Init.Visible = false;
			this.panelControl_Hunt_Debug.Visible = false;
			this.panelControl_Hunt_ConfigHuntAuto.Visible = false;
			this.panelControl_Hunt_Hunt.Visible = true;
			this.panelControl_Hunt_HuntAuto.Visible = false;
			this.panelControl_Home.Visible = false;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000031EC File Offset: 0x000013EC
		private void accordionControlElement_SubMenu_HuntAuto_Click(object sender, EventArgs e)
		{
			this.panelControl_Hunt_Config_Logiciel.Visible = false;
			this.panelControl_Hunt_Indice.Visible = false;
			this.panelControl_Hunt_Notifications.Visible = false;
			this.panelControl_Hunt_Init.Visible = false;
			this.panelControl_Hunt_Debug.Visible = false;
			this.panelControl_Hunt_ConfigHuntAuto.Visible = false;
			this.panelControl_Hunt_Hunt.Visible = false;
			this.panelControl_Hunt_HuntAuto.Visible = true;
			this.panelControl_Home.Visible = false;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003268 File Offset: 0x00001468
		private void trackBarControl_Hunt_Config_Logiciel_Opacity_Click(object sender, EventArgs e)
		{
			int trackBarValue = this.trackBarControl_Hunt_Config_Logiciel_Opacity.Value;
			base.Opacity = (double)trackBarValue / 100.0;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003294 File Offset: 0x00001494
		private void simpleButton_Hunt_Indice_Add_Click(object sender, EventArgs e)
		{
			try
			{
				string detectedText = this.textEdit_Hunt_Indice_Incorrect.Text.Trim();
				string correctedText = this.textEdit_Hunt_Indice_Correct.Text.Trim();
				if (string.IsNullOrEmpty(detectedText) || string.IsNullOrEmpty(correctedText))
				{
					MessageBox.Show("Veuillez remplir les deux champs avant de sauvegarder.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else if (!File.Exists(FormHome._configPath + "/corrections.xml"))
				{
					new XDocument(new object[]
					{
						new XElement("Corrections", new XElement("Correction", new object[]
						{
							new XElement("Erroneous", detectedText),
							new XElement("Correct", correctedText)
						}))
					}).Save(FormHome._configPath + "/corrections.xml");
					if (this._notify == "True")
					{
						this.toastNotificationsManager.ShowNotification("Indice_Correct");
					}
				}
				else
				{
					XDocument doc = XDocument.Load(FormHome._configPath + "/corrections.xml");
					XElement existingCorrection = doc.Descendants("Correction").FirstOrDefault(delegate(XElement x)
					{
						XElement xelement = x.Element("Erroneous");
						if (((xelement != null) ? xelement.Value : null) == detectedText)
						{
							XElement xelement2 = x.Element("Correct");
							return ((xelement2 != null) ? xelement2.Value : null) == correctedText;
						}
						return false;
					});
					if (existingCorrection != null)
					{
						existingCorrection.Element("Correct").Value = correctedText;
						if (this._notify == "True")
						{
							this.toastNotificationsManager.ShowNotification("Indice_Correct");
						}
					}
					else
					{
						doc.Element("Corrections").Add(new XElement("Correction", new object[]
						{
							new XElement("Erroneous", detectedText),
							new XElement("Correct", correctedText)
						}));
						if (this._notify == "True")
						{
							this.toastNotificationsManager.ShowNotification("Indice_Correct");
						}
					}
					doc.Save(FormHome._configPath + "/corrections.xml");
					this.textEdit_Hunt_Indice_Incorrect.Text = (this.textEdit_Hunt_Indice_Correct.Text = "");
				}
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors de l'ajout d'une correction :\n" + ex.Message);
				MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003548 File Offset: 0x00001748
		private async void simpleButton_Hunt_Debug_Token_Click(object sender, EventArgs e)
		{
			await this._Hunt.GetToken();
			this._token = this._Hunt.Token;
			this.textEdit_Hunt_Debug_Token.Text = this._token;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000357F File Offset: 0x0000177F
		private void simpleButton_Hunt_Debug_Capture_Click(object sender, EventArgs e)
		{
			this._Hunt.CaptureGame(FormHome._logPathImg + "/screenshot.png");
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000359C File Offset: 0x0000179C
		private void simpleButton_Hunt_Debug_GetPositionIndice_Click(object sender, EventArgs e)
		{
			string indice = this._Hunt.GetIndice(this._token, this.textEdit_Hunt_Debug_X.Text, this.textEdit_Hunt_Debug_Y.Text, this.textEdit_Hunt_Debug_Dir.Text);
			int currentX = int.Parse(this.textEdit_Hunt_Debug_X.Text);
			int currentY = int.Parse(this.textEdit_Hunt_Debug_Y.Text);
			ValueTuple<int, int, string> position = this._Hunt.GetIndicePosition(indice, this.textEdit_Hunt_Debug_Indice.Text, currentX, currentY);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(109, 6);
			defaultInterpolatedStringHandler.AppendLiteral("L'indice : ");
			defaultInterpolatedStringHandler.AppendFormatted(this.textEdit_Hunt_Debug_Indice.Text);
			defaultInterpolatedStringHandler.AppendLiteral(" qui a comme position de départ [");
			defaultInterpolatedStringHandler.AppendFormatted(this.textEdit_Hunt_Debug_X.Text);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted(this.textEdit_Hunt_Debug_Y.Text);
			defaultInterpolatedStringHandler.AppendLiteral("] vers la direction ");
			defaultInterpolatedStringHandler.AppendFormatted(this.textEdit_Hunt_Debug_Dir.Text);
			defaultInterpolatedStringHandler.AppendLiteral(" a été trouvé !\nPosition trouvée :\nX = ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item1);
			defaultInterpolatedStringHandler.AppendLiteral("\nY = ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item2);
			MessageBox.Show(defaultInterpolatedStringHandler.ToStringAndClear(), "Résultat de la recherche", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000036E4 File Offset: 0x000018E4
		private async void simpleButton_Hunt_Debug_GetPosition_Click(object sender, EventArgs e)
		{
			await Task.Run(delegate
			{
				this._Hunt.DetectCurrentMap(this._HuntAutoPosition_X, this._HuntAutoPosition_Y, this._HuntAutoPosition_Width, this._HuntAutoPosition_Height, this._HuntAutoPosition_Threshold, this._HuntAutoPosition_largeurTexte, this._HuntAutoPosition_hauteurTexte);
			});
			string croppedMapPath = FormHome._logPathImg + "/cropped_map.png";
			if (File.Exists(croppedMapPath))
			{
				string map = await Task.Run<string>(() => this._Hunt.PerformOCRTesseractMap(croppedMapPath));
				int X;
				int Y;
				if (!this._Hunt.ExtractCoordinatesSimple(map, out X, out Y))
				{
					string mapGoogle = await Task.Run<string>(() => this._Hunt.PerformOCRMapWithGoogleVision(croppedMapPath, this._googleAPI));
					this._Hunt.ExtractCoordinatesSimple(mapGoogle, out X, out Y);
					Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Coordonnées extraites avec Google Vision [");
					defaultInterpolatedStringHandler.AppendFormatted<int>(X);
					defaultInterpolatedStringHandler.AppendLiteral(", ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(Y);
					defaultInterpolatedStringHandler.AppendLiteral("]");
					dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Coordonnées extraites avec Google Vision [");
					defaultInterpolatedStringHandler.AppendFormatted<int>(X);
					defaultInterpolatedStringHandler.AppendLiteral(", ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(Y);
					defaultInterpolatedStringHandler.AppendLiteral("]");
					MessageBox.Show(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				else
				{
					Dofus_Hunt dofus_Hunt2 = this._Dofus_Hunt;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Coordonnées extraites avec Tesseract [");
					defaultInterpolatedStringHandler.AppendFormatted<int>(X);
					defaultInterpolatedStringHandler.AppendLiteral(", ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(Y);
					defaultInterpolatedStringHandler.AppendLiteral("]");
					dofus_Hunt2.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Coordonnées extraites avec Tesseract [");
					defaultInterpolatedStringHandler.AppendFormatted<int>(X);
					defaultInterpolatedStringHandler.AppendLiteral(", ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(Y);
					defaultInterpolatedStringHandler.AppendLiteral("]");
					MessageBox.Show(defaultInterpolatedStringHandler.ToStringAndClear());
				}
			}
			else
			{
				MessageBox.Show("L'image recadrée n'a pas été trouvée. Veuillez réessayer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000371C File Offset: 0x0000191C
		private void textEdit_Hunt_Config_Debug_EditValueChanged(object sender, EventArgs e)
		{
			string dateFormat = DateTime.Now.ToString("yyyyMMdd");
			if (this.textEdit_Hunt_Config_Debug.Text == dateFormat)
			{
				this.checkEdit_Hunt_Config_Debug.Enabled = true;
				return;
			}
			this.checkEdit_Hunt_Config_Debug.Enabled = false;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003768 File Offset: 0x00001968
		private void checkEdit_Hunt_Config_Debug_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkEdit_Hunt_Config_Debug.Checked)
			{
				this.accordionControlElement_SubMenu_Config_Debug.Visible = true;
			}
			if (!this.checkEdit_Hunt_Config_Debug.Checked)
			{
				this.accordionControlElement_SubMenu_Config_Debug.Visible = false;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000379C File Offset: 0x0000199C
		private void simpleButton_Hunt_Debug_GetIndice_Click(object sender, EventArgs e)
		{
			string indice = this._Hunt.getIndiceTexte(this._HuntAutoIndice_Threshold_Start, this._HuntAutoIndice_largeurTexte_Start, this._HuntAutoIndice_hauteurTexte_Start, this._HuntAutoIndice_Threshold_Coche, this._HuntAutoIndice_largeurTexte_Coche, this._HuntAutoIndice_hauteurTexte_Coche);
			MessageBox.Show("L'indice trouvé est : " + indice, "Résultat de la recherche", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000037F4 File Offset: 0x000019F4
		private void simpleButton_Hunt_Debug_GetArrow_Click(object sender, EventArgs e)
		{
			string arrow = this._Hunt.DetectArrowDirectionAfterOCR(this._HuntAutoIndice_Threshold_Arrow);
			string img_arrow = this._Hunt.GetArrowIcon(arrow);
			MessageBox.Show("La direction de la flèche est : " + img_arrow, "Résultat de la recherche", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000383C File Offset: 0x00001A3C
		private void checkEdit_Hunt_Config_Logiciel_Ecran_CheckedChanged(object sender, EventArgs e)
		{
			bool alwaysOnScreenValue;
			bool.TryParse(this._alwaysonscreen, out alwaysOnScreenValue);
			if (this.checkEdit_Hunt_Config_Logiciel_Ecran.Checked != alwaysOnScreenValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "AlwaysOnScreen", this.checkEdit_Hunt_Config_Logiciel_Ecran.Checked.ToString());
				this._alwaysonscreen = this.checkEdit_Hunt_Config_Logiciel_Ecran.Checked.ToString();
				this.initConfig();
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000038B8 File Offset: 0x00001AB8
		private void checkEdit_Hunt_Config_Logiciel_LogAvance_CheckedChanged(object sender, EventArgs e)
		{
			bool logAdvencedValue;
			bool.TryParse(this._advancedLog, out logAdvencedValue);
			if (this.checkEdit_Hunt_Config_Logiciel_LogAvance.Checked != logAdvencedValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "AdvancedLog", this.checkEdit_Hunt_Config_Logiciel_LogAvance.Checked.ToString());
				this._advancedLog = this.checkEdit_Hunt_Config_Logiciel_LogAvance.Checked.ToString();
				this.initConfig();
				this._Hunt = new Hunt(this._dofus, this._advancedLog, this._HuntAutoIndice_similarityThreshold);
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003950 File Offset: 0x00001B50
		private void checkEdit_Hunt_Config_Logiciel_Theme_CheckedChanged(object sender, EventArgs e)
		{
			bool darkValue;
			bool.TryParse(this._dark, out darkValue);
			if (this.checkEdit_Hunt_Config_Logiciel_Theme.Checked != darkValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Dark", this.checkEdit_Hunt_Config_Logiciel_Theme.Checked.ToString());
				this._dark = this.checkEdit_Hunt_Config_Logiciel_Theme.Checked.ToString();
				this.initConfig();
			}
			if (!this.checkEdit_Hunt_Config_Logiciel_Theme.Checked)
			{
				UserLookAndFeel.Default.SkinName = "Metropolis";
				return;
			}
			UserLookAndFeel.Default.SkinName = "Metropolis Dark";
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000039F8 File Offset: 0x00001BF8
		private void checkEdit_Hunt_Config_Logiciel_DeleteFile_CheckedChanged(object sender, EventArgs e)
		{
			bool deleteTempFilesValue;
			bool.TryParse(this._deleteTempFiles, out deleteTempFilesValue);
			if (this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Checked != deleteTempFilesValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "DeleteTempFiles", this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Checked.ToString());
				this._deleteTempFiles = this.checkEdit_Hunt_Config_Logiciel_DeleteFile.Checked.ToString();
				this.initConfig();
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003A74 File Offset: 0x00001C74
		private void checkEdit_Hunt_Config_Logiciel_DeleteLog_CheckedChanged(object sender, EventArgs e)
		{
			bool deleteLogValue;
			bool.TryParse(this._deleteLog, out deleteLogValue);
			if (this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Checked != deleteLogValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "DeleteLogs", this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Checked.ToString());
				this._deleteLog = this.checkEdit_Hunt_Config_Logiciel_DeleteLog.Checked.ToString();
				this.initConfig();
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003AF0 File Offset: 0x00001CF0
		private void checkEdit_Hunt_Config_Logiciel_Notifications_CheckedChanged(object sender, EventArgs e)
		{
			bool notifyValue;
			bool.TryParse(this._notify, out notifyValue);
			if (this.checkEdit_Hunt_Config_Logiciel_Notifications.Checked != notifyValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify", this.checkEdit_Hunt_Config_Logiciel_Notifications.Checked.ToString());
				this._notify = this.checkEdit_Hunt_Config_Logiciel_Notifications.Checked.ToString();
				this.initConfig();
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003B6C File Offset: 0x00001D6C
		private void checkEdit_Hunt_Config_Logiciel_UpdateDHU_CheckedChanged(object sender, EventArgs e)
		{
			bool updateDHUValue;
			bool.TryParse(this._updateDHU, out updateDHUValue);
			if (this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Checked != updateDHUValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "UpdateDHU", this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Checked.ToString());
				this._updateDHU = this.checkEdit_Hunt_Config_Logiciel_UpdateDHU.Checked.ToString();
				this.initConfig();
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003BE8 File Offset: 0x00001DE8
		private void checkEdit_Hunt_Config_UseGoogleVision_CheckedChanged(object sender, EventArgs e)
		{
			bool googleVisionValue;
			bool.TryParse(this._googleVision, out googleVisionValue);
			if (this.checkEdit_Hunt_Config_UseGoogleVision.Checked != googleVisionValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAuto_GoogleVision", this.checkEdit_Hunt_Config_UseGoogleVision.Checked.ToString());
				this._googleVision = this.checkEdit_Hunt_Config_UseGoogleVision.Checked.ToString();
				this.initConfig();
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003C64 File Offset: 0x00001E64
		private void checkEdit_Hunt_Config_Offline_CheckedChanged(object sender, EventArgs e)
		{
			bool modeOfflineValue;
			bool.TryParse(this._modeOffline, out modeOfflineValue);
			if (this.checkEdit_Hunt_Config_Offline.Checked != modeOfflineValue)
			{
				this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAuto_Offline", this.checkEdit_Hunt_Config_Offline.Checked.ToString());
				this._modeOffline = this.checkEdit_Hunt_Config_Offline.Checked.ToString();
				this.initConfig();
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003CE0 File Offset: 0x00001EE0
		private void simpleButton_Notify_Reinit_Click(object sender, EventArgs e)
		{
			this.textEdit_Notify_App_Update.Text = "Une mise à jour est disponible !";
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_App_Update", this.textEdit_Notify_App_Update.Text);
			this.textEdit_Notify_App_PbCo.Text = "Problème de connexion, vérifier votre connexion ou réessayer plus tard.";
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_App_Connect", this.textEdit_Notify_App_PbCo.Text);
			this.textEdit_Notify_App_PbData.Text = "Erreur lors de la récupération des données.";
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_App_GetData", this.textEdit_Notify_App_PbData.Text);
			this.textEdit_Notify_App_Restart.Text = "L'application demande une mise à jour.";
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_App_Restart", this.textEdit_Notify_App_Restart.Text);
			this.textEdit_Notify_Hunt_NoData.Text = "Aucune données trouvée à la position.";
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_Hunt_NoData", this.textEdit_Notify_Hunt_NoData.Text);
			this.textEdit_Indices_IndiceOK.Text = "Merci de vous rendre à la position pour continuer.";
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_Indice_OK", this.textEdit_Indices_IndiceOK.Text);
			this.textEdit_Indices_IndiceKO.Text = "Erreur lors de la récupération de la position de l'indice ...\nPeut être vérifier l'indice détecté et faire une correction manuelle.";
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_Indice_KO", this.textEdit_Indices_IndiceKO.Text);
			this.textEdit_Indices_Phorreur.Text = "L'indice en cours semble être un Phorreur, pourquoi ne pas le faire manuellement ?";
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_Indice_Phorreur", this.textEdit_Indices_Phorreur.Text);
			this.textEdit_Indices_CorrectIndice.Text = "Correction d'indice ajoutée avec succès.";
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_Indice_Correct", this.textEdit_Indices_CorrectIndice.Text);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003EF8 File Offset: 0x000020F8
		private void simpleButton_Notify_Save_Click(object sender, EventArgs e)
		{
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_App_Update", this.textEdit_Notify_App_Update.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_App_Connect", this.textEdit_Notify_App_PbCo.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_App_GetData", this.textEdit_Notify_App_PbData.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_App_Restart", this.textEdit_Notify_App_Restart.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_Hunt_NoData", this.textEdit_Notify_Hunt_NoData.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_Indice_OK", this.textEdit_Indices_IndiceOK.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_Indice_KO", this.textEdit_Indices_IndiceKO.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_Indice_Phorreur", this.textEdit_Indices_Phorreur.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "Notify_Indice_Correct", this.textEdit_Indices_CorrectIndice.Text);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000407F File Offset: 0x0000227F
		private void groupControl2_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00004084 File Offset: 0x00002284
		private void pictureBox_Hunt_Config_Hunt_Template_Coche_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files|*.png";
				openFileDialog.Title = "Sélectionner un template";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = openFileDialog.FileName;
					string targetDirectory = Path.Combine(Application.StartupPath, "ressources", "img");
					string targetFilePath = Path.Combine(targetDirectory, "coche_blanche.png");
					if (!Directory.Exists(targetDirectory))
					{
						Directory.CreateDirectory(targetDirectory);
					}
					if (this.pictureBox_Hunt_Config_Hunt_Template_Coche.Image != null)
					{
						this.pictureBox_Hunt_Config_Hunt_Template_Coche.Image.Dispose();
						this.pictureBox_Hunt_Config_Hunt_Template_Coche.Image = null;
					}
					File.Copy(fileName, targetFilePath, true);
					this._Dofus_Hunt.AddLog("Modification de l'image Template Coche Blanche effectuée avec succès.");
					this.pictureBox_Hunt_Config_Hunt_Template_Coche.Image = Image.FromFile(targetFilePath);
				}
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00004160 File Offset: 0x00002360
		private void pictureBox_Hunt_Config_Hunt_Template_Start_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files|*.png";
				openFileDialog.Title = "Sélectionner un template";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = openFileDialog.FileName;
					string targetDirectory = Path.Combine(Application.StartupPath, "ressources", "img");
					string targetFilePath = Path.Combine(targetDirectory, "depart_template.png");
					if (!Directory.Exists(targetDirectory))
					{
						Directory.CreateDirectory(targetDirectory);
					}
					if (this.pictureBox_Hunt_Config_Hunt_Template_Start.Image != null)
					{
						this.pictureBox_Hunt_Config_Hunt_Template_Start.Image.Dispose();
						this.pictureBox_Hunt_Config_Hunt_Template_Start.Image = null;
					}
					File.Copy(fileName, targetFilePath, true);
					this._Dofus_Hunt.AddLog("Modification de l'image Template Départ effectuée avec succès.");
					this.pictureBox_Hunt_Config_Hunt_Template_Start.Image = Image.FromFile(targetFilePath);
				}
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000423C File Offset: 0x0000243C
		private void pictureBox_Hunt_Config_Hunt_Template_Level_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files|*.png";
				openFileDialog.Title = "Sélectionner un template";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = openFileDialog.FileName;
					string targetDirectory = Path.Combine(Application.StartupPath, "ressources", "img");
					string targetFilePath = Path.Combine(targetDirectory, "niveau.png");
					if (!Directory.Exists(targetDirectory))
					{
						Directory.CreateDirectory(targetDirectory);
					}
					if (this.pictureBox_Hunt_Config_Hunt_Template_Level.Image != null)
					{
						this.pictureBox_Hunt_Config_Hunt_Template_Level.Image.Dispose();
						this.pictureBox_Hunt_Config_Hunt_Template_Level.Image = null;
					}
					File.Copy(fileName, targetFilePath, true);
					this._Dofus_Hunt.AddLog("Modification de l'image Template Level effectuée avec succès.");
					this.pictureBox_Hunt_Config_Hunt_Template_Level.Image = Image.FromFile(targetFilePath);
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00004318 File Offset: 0x00002518
		private void pictureBox_Hunt_Config_Hunt_Template_Arrow_6_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files|*.png";
				openFileDialog.Title = "Sélectionner un template";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = openFileDialog.FileName;
					string targetDirectory = Path.Combine(Application.StartupPath, "ressources", "img");
					string targetFilePath = Path.Combine(targetDirectory, "fleche_haut.png");
					if (!Directory.Exists(targetDirectory))
					{
						Directory.CreateDirectory(targetDirectory);
					}
					if (this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.Image != null)
					{
						this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.Image.Dispose();
						this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.Image = null;
					}
					File.Copy(fileName, targetFilePath, true);
					this._Dofus_Hunt.AddLog("Modification de l'image Template Flèche Haut effectuée avec succès.");
					this.pictureBox_Hunt_Config_Hunt_Template_Arrow_6.Image = Image.FromFile(targetFilePath);
				}
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000043F4 File Offset: 0x000025F4
		private void pictureBox_Hunt_Config_Hunt_Template_Arrow_0_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files|*.png";
				openFileDialog.Title = "Sélectionner un template";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = openFileDialog.FileName;
					string targetDirectory = Path.Combine(Application.StartupPath, "ressources", "img");
					string targetFilePath = Path.Combine(targetDirectory, "fleche_droite.png");
					if (!Directory.Exists(targetDirectory))
					{
						Directory.CreateDirectory(targetDirectory);
					}
					if (this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.Image != null)
					{
						this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.Image.Dispose();
						this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.Image = null;
					}
					File.Copy(fileName, targetFilePath, true);
					this._Dofus_Hunt.AddLog("Modification de l'image Template Flèche Droite effectuée avec succès.");
					this.pictureBox_Hunt_Config_Hunt_Template_Arrow_0.Image = Image.FromFile(targetFilePath);
				}
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000044D0 File Offset: 0x000026D0
		private void pictureBox_Hunt_Config_Hunt_Template_Arrow_2_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files|*.png";
				openFileDialog.Title = "Sélectionner un template";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = openFileDialog.FileName;
					string targetDirectory = Path.Combine(Application.StartupPath, "ressources", "img");
					string targetFilePath = Path.Combine(targetDirectory, "fleche_bas.png");
					if (!Directory.Exists(targetDirectory))
					{
						Directory.CreateDirectory(targetDirectory);
					}
					if (this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.Image != null)
					{
						this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.Image.Dispose();
						this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.Image = null;
					}
					File.Copy(fileName, targetFilePath, true);
					this._Dofus_Hunt.AddLog("Modification de l'image Template Flèche Bas effectuée avec succès.");
					this.pictureBox_Hunt_Config_Hunt_Template_Arrow_2.Image = Image.FromFile(targetFilePath);
				}
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000045AC File Offset: 0x000027AC
		private void pictureBox_Hunt_Config_Hunt_Template_Arrow_4_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files|*.png";
				openFileDialog.Title = "Sélectionner un template";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = openFileDialog.FileName;
					string targetDirectory = Path.Combine(Application.StartupPath, "ressources", "img");
					string targetFilePath = Path.Combine(targetDirectory, "fleche_gauche.png");
					if (!Directory.Exists(targetDirectory))
					{
						Directory.CreateDirectory(targetDirectory);
					}
					if (this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.Image != null)
					{
						this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.Image.Dispose();
						this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.Image = null;
					}
					File.Copy(fileName, targetFilePath, true);
					this._Dofus_Hunt.AddLog("Modification de l'image Template Flèche Gauche effectuée avec succès.");
					this.pictureBox_Hunt_Config_Hunt_Template_Arrow_4.Image = Image.FromFile(targetFilePath);
				}
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004688 File Offset: 0x00002888
		private string ReplaceDotWithComma(string input)
		{
			return input.Replace('.', ',');
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004694 File Offset: 0x00002894
		private void simpleButton_Hunt_Config_Hunt_Position_save_Click(object sender, EventArgs e)
		{
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoPosition_X", this.textEdit_Hunt_Config_Hunt_Position_X.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoPosition_Y", this.textEdit_Hunt_Config_Hunt_Position_Y.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoPosition_width", this.textEdit_Hunt_Config_Hunt_Position_width.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoPosition_height", this.textEdit_Hunt_Config_Hunt_Position_height.Text);
			string thresholdValue = this.ReplaceDotWithComma(this.textEdit_Hunt_Config_Hunt_Position_threshold.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoPosition_threshold", thresholdValue);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoPosition_largeurTexte", this.textEdit_Hunt_Config_Hunt_Position_largeurTexte.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoPosition_hauteurTexte", this.textEdit_Hunt_Config_Hunt_Position_hauteurTexte.Text);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000047D0 File Offset: 0x000029D0
		private void simpleButton_Hunt_Config_Hunt_Indice_Save_Click(object sender, EventArgs e)
		{
			string HuntAutoIndice_OCRStart = this.ReplaceDotWithComma(this.textEdit_Hunt_Config_Hunt_Indice_OCRStart.Text);
			string HuntAutoIndice_OCRCoche = this.ReplaceDotWithComma(this.textEdit_Hunt_Config_Hunt_Indice_OCRCoche.Text);
			string HuntAutoIndice_OCRArrow = this.ReplaceDotWithComma(this.textEdit_Hunt_Config_Hunt_Indice_OCRFleche.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoIndice_OCRStart", HuntAutoIndice_OCRStart);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoIndice_LStart", this.textEdit_Hunt_Config_Hunt_Indice_LStart.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoIndice_HStart", this.textEdit_Hunt_Config_Hunt_Indice_HStart.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoIndice_OCRCoche", HuntAutoIndice_OCRCoche);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoIndice_LIndice", this.textEdit_Hunt_Config_Hunt_Indice_LIndice.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoIndice_HIndice", this.textEdit_Hunt_Config_Hunt_Indice_HIndice.Text);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoIndice_OCRArrow", HuntAutoIndice_OCRArrow);
			this._Dofus_Hunt.UpdateParameterValue(FormHome._configPath + "/appSettings.xml", "HuntAutoIndice_similarityThreshold", this.textEdit_Hunt_Config_Hunt_Indice_Detection.Text);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004948 File Offset: 0x00002B48
		private void PopulateComboBox(string jsonResponse, int currentX, int currentY)
		{
			try
			{
				this.comboBoxEdit_Hunt_Indice.Properties.Items.Clear();
				this.huntIndicePositions.Clear();
				HashSet<string> namesSet = new HashSet<string>();
				JObject parsedJson = JObject.Parse(jsonResponse);
				if (parsedJson["data"] != null)
				{
					foreach (JToken item in ((IEnumerable<JToken>)parsedJson["data"]))
					{
						JToken jtoken = item["posX"];
						int posX = ((jtoken != null) ? jtoken.Value<int>() : 0);
						JToken jtoken2 = item["posY"];
						int posY = ((jtoken2 != null) ? jtoken2.Value<int>() : 0);
						if (item["pois"] != null)
						{
							foreach (JToken jtoken3 in ((IEnumerable<JToken>)item["pois"]))
							{
								JToken jtoken4 = jtoken3["name"];
								string text;
								if (jtoken4 == null)
								{
									text = null;
								}
								else
								{
									JToken jtoken5 = jtoken4["fr"];
									text = ((jtoken5 != null) ? jtoken5.ToString() : null);
								}
								string nameFr = text;
								if (!string.IsNullOrEmpty(nameFr))
								{
									int distance = Math.Abs(posX - currentX) + Math.Abs(posY - currentY);
									if (this.huntIndicePositions.ContainsKey(nameFr))
									{
										ValueTuple<int, int> existingPosition = this.huntIndicePositions[nameFr];
										int existingDistance = Math.Abs(existingPosition.Item1 - currentX) + Math.Abs(existingPosition.Item2 - currentY);
										if (distance < existingDistance)
										{
											this.huntIndicePositions[nameFr] = new ValueTuple<int, int>(posX, posY);
										}
									}
									else
									{
										this.huntIndicePositions[nameFr] = new ValueTuple<int, int>(posX, posY);
									}
									namesSet.Add(nameFr);
								}
							}
						}
					}
					List<string> list = namesSet.ToList<string>();
					list.Sort();
					using (List<string>.Enumerator enumerator3 = list.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							string name = enumerator3.Current;
							this.comboBoxEdit_Hunt_Indice.Properties.Items.Add(name);
						}
						goto IL_0221;
					}
				}
				if (this._advancedLog == "True")
				{
					this._Dofus_Hunt.AddLog("Aucune donnée trouvée dans la réponse JSON.");
				}
				IL_0221:;
			}
			catch (Exception ex)
			{
				if (this._advancedLog == "True")
				{
					this._Dofus_Hunt.AddLog("Erreur lors de l'ajout des éléments à la comboBox : " + ex.Message);
				}
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004C10 File Offset: 0x00002E10
		private void simpleButton_Hunt_6_Click(object sender, EventArgs e)
		{
			this.RessetColorButtonHunt(this.simpleButton_Hunt_2);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_0);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_6);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_4);
			this.ChangeColorButtonHunt(this.simpleButton_Hunt_6);
			string direction = "6";
			if (this._modeOffline == "True")
			{
				this.comboBoxEdit_Hunt_Indice.Properties.Items.Clear();
				using (List<IndiceData>.Enumerator enumerator = (from indice in this._Hunt.GetHuntData(this.textEdit_Hunt_X.Text, this.textEdit_Hunt_Y.Text, direction)
					orderby indice.indice
					select indice).ToList<IndiceData>().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IndiceData indiceJSON = enumerator.Current;
						this.huntIndicePositions.Clear();
						this.comboBoxEdit_Hunt_Indice.Properties.Items.Add(indiceJSON.indice);
					}
					return;
				}
			}
			string indice2 = this._Hunt.GetIndice(this._token, this.textEdit_Hunt_X.Text, this.textEdit_Hunt_Y.Text, direction);
			int currentX = int.Parse(this.textEdit_Hunt_X.Text);
			int currentY = int.Parse(this.textEdit_Hunt_Y.Text);
			this.PopulateComboBox(indice2, currentX, currentY);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004D8C File Offset: 0x00002F8C
		private void RessetColorButtonHunt(SimpleButton simpleButton)
		{
			simpleButton.Appearance.ForeColor = SystemColors.ControlText;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00004DA0 File Offset: 0x00002FA0
		private void ChangeColorButtonHunt(SimpleButton simpleButton)
		{
			if (this._dark == "False")
			{
				simpleButton.ForeColor = Color.FromArgb(58, 203, 250);
				return;
			}
			simpleButton.ForeColor = Color.FromArgb(220, 135, 13);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00004DF0 File Offset: 0x00002FF0
		private void comboBoxEdit_Hunt_Indice_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this._modeOffline == "True")
			{
				object selectedItem2 = this.comboBoxEdit_Hunt_Indice.SelectedItem;
				string selectedIndice = ((selectedItem2 != null) ? selectedItem2.ToString() : null);
				ValueTuple<int, int, string> position = this._Hunt.GetIndicePositionOffline(selectedIndice);
				if (!string.IsNullOrEmpty(selectedIndice))
				{
					this.textEdit_Hunt_X.Text = position.Item1.ToString();
					this.textEdit_Hunt_Y.Text = position.Item2.ToString();
					Control control = this.labelControl_Hunt_Map;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
					defaultInterpolatedStringHandler.AppendLiteral("[");
					defaultInterpolatedStringHandler.AppendFormatted(position.Item1.ToString());
					defaultInterpolatedStringHandler.AppendLiteral(", ");
					defaultInterpolatedStringHandler.AppendFormatted(position.Item2.ToString());
					defaultInterpolatedStringHandler.AppendLiteral("]");
					control.Text = defaultInterpolatedStringHandler.ToStringAndClear();
					if (this.checkEdit_Hunt_AutoTravel.Checked)
					{
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
						defaultInterpolatedStringHandler.AppendLiteral("/travel ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item1);
						defaultInterpolatedStringHandler.AppendLiteral(" ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item2);
						Clipboard.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					this.comboBoxEdit_Hunt_Indice.Text = "";
					this.comboBoxEdit_Hunt_Indice.Properties.Items.Clear();
					this.RessetColorButtonHunt(this.simpleButton_Hunt_2);
					this.RessetColorButtonHunt(this.simpleButton_Hunt_0);
					this.RessetColorButtonHunt(this.simpleButton_Hunt_6);
					this.RessetColorButtonHunt(this.simpleButton_Hunt_4);
					return;
				}
			}
			else
			{
				object selectedItem3 = this.comboBoxEdit_Hunt_Indice.SelectedItem;
				string selectedItem = ((selectedItem3 != null) ? selectedItem3.ToString() : null);
				if (!string.IsNullOrEmpty(selectedItem) && this.huntIndicePositions.ContainsKey(selectedItem))
				{
					ValueTuple<int, int> positions = this.huntIndicePositions[selectedItem];
					this.textEdit_Hunt_X.Text = positions.Item1.ToString();
					this.textEdit_Hunt_Y.Text = positions.Item2.ToString();
					Control control2 = this.labelControl_Hunt_Map;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
					defaultInterpolatedStringHandler.AppendLiteral("[");
					defaultInterpolatedStringHandler.AppendFormatted(positions.Item1.ToString());
					defaultInterpolatedStringHandler.AppendLiteral(", ");
					defaultInterpolatedStringHandler.AppendFormatted(positions.Item2.ToString());
					defaultInterpolatedStringHandler.AppendLiteral("]");
					control2.Text = defaultInterpolatedStringHandler.ToStringAndClear();
					if (this.checkEdit_Hunt_AutoTravel.Checked)
					{
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
						defaultInterpolatedStringHandler.AppendLiteral("/travel ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(positions.Item1);
						defaultInterpolatedStringHandler.AppendLiteral(" ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(positions.Item2);
						Clipboard.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					this.comboBoxEdit_Hunt_Indice.Text = "";
					this.comboBoxEdit_Hunt_Indice.Properties.Items.Clear();
					this.huntIndicePositions.Clear();
					this.RessetColorButtonHunt(this.simpleButton_Hunt_2);
					this.RessetColorButtonHunt(this.simpleButton_Hunt_0);
					this.RessetColorButtonHunt(this.simpleButton_Hunt_6);
					this.RessetColorButtonHunt(this.simpleButton_Hunt_4);
				}
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000510C File Offset: 0x0000330C
		private void simpleButton_Hunt_0_Click(object sender, EventArgs e)
		{
			this.RessetColorButtonHunt(this.simpleButton_Hunt_2);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_0);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_6);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_4);
			this.ChangeColorButtonHunt(this.simpleButton_Hunt_0);
			string direction = "0";
			if (this._modeOffline == "True")
			{
				this.comboBoxEdit_Hunt_Indice.Properties.Items.Clear();
				using (List<IndiceData>.Enumerator enumerator = (from indice in this._Hunt.GetHuntData(this.textEdit_Hunt_X.Text, this.textEdit_Hunt_Y.Text, direction)
					orderby indice.indice
					select indice).ToList<IndiceData>().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IndiceData indiceJSON = enumerator.Current;
						this.huntIndicePositions.Clear();
						this.comboBoxEdit_Hunt_Indice.Properties.Items.Add(indiceJSON.indice);
					}
					return;
				}
			}
			string indice2 = this._Hunt.GetIndice(this._token, this.textEdit_Hunt_X.Text, this.textEdit_Hunt_Y.Text, direction);
			int currentX = int.Parse(this.textEdit_Hunt_X.Text);
			int currentY = int.Parse(this.textEdit_Hunt_Y.Text);
			this.PopulateComboBox(indice2, currentX, currentY);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00005288 File Offset: 0x00003488
		private void simpleButton_Hunt_2_Click(object sender, EventArgs e)
		{
			this.RessetColorButtonHunt(this.simpleButton_Hunt_2);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_0);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_6);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_4);
			this.ChangeColorButtonHunt(this.simpleButton_Hunt_2);
			string direction = "2";
			if (this._modeOffline == "True")
			{
				this.comboBoxEdit_Hunt_Indice.Properties.Items.Clear();
				using (List<IndiceData>.Enumerator enumerator = (from indice in this._Hunt.GetHuntData(this.textEdit_Hunt_X.Text, this.textEdit_Hunt_Y.Text, direction)
					orderby indice.indice
					select indice).ToList<IndiceData>().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IndiceData indiceJSON = enumerator.Current;
						this.huntIndicePositions.Clear();
						this.comboBoxEdit_Hunt_Indice.Properties.Items.Add(indiceJSON.indice);
					}
					return;
				}
			}
			string indice2 = this._Hunt.GetIndice(this._token, this.textEdit_Hunt_X.Text, this.textEdit_Hunt_Y.Text, direction);
			int currentX = int.Parse(this.textEdit_Hunt_X.Text);
			int currentY = int.Parse(this.textEdit_Hunt_Y.Text);
			this.PopulateComboBox(indice2, currentX, currentY);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00005404 File Offset: 0x00003604
		private void simpleButton_Hunt_4_Click(object sender, EventArgs e)
		{
			this.RessetColorButtonHunt(this.simpleButton_Hunt_2);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_0);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_6);
			this.RessetColorButtonHunt(this.simpleButton_Hunt_4);
			this.ChangeColorButtonHunt(this.simpleButton_Hunt_4);
			string direction = "4";
			if (this._modeOffline == "True")
			{
				this.comboBoxEdit_Hunt_Indice.Properties.Items.Clear();
				using (List<IndiceData>.Enumerator enumerator = (from indice in this._Hunt.GetHuntData(this.textEdit_Hunt_X.Text, this.textEdit_Hunt_Y.Text, direction)
					orderby indice.indice
					select indice).ToList<IndiceData>().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IndiceData indiceJSON = enumerator.Current;
						this.huntIndicePositions.Clear();
						this.comboBoxEdit_Hunt_Indice.Properties.Items.Add(indiceJSON.indice);
					}
					return;
				}
			}
			string indice2 = this._Hunt.GetIndice(this._token, this.textEdit_Hunt_X.Text, this.textEdit_Hunt_Y.Text, direction);
			int currentX = int.Parse(this.textEdit_Hunt_X.Text);
			int currentY = int.Parse(this.textEdit_Hunt_Y.Text);
			this.PopulateComboBox(indice2, currentX, currentY);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005580 File Offset: 0x00003780
		private void ResetInterfaceChasse()
		{
			this.labelControl_HuntAuto_MapStart.Text = "Map de départ :";
			this.labelControl_HuntAuto_Indice.Text = "Indice :";
			this.labelControl_HuntAuto_IndiceCor.Text = "Indice corrigé :";
			this.labelControl_HuntAuto_IndiceCor.Visible = false;
			this.labelControl_HuntAuto_Direction.Text = "Direction :";
			this.labelControl_HuntAuto_MapIndice.Text = "Map de l'indice :";
			this.simpleButton_HuntAutoStart.Enabled = true;
			this.simpleButton_HuntAutoStop.Enabled = false;
			this.checkEdit_HuntAuto_AutoTravel.Checked = true;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005610 File Offset: 0x00003810
		private void accordionControlElement_SubMenu_Config_Update_Click(object sender, EventArgs e)
		{
			try
			{
				string updateProgramPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dofus Hunt Update.exe");
				if (File.Exists(updateProgramPath))
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo
					{
						FileName = updateProgramPath,
						UseShellExecute = true,
						Verb = "runas"
					};
					try
					{
						Process.Start(processStartInfo);
						Application.Exit();
						goto IL_007E;
					}
					catch (Win32Exception ex)
					{
						MessageBox.Show("L'élévation a été refusée : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						goto IL_007E;
					}
				}
				MessageBox.Show("Le programme de mise à jour n'a pas été trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				IL_007E:;
			}
			catch (Exception ex2)
			{
				MessageBox.Show("Une erreur s'est produite : " + ex2.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000056DC File Offset: 0x000038DC
		private async void simpleButton_HuntAutoStart_Click(object sender, EventArgs e)
		{
			FormHome.<>c__DisplayClass111_0 CS$<>8__locals1 = new FormHome.<>c__DisplayClass111_0();
			CS$<>8__locals1.<>4__this = this;
			string dofus = this._dofus;
			this.simpleButton_HuntAutoStart.Enabled = false;
			this.simpleButton_HuntAutoStop.Enabled = true;
			this._Hunt.CaptureGame(FormHome._logPathImg + "/screenshot.png");
			await Task.Run(delegate
			{
				CS$<>8__locals1.<>4__this._Hunt.DetectCurrentMap(CS$<>8__locals1.<>4__this._HuntAutoPosition_X, CS$<>8__locals1.<>4__this._HuntAutoPosition_Y, CS$<>8__locals1.<>4__this._HuntAutoPosition_Width, CS$<>8__locals1.<>4__this._HuntAutoPosition_Height, CS$<>8__locals1.<>4__this._HuntAutoPosition_Threshold, CS$<>8__locals1.<>4__this._HuntAutoPosition_largeurTexte, CS$<>8__locals1.<>4__this._HuntAutoPosition_hauteurTexte);
			});
			CS$<>8__locals1.croppedMapPath = FormHome._logPathImg + "/cropped_map.png";
			if (File.Exists(CS$<>8__locals1.croppedMapPath))
			{
				FormHome.<>c__DisplayClass111_1 CS$<>8__locals2 = new FormHome.<>c__DisplayClass111_1();
				CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
				string map = await Task.Run<string>(() => CS$<>8__locals2.CS$<>8__locals1.<>4__this._Hunt.PerformOCRTesseractMap(CS$<>8__locals2.CS$<>8__locals1.croppedMapPath));
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
				if (!this._Hunt.ExtractCoordinatesSimple(map, out this._currentX, out this._currentY) && this._googleVision == "True")
				{
					string mapGoogle = await Task.Run<string>(() => CS$<>8__locals2.CS$<>8__locals1.<>4__this._Hunt.PerformOCRMapWithGoogleVision(CS$<>8__locals2.CS$<>8__locals1.croppedMapPath, CS$<>8__locals2.CS$<>8__locals1.<>4__this._googleAPI));
					this._Hunt.ExtractCoordinatesSimple(mapGoogle, out this._currentX, out this._currentY);
					if (this._advancedLog == "True")
					{
						Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 2);
						defaultInterpolatedStringHandler.AppendLiteral("Coordonnées extraites avec Google Vision [");
						defaultInterpolatedStringHandler.AppendFormatted<int>(this._currentX);
						defaultInterpolatedStringHandler.AppendLiteral(", ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(this._currentY);
						defaultInterpolatedStringHandler.AppendLiteral("]");
						dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
				}
				else if (this._advancedLog == "True")
				{
					Dofus_Hunt dofus_Hunt2 = this._Dofus_Hunt;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Coordonnées extraites avec Tesseract [");
					defaultInterpolatedStringHandler.AppendFormatted<int>(this._currentX);
					defaultInterpolatedStringHandler.AppendLiteral(", ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(this._currentY);
					defaultInterpolatedStringHandler.AppendLiteral("]");
					dofus_Hunt2.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				Control control = this.labelControl_HuntAuto_MapStart;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Map de départ : [");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this._currentX);
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this._currentY);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				control.Text = defaultInterpolatedStringHandler.ToStringAndClear();
				CS$<>8__locals2.indice = this._Hunt.getIndiceTexte(this._HuntAutoIndice_Threshold_Start, this._HuntAutoIndice_largeurTexte_Start, this._HuntAutoIndice_hauteurTexte_Start, this._HuntAutoIndice_Threshold_Coche, this._HuntAutoIndice_largeurTexte_Coche, this._HuntAutoIndice_hauteurTexte_Coche);
				if (CS$<>8__locals2.indice == string.Empty)
				{
					this._Dofus_Hunt.AddLog("Indice de départ non détecté. Veuillez réessayer.");
					this.ResetInterfaceChasse();
					if (this._notify == "True")
					{
						this.toastNotificationsManager.ShowNotification("App_GetData");
					}
				}
				else
				{
					string correctedText = this._Hunt.GetCorrectedText(CS$<>8__locals2.indice);
					this.labelControl_HuntAuto_Indice.Text = "Indice : " + correctedText;
					this._lastDetectedIndice = correctedText;
					CS$<>8__locals2.arrow = this._Hunt.DetectArrowDirectionAfterOCR(this._HuntAutoIndice_Threshold_Arrow);
					if (CS$<>8__locals2.arrow == string.Empty)
					{
						this._Dofus_Hunt.AddLog("Flèche de l'indice non détectée. Veuillez réessayer.");
						this.ResetInterfaceChasse();
						if (this._notify == "True")
						{
							this.toastNotificationsManager.ShowNotification("App_GetData");
						}
					}
					else
					{
						string img_arrow = this._Hunt.GetArrowIcon(CS$<>8__locals2.arrow);
						this.labelControl_HuntAuto_Direction.Text = "Direction : " + img_arrow;
						if (this._Hunt.DetectPhorreur(this._lastDetectedIndice) == 1)
						{
							this._lastIndiceIsPhorreur = true;
							if (this._advancedLog == "True")
							{
								this._Dofus_Hunt.AddLog("L'indice est un Phorreur.");
							}
							if (this._notify == "True")
							{
								this.toastNotificationsManager.ShowNotification("Indice_Phorreur");
							}
							this.labelControl_HuntAuto_IndiceCor.Visible = false;
							this.labelControl_HuntAuto_IndiceCor.Text = "Indice corrigé : ";
							this.StartMonitorigChasse();
						}
						else
						{
							this._lastIndiceIsPhorreur = false;
							if (this._modeOffline == "True")
							{
								ValueTuple<int, int, string> position = this._Hunt.GetIndicePositionOfflineAuto(correctedText, CS$<>8__locals2.arrow, this._currentX, this._currentY);
								if (correctedText != position.Item3)
								{
									this.labelControl_HuntAuto_IndiceCor.Text = "Indice corrigé : " + position.Item3;
									this.labelControl_HuntAuto_IndiceCor.Visible = true;
								}
								else
								{
									this.labelControl_HuntAuto_IndiceCor.Visible = false;
									this.labelControl_HuntAuto_IndiceCor.Text = "Indice corrigé : ";
								}
								if (position.Item1 == -99 && position.Item2 == -99)
								{
									this._Dofus_Hunt.AddLog("Position de l'indice non trouvée. Veuillez réessayer.");
									this.simpleButton_HuntAutoStart.Enabled = true;
									this.simpleButton_HuntAutoStop.Enabled = false;
									if (this._notify == "True")
									{
										this.toastNotificationsManager.ShowNotification("App_GetData");
									}
									return;
								}
								Control control2 = this.labelControl_HuntAuto_MapIndice;
								defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
								defaultInterpolatedStringHandler.AppendLiteral("Map de l'indice : [");
								defaultInterpolatedStringHandler.AppendFormatted(position.Item1.ToString());
								defaultInterpolatedStringHandler.AppendLiteral(", ");
								defaultInterpolatedStringHandler.AppendFormatted(position.Item2.ToString());
								defaultInterpolatedStringHandler.AppendLiteral("]");
								control2.Text = defaultInterpolatedStringHandler.ToStringAndClear();
								this._currentX = position.Item1;
								this._currentY = position.Item2;
								if (this.checkEdit_HuntAuto_AutoTravel.Checked)
								{
									Clipboard.SetText("/travel " + position.Item1.ToString() + " " + position.Item2.ToString());
								}
								if (this._notify == "True")
								{
									this.toastNotificationsManager.ShowNotification("Indice_OK");
								}
								this.StartMonitorigChasse();
							}
							else
							{
								await Task.Run<string>(() => CS$<>8__locals2.CS$<>8__locals1.<>4__this._Hunt.GetIndice(CS$<>8__locals2.CS$<>8__locals1.<>4__this._token, CS$<>8__locals2.CS$<>8__locals1.<>4__this._currentX.ToString(), CS$<>8__locals2.CS$<>8__locals1.<>4__this._currentY.ToString(), CS$<>8__locals2.arrow));
								ValueTuple<int, int, string> position2 = await Task.Run<ValueTuple<int, int, string>>(() => CS$<>8__locals2.CS$<>8__locals1.<>4__this._Hunt.GetIndicePosition(CS$<>8__locals2.indice, CS$<>8__locals2.CS$<>8__locals1.<>4__this._lastDetectedIndice, CS$<>8__locals2.CS$<>8__locals1.<>4__this._currentX, CS$<>8__locals2.CS$<>8__locals1.<>4__this._currentY));
								if (correctedText != position2.Item3)
								{
									this.labelControl_HuntAuto_IndiceCor.Text = "Indice corrigé : " + position2.Item3;
									this.labelControl_HuntAuto_IndiceCor.Visible = true;
								}
								else
								{
									this.labelControl_HuntAuto_IndiceCor.Visible = false;
									this.labelControl_HuntAuto_IndiceCor.Text = "Indice corrigé : ";
								}
								if (position2.Item1 == -99 && position2.Item2 == -99)
								{
									this._Dofus_Hunt.AddLog("Position de l'indice non trouvée. Veuillez réessayer.");
									this.simpleButton_HuntAutoStart.Enabled = true;
									this.simpleButton_HuntAutoStop.Enabled = false;
									if (this._notify == "True")
									{
										this.toastNotificationsManager.ShowNotification("App_GetData");
									}
									return;
								}
								Control control3 = this.labelControl_HuntAuto_MapIndice;
								defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
								defaultInterpolatedStringHandler.AppendLiteral("Map de l'indice : [");
								defaultInterpolatedStringHandler.AppendFormatted(position2.Item1.ToString());
								defaultInterpolatedStringHandler.AppendLiteral(", ");
								defaultInterpolatedStringHandler.AppendFormatted(position2.Item2.ToString());
								defaultInterpolatedStringHandler.AppendLiteral("]");
								control3.Text = defaultInterpolatedStringHandler.ToStringAndClear();
								this._currentX = position2.Item1;
								this._currentY = position2.Item2;
								if (this.checkEdit_HuntAuto_AutoTravel.Checked)
								{
									Clipboard.SetText("/travel " + position2.Item1.ToString() + " " + position2.Item2.ToString());
								}
								if (this._notify == "True")
								{
									this.toastNotificationsManager.ShowNotification("Indice_OK");
								}
								this.StartMonitorigChasse();
							}
						}
						CS$<>8__locals2 = null;
						correctedText = null;
					}
				}
			}
			else
			{
				this._Dofus_Hunt.AddLog("L'image recadrée n'a pas été trouvée. Veuillez réessayer.");
				this.ResetInterfaceChasse();
				if (this._notify == "True")
				{
					this.toastNotificationsManager.ShowNotification("Hunt_NoData");
				}
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005714 File Offset: 0x00003914
		private void StartMonitorigChasse()
		{
			FormHome.<>c__DisplayClass112_0 CS$<>8__locals1 = new FormHome.<>c__DisplayClass112_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.erreurs = 0;
			this._cancellationTokenSource = new CancellationTokenSource();
			CS$<>8__locals1.token = this._cancellationTokenSource.Token;
			Thread thread = new Thread(delegate
			{
				FormHome.<>c__DisplayClass112_0.<<StartMonitorigChasse>b__0>d <<StartMonitorigChasse>b__0>d;
				<<StartMonitorigChasse>b__0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
				<<StartMonitorigChasse>b__0>d.<>4__this = CS$<>8__locals1;
				<<StartMonitorigChasse>b__0>d.<>1__state = -1;
				<<StartMonitorigChasse>b__0>d.<>t__builder.Start<FormHome.<>c__DisplayClass112_0.<<StartMonitorigChasse>b__0>d>(ref <<StartMonitorigChasse>b__0>d);
			});
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000576C File Offset: 0x0000396C
		private void simpleButton_HuntAutoStop_Click(object sender, EventArgs e)
		{
			if (this._cancellationTokenSource != null)
			{
				this._cancellationTokenSource.Cancel();
				if (this._advancedLog == "True")
				{
					this._Dofus_Hunt.AddLog("Demande d'annulation de la surveillance de l'indice envoyée.");
				}
				this.ResetInterfaceChasse();
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000057AC File Offset: 0x000039AC
		private void labelControl_HuntAuto_IndiceCor_Click(object sender, EventArgs e)
		{
			if (this.labelControl_HuntAuto_IndiceCor.Text != "Indice corrigé :")
			{
				string labelText_Ok = this.labelControl_HuntAuto_IndiceCor.Text;
				string prefix_Ok = "Indice corrigé : ";
				string correctedIndice_Ok = string.Empty;
				if (labelText_Ok.StartsWith(prefix_Ok))
				{
					correctedIndice_Ok = labelText_Ok.Substring(prefix_Ok.Length).Trim();
				}
				string labelText = this.labelControl_HuntAuto_Indice.Text;
				string prefix = "Indice : ";
				string correctedIndice = string.Empty;
				if (labelText.StartsWith(prefix))
				{
					correctedIndice = labelText.Substring(prefix.Length).Trim();
				}
				try
				{
					string detectedText = correctedIndice;
					string correctedText = correctedIndice_Ok;
					if (string.IsNullOrEmpty(detectedText) || string.IsNullOrEmpty(correctedText))
					{
						MessageBox.Show("Veuillez remplir les deux champs avant de sauvegarder.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else if (!File.Exists(FormHome._configPath + "/corrections.xml"))
					{
						new XDocument(new object[]
						{
							new XElement("Corrections", new XElement("Correction", new object[]
							{
								new XElement("Erroneous", detectedText),
								new XElement("Correct", correctedText)
							}))
						}).Save(FormHome._configPath + "/corrections.xml");
						if (this._notify == "True")
						{
							this.toastNotificationsManager.ShowNotification("Indice_Correct");
						}
					}
					else
					{
						XDocument doc = XDocument.Load(FormHome._configPath + "/corrections.xml");
						XElement existingCorrection = doc.Descendants("Correction").FirstOrDefault(delegate(XElement x)
						{
							XElement xelement = x.Element("Erroneous");
							if (((xelement != null) ? xelement.Value : null) == detectedText)
							{
								XElement xelement2 = x.Element("Correct");
								return ((xelement2 != null) ? xelement2.Value : null) == correctedText;
							}
							return false;
						});
						if (existingCorrection != null)
						{
							existingCorrection.Element("Correct").Value = correctedText;
							if (this._notify == "True")
							{
								this.toastNotificationsManager.ShowNotification("Indice_Correct");
							}
						}
						else
						{
							doc.Element("Corrections").Add(new XElement("Correction", new object[]
							{
								new XElement("Erroneous", detectedText),
								new XElement("Correct", correctedText)
							}));
							if (this._notify == "True")
							{
								this.toastNotificationsManager.ShowNotification("Indice_Correct");
							}
						}
						doc.Save(FormHome._configPath + "/corrections.xml");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00005AA0 File Offset: 0x00003CA0
		private void pictureBox_Discord_Click(object sender, EventArgs e)
		{
			string url = "https://discord.gg/2kBBXQ7R9T";
			Process.Start(new ProcessStartInfo
			{
				FileName = url,
				UseShellExecute = true
			});
		}

		// Token: 0x04000001 RID: 1
		private static readonly string _configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt");

		// Token: 0x04000002 RID: 2
		private static readonly string _logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt", "logs");

		// Token: 0x04000003 RID: 3
		private static readonly string _logPathImg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt", "logs", "img");

		// Token: 0x04000004 RID: 4
		private static readonly string RevisionFilePath = "revision.txt";

		// Token: 0x04000005 RID: 5
		private static readonly string RevisionDHUFilePath = "revision_update.txt";

		// Token: 0x04000006 RID: 6
		private static readonly string configFilePath = FormHome._configPath + "/appSettings.xml";

		// Token: 0x04000007 RID: 7
		[TupleElementNames(new string[] { "posX", "posY" })]
		private Dictionary<string, ValueTuple<int, int>> huntIndicePositions = new Dictionary<string, ValueTuple<int, int>>();

		// Token: 0x04000008 RID: 8
		private Dofus_Hunt _Dofus_Hunt;

		// Token: 0x04000009 RID: 9
		private Hunt _Hunt;

		// Token: 0x0400000A RID: 10
		private CancellationTokenSource _cancellationTokenSource;

		// Token: 0x0400000B RID: 11
		private string _dofus;

		// Token: 0x0400000C RID: 12
		private string _opacity;

		// Token: 0x0400000D RID: 13
		private string _alwaysonscreen;

		// Token: 0x0400000E RID: 14
		private string _dark;

		// Token: 0x0400000F RID: 15
		private string _advancedLog;

		// Token: 0x04000010 RID: 16
		private string _deleteTempFiles;

		// Token: 0x04000011 RID: 17
		private string _deleteLog;

		// Token: 0x04000012 RID: 18
		private string _notify;

		// Token: 0x04000013 RID: 19
		private string _updateDHU;

		// Token: 0x04000014 RID: 20
		private string _version;

		// Token: 0x04000015 RID: 21
		private string _token;

		// Token: 0x04000016 RID: 22
		private string _googleVision;

		// Token: 0x04000017 RID: 23
		private string _modeOffline;

		// Token: 0x04000018 RID: 24
		private string _googleAPI;

		// Token: 0x04000019 RID: 25
		private Timer tokenTimer;

		// Token: 0x0400001A RID: 26
		private string _lastDetectedIndice = string.Empty;

		// Token: 0x0400001B RID: 27
		private bool _lastIndiceIsPhorreur;

		// Token: 0x0400001C RID: 28
		private int _currentX;

		// Token: 0x0400001D RID: 29
		private int _currentY;

		// Token: 0x0400001E RID: 30
		private string _notify_App_Update;

		// Token: 0x0400001F RID: 31
		private string _notify_App_Connect;

		// Token: 0x04000020 RID: 32
		private string _notify_App_GetData;

		// Token: 0x04000021 RID: 33
		private string _notify_App_Restart;

		// Token: 0x04000022 RID: 34
		private string _notify_Hunt_NoData;

		// Token: 0x04000023 RID: 35
		private string _notify_Indice_OK;

		// Token: 0x04000024 RID: 36
		private string _notify_Indice_KO;

		// Token: 0x04000025 RID: 37
		private string _notify_Indice_Phorreur;

		// Token: 0x04000026 RID: 38
		private string _notify_Indice_Correct;

		// Token: 0x04000027 RID: 39
		private int _HuntAutoPosition_X;

		// Token: 0x04000028 RID: 40
		private int _HuntAutoPosition_Y;

		// Token: 0x04000029 RID: 41
		private int _HuntAutoPosition_Width;

		// Token: 0x0400002A RID: 42
		private int _HuntAutoPosition_Height;

		// Token: 0x0400002B RID: 43
		private double _HuntAutoPosition_Threshold;

		// Token: 0x0400002C RID: 44
		private int _HuntAutoPosition_largeurTexte;

		// Token: 0x0400002D RID: 45
		private int _HuntAutoPosition_hauteurTexte;

		// Token: 0x0400002E RID: 46
		private double _HuntAutoIndice_Threshold_Start;

		// Token: 0x0400002F RID: 47
		private double _HuntAutoIndice_Threshold_Coche;

		// Token: 0x04000030 RID: 48
		private double _HuntAutoIndice_Threshold_Arrow;

		// Token: 0x04000031 RID: 49
		private int _HuntAutoIndice_largeurTexte_Start;

		// Token: 0x04000032 RID: 50
		private int _HuntAutoIndice_hauteurTexte_Start;

		// Token: 0x04000033 RID: 51
		private int _HuntAutoIndice_largeurTexte_Coche;

		// Token: 0x04000034 RID: 52
		private int _HuntAutoIndice_hauteurTexte_Coche;

		// Token: 0x04000035 RID: 53
		private int _HuntAutoIndice_similarityThreshold;
	}
}
