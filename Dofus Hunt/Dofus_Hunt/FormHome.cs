using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AutoIt;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Animation;
using DevExpress.XtraBars.ToastNotifications;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraWaitForm;
using Dofus_Hunt.Properties;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;

namespace Dofus_Hunt
{
	// Token: 0x0200000C RID: 12
	public partial class FormHome : XtraForm
	{
		// Token: 0x06000040 RID: 64 RVA: 0x000055B8 File Offset: 0x000037B8
		public FormHome(string Dofus)
		{
			this.InitializeComponent();
			this._dofus = Dofus;
			this._dofusHunt = new DofusHunt(0, 70);
			this.tokenTimer = new Timer();
			this.tokenTimer.Interval = 3600000;
			this.tokenTimer.Tick += this.Timer_Tick;
			this.tokenTimer.Start();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00005690 File Offset: 0x00003890
		private async void FormHome_Load(object sender, EventArgs e)
		{
			if (this._dofusHunt.CreateDefaultConfigFileIfNotExists(this._configPath + "/appSettings.xml"))
			{
				this._dofusHunt.AddLog("Création de la configuration par défaut.");
			}
			else
			{
				this._dofusHunt.AddLog("Chargement de la configuration.");
			}
			this.initConfig();
			if (this._advancedLog == "True")
			{
				this._dofusHunt = new DofusHunt(1, this._seuil);
			}
			else
			{
				this._dofusHunt = new DofusHunt(0, this._seuil);
			}
			this.version = this._dofusHunt.ReadVersionFromFile("revision.txt");
			this.labelControl_version.Text = "Version : " + this.version;
			if (this._dofusHunt.GetVersion() != this.version)
			{
				this.pictureBox_update.Visible = true;
			}
			this.setConfig();
			this.ConfigToastNotifications();
			string url = "https://dofusdb.fr/fr/tools/treasure-hunt";
			TaskAwaiter<bool> taskAwaiter = this._dofusHunt.PingUrlAsync(url).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<bool> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<bool>);
			}
			if (!taskAwaiter.GetResult())
			{
				this.toastNotificationsManager.ShowNotification("NoDDB");
				this.pictureBox_config.Visible = true;
			}
			else
			{
				await Task.Run(delegate
				{
					this.tokenTimer.Start();
					this.googleAPI = this._dofusHunt.GetGoogleAPIKey("google.xml");
				});
				await this.GetToken();
				this.panelControl_init.Visible = false;
				this.pictureBox_autoHunt.Visible = true;
				this.pictureBox_hunt.Visible = true;
				this.pictureBox_config.Visible = true;
				this.pictureBox_skin.Visible = true;
				this.panelControl_huntauto.Visible = true;
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000056C8 File Offset: 0x000038C8
		private void ConfigToastNotifications()
		{
			this.toastNotificationsManager.ApplicationId = "Dofus Hunt";
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("RestartAppConfig", Resources.logo_64x64, "Dofus Hunt", "Pour prendre effet, l'application doit être redémarrée.", "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("SaveCorrections", Resources.logo_64x64, "Dofus Hunt", "Correction d'indice ajoutée avec succès.", "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("NoDataJSON", Resources.logo_64x64, "Dofus Hunt", "Aucune données trouvée à la position.", "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("ErreurComboBox", Resources.logo_64x64, "Dofus Hunt", "Erreur lors de la récupération des données.", "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("NoIndice", Resources.logo_64x64, "Dofus Hunt", "Indice non trouvé ou invalide.", "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("NoDDB", Resources.logo_64x64, "Dofus Hunt", "Problème lors de la récupération du token, merci de vérifier votre connexion ou réessayer plus tard.", "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("Phorreur", Resources.logo_64x64, "Dofus Hunt", "L'indice en cours semble être un Phorreur, pourquoi ne pas le faire manuellement ?", "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("IndiceOk", Resources.logo_64x64, "Dofus Hunt", "Merci de vous rendre à la position pour continuer.", "", ToastNotificationTemplate.ImageAndText02));
			this.toastNotificationsManager.Notifications.Add(new ToastNotification("IndiceKO", Resources.logo_64x64, "Dofus Hunt", "Erreur lors de la récupération de la position de l'indice ...\nPeut être vérifier l'indice détecté et faire une correction manuelle.", "", ToastNotificationTemplate.ImageAndText02));
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00005898 File Offset: 0x00003A98
		private void setIconSkin()
		{
			string suffix = ((UserLookAndFeel.Default.ActiveSkinName == "Metropolis") ? "" : "_dark");
			foreach (KeyValuePair<PictureBox, string> kvp in new Dictionary<PictureBox, string>
			{
				{ this.pictureBox_autoHunt, "ico_huntauto" },
				{ this.pictureBox_hunt, "ico_hunt" },
				{ this.pictureBox_update, "ico_maj" },
				{ this.pictureBox_config, "ico_config" },
				{ this.pictureBox_skin, "ico_skin" }
			})
			{
				kvp.Key.Image = (Image)Resources.ResourceManager.GetObject(kvp.Value + suffix);
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005984 File Offset: 0x00003B84
		private async Task GetToken()
		{
			this._dofusHunt.AddLog("Mise à jour du token en cours...");
			try
			{
				this.proxyServer = new ProxyServer(true, false, false);
				this.proxyEndPoint = new ExplicitProxyEndPoint(IPAddress.Loopback, 8000, true);
				this.proxyServer.AddEndPoint(this.proxyEndPoint);
				this.proxyServer.Start(true);
				this.proxyServer.BeforeRequest += this.OnRequestCapture;
				ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
				chromeDriverService.HideCommandPromptWindow = true;
				chromeDriverService.SuppressInitialDiagnosticInformation = true;
				ChromeOptions options = new ChromeOptions();
				options.AddArgument("--disable-gpu");
				options.AddArgument("--window-size=1920,1080");
				options.AddArgument("--ignore-certificate-errors");
				options.AddArgument("--proxy-server=127.0.0.1:8000");
				options.AddArgument("--headless");
				using (ChromeDriver driver = new ChromeDriver(chromeDriverService, options))
				{
					driver.Navigate().GoToUrl("https://dofusdb.fr/fr/tools/treasure-hunt");
					await Task.Delay(2000);
					driver.FindElement(By.CssSelector("input[placeholder='X']")).SendKeys("1");
					driver.FindElement(By.CssSelector("input[placeholder='Y']")).SendKeys("1");
					driver.FindElement(By.CssSelector(".treasure-hunt-direction .fa-arrow-left")).Click();
					await Task.Delay(1000);
				}
				ChromeDriver driver = null;
				this.proxyServer.Stop();
				string currentTime = DateTime.Now.ToString("HH:mm:ss");
				base.Invoke(delegate
				{
					this.labelControl_HToken.Text = "Heure du token : " + currentTime;
				});
				this._dofusHunt.AddLog("Token mis à jour avec succès");
			}
			catch (Exception ex)
			{
				this._dofusHunt.AddLog("Erreur lors de la mise à jour du token : " + ex.Message);
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000059C8 File Offset: 0x00003BC8
		private Task OnRequestCapture(object sender, SessionEventArgs e)
		{
			foreach (HttpHeader header in e.HttpClient.Request.Headers)
			{
				if (header.Name.Equals("Token", StringComparison.OrdinalIgnoreCase))
				{
					string token = header.Value;
					base.Invoke(delegate
					{
						this.textEdit_token.Text = token;
					});
					this._token = token;
					break;
				}
			}
			return Task.CompletedTask;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00005A6C File Offset: 0x00003C6C
		private void setConfig()
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action(this.setConfig));
				return;
			}
			double opacityDouble;
			double.TryParse(this._opacity, out opacityDouble);
			int opacityInt;
			int.TryParse(this._opacity, out opacityInt);
			if (opacityDouble >= 0.0 && opacityDouble <= 100.0)
			{
				base.Opacity = opacityDouble / 100.0;
				this.trackBarControl_opacity.Value = opacityInt;
			}
			else
			{
				base.Opacity = 100.0;
				this.trackBarControl_opacity.Value = 100;
			}
			if (this._alwaysonscreen == "True")
			{
				base.TopMost = true;
				this.checkEdit_alwaysonscreen.Checked = true;
			}
			if (this._advancedLog == "True")
			{
				this.checkEdit_AdvancedLogs.Checked = true;
			}
			if (this._dark == "False")
			{
				UserLookAndFeel.Default.SkinName = "Metropolis";
			}
			else
			{
				UserLookAndFeel.Default.SkinName = "Metropolis Dark";
			}
			this.textEdit_ConfigSeuil.Text = this._seuil.ToString();
			this.setIconSkin();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00005B94 File Offset: 0x00003D94
		private void initConfig()
		{
			string configFilePath = this._configPath + "/appSettings.xml";
			this._dofusHunt.EnsureConfigParameters(configFilePath);
			this._opacity = this._dofusHunt.GetConfigValue(configFilePath, "Opacity");
			if (string.IsNullOrEmpty(this._opacity))
			{
				this._opacity = "100";
			}
			this._alwaysonscreen = this._dofusHunt.GetConfigValue(configFilePath, "AlwaysOnScreen");
			this._advancedLog = this._dofusHunt.GetConfigValue(configFilePath, "LogAdvanced");
			this._dark = this._dofusHunt.GetConfigValue(configFilePath, "Dark");
			this._seuil = int.Parse(this._dofusHunt.GetConfigValue(configFilePath, "Detection"));
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005C50 File Offset: 0x00003E50
		private void updateConfig()
		{
			int opacityInt;
			int.TryParse(this._opacity, out opacityInt);
			if (opacityInt != this.trackBarControl_opacity.Value)
			{
				this._dofusHunt.UpdateParameterValue(this._configPath + "/appSettings.xml", "Opacity", this.trackBarControl_opacity.Value.ToString());
			}
			bool alwaysOnScreenValue;
			bool.TryParse(this._alwaysonscreen, out alwaysOnScreenValue);
			if (this.checkEdit_alwaysonscreen.Checked != alwaysOnScreenValue)
			{
				this._dofusHunt.UpdateParameterValue(this._configPath + "/appSettings.xml", "AlwaysOnScreen", this.checkEdit_alwaysonscreen.Checked.ToString());
			}
			bool logAdvencedValue;
			bool.TryParse(this._advancedLog, out logAdvencedValue);
			if (this.checkEdit_AdvancedLogs.Checked != logAdvencedValue)
			{
				this._dofusHunt.UpdateParameterValue(this._configPath + "/appSettings.xml", "LogAdvanced", this.checkEdit_AdvancedLogs.Checked.ToString());
			}
			if (this._dark == "False")
			{
				this._dofusHunt.UpdateParameterValue(this._configPath + "/appSettings.xml", "Dark", "False");
			}
			else
			{
				this._dofusHunt.UpdateParameterValue(this._configPath + "/appSettings.xml", "Dark", "True");
			}
			this._dofusHunt.UpdateParameterValue(this._configPath + "/appSettings.xml", "Detection", this.textEdit_ConfigSeuil.Text);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00005DD8 File Offset: 0x00003FD8
		private void PopulateComboBox(string jsonResponse, int currentX, int currentY)
		{
			try
			{
				this.comboBoxEdit_huntindice.Properties.Items.Clear();
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
							this.comboBoxEdit_huntindice.Properties.Items.Add(name);
						}
						goto IL_0231;
					}
				}
				this.toastNotificationsManager.ShowNotification("NoDataJSON");
				if (this._advancedLog == "True")
				{
					this._dofusHunt.AddLog("Aucune donnée trouvée dans la réponse JSON.");
				}
				IL_0231:;
			}
			catch (Exception ex)
			{
				this.toastNotificationsManager.ShowNotification("ErreurComboBox");
				if (this._advancedLog == "True")
				{
					this._dofusHunt.AddLog("Erreur lors de l'ajout des éléments à la comboBox : " + ex.Message);
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000060C0 File Offset: 0x000042C0
		private void ChangeColorButtonHunt(SimpleButton simpleButton)
		{
			if (this._dark == "False")
			{
				simpleButton.ForeColor = Color.FromArgb(58, 203, 250);
				return;
			}
			simpleButton.ForeColor = Color.FromArgb(220, 135, 13);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000022A8 File Offset: 0x000004A8
		private void RessetColorButtonHunt(SimpleButton simpleButton)
		{
			simpleButton.Appearance.ForeColor = SystemColors.ControlText;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00006110 File Offset: 0x00004310
		private void textEdit_passdebug_EditValueChanged(object sender, EventArgs e)
		{
			string dateFormat = DateTime.Now.ToString("yyyyMMdd");
			if (this.textEdit_passdebug.Text == dateFormat)
			{
				this.checkEdit_debug.Enabled = true;
				return;
			}
			this.checkEdit_debug.Enabled = false;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000615C File Offset: 0x0000435C
		private void trackBarControl_opacity_EditValueChanged(object sender, EventArgs e)
		{
			int trackBarValue = this.trackBarControl_opacity.Value;
			base.Opacity = (double)trackBarValue / 100.0;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000022BA File Offset: 0x000004BA
		private void checkEdit_alwaysonscreen_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkEdit_alwaysonscreen.Checked)
			{
				base.TopMost = true;
				return;
			}
			base.TopMost = false;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000022D8 File Offset: 0x000004D8
		private void checkEdit_AdvancedLogs_CheckedChanged(object sender, EventArgs e)
		{
			this.toastNotificationsManager.ShowNotification("RestartAppConfig");
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000022EA File Offset: 0x000004EA
		private void Timer_Tick(object sender, EventArgs e)
		{
			this.GetToken();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000022F3 File Offset: 0x000004F3
		private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.updateConfig();
			this._dofusHunt.DeleteOldLogFiles(3);
			Application.Exit();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00006188 File Offset: 0x00004388
		private void pictureBox_skin_Click(object sender, EventArgs e)
		{
			if (this._dark == "True")
			{
				this._dark = "False";
				UserLookAndFeel.Default.SkinName = "Metropolis";
			}
			else
			{
				this._dark = "True";
				UserLookAndFeel.Default.SkinName = "Metropolis Dark";
			}
			this.setIconSkin();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000022EA File Offset: 0x000004EA
		private void simpleButton_GetToken_Click(object sender, EventArgs e)
		{
			this.GetToken();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000061E4 File Offset: 0x000043E4
		private void simpleButtonGetPositionIndice_Click(object sender, EventArgs e)
		{
			string indice = this._dofusHunt.GetIndice(this._token, this.textEdit_debugX.Text, this.textEdit_debugY.Text, this.textEdit_debugDirection.Text);
			int currentX = int.Parse(this.textEdit_debugX.Text);
			int currentY = int.Parse(this.textEdit_debugY.Text);
			ValueTuple<int, int, string> position = this._dofusHunt.GetIndicePosition(indice, this.textEdit_debugIndice.Text, currentX, currentY);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(109, 6);
			defaultInterpolatedStringHandler.AppendLiteral("L'indice : ");
			defaultInterpolatedStringHandler.AppendFormatted(this.textEdit_debugIndice.Text);
			defaultInterpolatedStringHandler.AppendLiteral(" qui a comme position de départ [");
			defaultInterpolatedStringHandler.AppendFormatted(this.textEdit_debugX.Text);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted(this.textEdit_debugY.Text);
			defaultInterpolatedStringHandler.AppendLiteral("] vers la direction ");
			defaultInterpolatedStringHandler.AppendFormatted(this.textEdit_debugDirection.Text);
			defaultInterpolatedStringHandler.AppendLiteral(" a été trouvé !\nPosition trouvée :\nX = ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item1);
			defaultInterpolatedStringHandler.AppendLiteral("\nY = ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item2);
			MessageBox.Show(defaultInterpolatedStringHandler.ToStringAndClear(), "Résultat de la recherche", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000632C File Offset: 0x0000452C
		private void simpleButton_Capture_Click(object sender, EventArgs e)
		{
			string windowName = this._dofus;
			AutoItX.WinActivate(windowName, "");
			AutoItX.WinWaitActive(windowName, "", 0);
			if (AutoItX.WinActive(windowName, "") == 1)
			{
				Rectangle winPos = AutoItX.WinGetPos(windowName, "");
				Rectangle captureRect = new Rectangle(winPos.Left, winPos.Top, winPos.Width, winPos.Height);
				this._dofusHunt.CaptureWindow(captureRect).Save(this._logPathImg + "/screenshot.png", ImageFormat.Png);
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000063BC File Offset: 0x000045BC
		private async void simpleButton_GetPosition_Click(object sender, EventArgs e)
		{
			await Task.Run(delegate
			{
				this._dofusHunt.DetectCurrentMap();
			});
			string croppedMapPath = this._logPathImg + "/cropped_map.png";
			if (File.Exists(croppedMapPath))
			{
				string map = await Task.Run<string>(() => this._dofusHunt.PerformOCRTesseractMap(croppedMapPath));
				int X;
				int Y;
				if (!this._dofusHunt.ExtractCoordinatesSimple(map, out X, out Y))
				{
					string mapGoogle = await Task.Run<string>(() => this._dofusHunt.PerformOCRMapWithGoogleVision(croppedMapPath, this.googleAPI));
					this._dofusHunt.ExtractCoordinatesSimple(mapGoogle, out X, out Y);
					DofusHunt dofusHunt = this._dofusHunt;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Coordonnées extraites avec Google Vision [");
					defaultInterpolatedStringHandler.AppendFormatted<int>(X);
					defaultInterpolatedStringHandler.AppendLiteral(", ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(Y);
					defaultInterpolatedStringHandler.AppendLiteral("]");
					dofusHunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
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
					DofusHunt dofusHunt2 = this._dofusHunt;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Coordonnées extraites avec Tesseract [");
					defaultInterpolatedStringHandler.AppendFormatted<int>(X);
					defaultInterpolatedStringHandler.AppendLiteral(", ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(Y);
					defaultInterpolatedStringHandler.AppendLiteral("]");
					dofusHunt2.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
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

		// Token: 0x06000057 RID: 87 RVA: 0x000063F4 File Offset: 0x000045F4
		private void simpleButton_changeIndice_Click(object sender, EventArgs e)
		{
			try
			{
				string detectedText = this.textEdit_detectedindice.Text.Trim();
				string correctedText = this.textEdit_indiceok.Text.Trim();
				if (string.IsNullOrEmpty(detectedText) || string.IsNullOrEmpty(correctedText))
				{
					MessageBox.Show("Veuillez remplir les deux champs avant de sauvegarder.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else if (!File.Exists(this._configPath + "/corrections.xml"))
				{
					new XDocument(new object[]
					{
						new XElement("Corrections", new XElement("Correction", new object[]
						{
							new XElement("Erroneous", detectedText),
							new XElement("Correct", correctedText)
						}))
					}).Save(this._configPath + "/corrections.xml");
					this.toastNotificationsManager.ShowNotification("SaveCorrections");
				}
				else
				{
					XDocument doc = XDocument.Load(this._configPath + "/corrections.xml");
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
						this.toastNotificationsManager.ShowNotification("SaveCorrections");
					}
					else
					{
						doc.Element("Corrections").Add(new XElement("Correction", new object[]
						{
							new XElement("Erroneous", detectedText),
							new XElement("Correct", correctedText)
						}));
						this.toastNotificationsManager.ShowNotification("SaveCorrections");
					}
					doc.Save(this._configPath + "/corrections.xml");
					this.textEdit_detectedindice.Text = (this.textEdit_indiceok.Text = "");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00006654 File Offset: 0x00004854
		private void simpleButton_GetIndice_Click(object sender, EventArgs e)
		{
			string dofus = this._dofus;
			AutoItX.WinActivate(dofus, "");
			AutoItX.WinWaitActive(dofus, "", 0);
			if (AutoItX.WinActive(dofus, "") == 1)
			{
				this._dofusHunt.DetectAndExtractHuntInfo();
				Mat template = CvInvoke.Imread("ressources/img/coche_blanche.png", ImreadModes.Color);
				if (template.IsEmpty)
				{
					this._dofusHunt.AddLog("Erreur : image de la Coche introuvable (coche_blanche.png)");
					return;
				}
				Mat screenMat = new Mat(this._logPathImg + "/cropped_hunt.png", ImreadModes.Color);
				Mat result = new Mat();
				CvInvoke.MatchTemplate(screenMat, template, result, TemplateMatchingType.CcoeffNormed, null);
				double minVal = 0.0;
				double maxVal = 0.0;
				Point minLoc = default(Point);
				Point maxLoc = default(Point);
				CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc, null);
				DofusHunt dofusHunt = this._dofusHunt;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(51, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Valeur de correspondance maximale : ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(maxVal);
				defaultInterpolatedStringHandler.AppendLiteral(" à la position ");
				defaultInterpolatedStringHandler.AppendFormatted<Point>(maxLoc);
				dofusHunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
				if (maxVal >= 0.8)
				{
					DofusHunt dofusHunt2 = this._dofusHunt;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Coche détectée : ");
					defaultInterpolatedStringHandler.AppendFormatted<Point>(maxLoc);
					dofusHunt2.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					int offsetX = maxLoc.X - 450;
					int offsetY = maxLoc.Y - 10;
					int largeurTexte = 190;
					int hauteurTexte = 40;
					if (offsetX < 0)
					{
						offsetX = 0;
					}
					if (offsetY < 0)
					{
						offsetY = 0;
					}
					Rectangle textArea = new Rectangle(offsetX, offsetY, largeurTexte, hauteurTexte);
					DofusHunt dofusHunt3 = this._dofusHunt;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(87, 4);
					defaultInterpolatedStringHandler.AppendLiteral("Dimensions de la zone de texte capturée : Position (X = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(textArea.X);
					defaultInterpolatedStringHandler.AppendLiteral(", Y = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(textArea.Y);
					defaultInterpolatedStringHandler.AppendLiteral("), Largeur = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(textArea.Width);
					defaultInterpolatedStringHandler.AppendLiteral(", Hauteur = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(textArea.Height);
					dofusHunt3.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					new Mat(screenMat, textArea).Save(this._logPathImg + "/cropped_text.png");
					this._dofusHunt.AddLog("Zone de texte recadrée et sauvegardée : cropped_text.png");
					File.ReadAllBytes(this._logPathImg + "/cropped_text.png");
					string extractedText = this._dofusHunt.PerformOCRTesseract(this._logPathImg + "/cropped_text.png");
					MessageBox.Show("Texte extrait : " + extractedText, "Résultat de l'analyse OCR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000068EC File Offset: 0x00004AEC
		private void simpleButton_Arrow_Click(object sender, EventArgs e)
		{
			Mat croppedMat = new Mat(this._logPathImg + "/cropped_text.png", ImreadModes.Color);
			string arrow = this._dofusHunt.DetectArrowDirectionAfterOCR(croppedMat);
			string img_arrow = this._dofusHunt.GetArrowIcon(arrow);
			MessageBox.Show("Direction de la flèche : " + img_arrow, "Résultat de la recherche", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006944 File Offset: 0x00004B44
		private void checkEdit_debug_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkEdit_debug.Checked)
			{
				base.Size = new Size(690, 370);
				this.panelControl_debug.Visible = true;
			}
			if (!this.checkEdit_debug.Checked)
			{
				base.Size = new Size(320, 370);
				this.panelControl_debug.Visible = false;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000230C File Offset: 0x0000050C
		private void pictureBox_config_Click(object sender, EventArgs e)
		{
			this.panelControl_init.Visible = false;
			this.panelControl_config.Visible = true;
			this.panelControl_hunt.Visible = false;
			this.panelControl_huntauto.Visible = false;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000069B0 File Offset: 0x00004BB0
		private void pictureBox_update_Click(object sender, EventArgs e)
		{
			try
			{
				string updateProgramPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dofus Hunt Update.exe");
				if (File.Exists(updateProgramPath))
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = updateProgramPath,
						Verb = "runas"
					});
					Application.Exit();
				}
				else
				{
					MessageBox.Show("Le programme de mise à jour n'a pas été trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00006A44 File Offset: 0x00004C44
		private void pictureBox_hunt_Click(object sender, EventArgs e)
		{
			this.textEdit_huntX.Text = "";
			this.textEdit_huntY.Text = "";
			this.comboBoxEdit_huntindice.Text = "";
			this.comboBoxEdit_huntindice.Properties.Items.Clear();
			this.labelControl_huntresultat.Text = "";
			this.checkEdit_hunt.Checked = true;
			this.panelControl_init.Visible = false;
			this.panelControl_config.Visible = false;
			this.panelControl_hunt.Visible = true;
			this.panelControl_huntauto.Visible = false;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00006AE4 File Offset: 0x00004CE4
		private void comboBoxEdit_huntindice_SelectedIndexChanged(object sender, EventArgs e)
		{
			object selectedItem2 = this.comboBoxEdit_huntindice.SelectedItem;
			string selectedItem = ((selectedItem2 != null) ? selectedItem2.ToString() : null);
			if (!string.IsNullOrEmpty(selectedItem) && this.huntIndicePositions.ContainsKey(selectedItem))
			{
				ValueTuple<int, int> positions = this.huntIndicePositions[selectedItem];
				this.textEdit_huntX.Text = positions.Item1.ToString();
				this.textEdit_huntY.Text = positions.Item2.ToString();
				Control control = this.labelControl_huntresultat;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
				defaultInterpolatedStringHandler.AppendLiteral("[");
				defaultInterpolatedStringHandler.AppendFormatted(positions.Item1.ToString());
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted(positions.Item2.ToString());
				defaultInterpolatedStringHandler.AppendLiteral("]");
				control.Text = defaultInterpolatedStringHandler.ToStringAndClear();
				if (this.checkEdit_hunt.Checked)
				{
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
					defaultInterpolatedStringHandler.AppendLiteral("/travel ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(positions.Item1);
					defaultInterpolatedStringHandler.AppendLiteral(" ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(positions.Item2);
					Clipboard.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				this.comboBoxEdit_huntindice.Text = "";
				this.comboBoxEdit_huntindice.Properties.Items.Clear();
				this.huntIndicePositions.Clear();
				this.RessetColorButtonHunt(this.simpleButton_hunt6);
				this.RessetColorButtonHunt(this.simpleButton_hunt0);
				this.RessetColorButtonHunt(this.simpleButton_hunt2);
				this.RessetColorButtonHunt(this.simpleButton_hunt4);
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00006C7C File Offset: 0x00004E7C
		private void simpleButton_hunt6_Click(object sender, EventArgs e)
		{
			string indice = this._dofusHunt.GetIndice(this._token, this.textEdit_huntX.Text, this.textEdit_huntY.Text, "6");
			int currentX = int.Parse(this.textEdit_huntX.Text);
			int currentY = int.Parse(this.textEdit_huntY.Text);
			this.PopulateComboBox(indice, currentX, currentY);
			this.ChangeColorButtonHunt(this.simpleButton_hunt6);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00006CF0 File Offset: 0x00004EF0
		private void simpleButton_hunt0_Click(object sender, EventArgs e)
		{
			string indice = this._dofusHunt.GetIndice(this._token, this.textEdit_huntX.Text, this.textEdit_huntY.Text, "0");
			int currentX = int.Parse(this.textEdit_huntX.Text);
			int currentY = int.Parse(this.textEdit_huntY.Text);
			this.PopulateComboBox(indice, currentX, currentY);
			this.ChangeColorButtonHunt(this.simpleButton_hunt0);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00006D64 File Offset: 0x00004F64
		private void simpleButton_hunt2_Click(object sender, EventArgs e)
		{
			string indice = this._dofusHunt.GetIndice(this._token, this.textEdit_huntX.Text, this.textEdit_huntY.Text, "2");
			int currentX = int.Parse(this.textEdit_huntX.Text);
			int currentY = int.Parse(this.textEdit_huntY.Text);
			this.PopulateComboBox(indice, currentX, currentY);
			this.ChangeColorButtonHunt(this.simpleButton_hunt2);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00006DD8 File Offset: 0x00004FD8
		private void simpleButton_hunt4_Click(object sender, EventArgs e)
		{
			string indice = this._dofusHunt.GetIndice(this._token, this.textEdit_huntX.Text, this.textEdit_huntY.Text, "4");
			int currentX = int.Parse(this.textEdit_huntX.Text);
			int currentY = int.Parse(this.textEdit_huntY.Text);
			this.PopulateComboBox(indice, currentX, currentY);
			this.ChangeColorButtonHunt(this.simpleButton_hunt4);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000233E File Offset: 0x0000053E
		private void pictureBox_autoHunt_Click(object sender, EventArgs e)
		{
			this.panelControl_init.Visible = false;
			this.panelControl_config.Visible = false;
			this.panelControl_hunt.Visible = false;
			this.panelControl_huntauto.Visible = true;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002370 File Offset: 0x00000570
		private void checkEdit_debug_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00006E4C File Offset: 0x0000504C
		private void simpleButton_stopHunt_Click(object sender, EventArgs e)
		{
			if (this._cancellationTokenSource != null)
			{
				this._cancellationTokenSource.Cancel();
				if (this._advancedLog == "True")
				{
					this._dofusHunt.AddLog("Demande d'annulation de la surveillance de l'indice envoyée.");
				}
				this.checkEdit_huntAutoTravel.Checked = true;
				this.labelControl_huntAutoStart.Text = "Map de départ :";
				this.labelControl_huntAutoIndice.Text = "Indice :";
				this.labelControl_huntAutoIndiceCor.Text = "Indice corrigé :";
				this.labelControl_huntAutoDir.Text = "Direction :";
				this.labelControl_huntAutoMInd.Text = "Map de l'indice :";
				this.simpleButton_startHunt.Enabled = true;
				this.simpleButton_stopHunt.Enabled = false;
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00006F08 File Offset: 0x00005108
		private async void simpleButton_startHunt_Click(object sender, EventArgs e)
		{
			FormHome.<>c__DisplayClass61_0 CS$<>8__locals1 = new FormHome.<>c__DisplayClass61_0();
			CS$<>8__locals1.<>4__this = this;
			string dofus = this._dofus;
			this.simpleButton_startHunt.Enabled = false;
			this.simpleButton_stopHunt.Enabled = true;
			Rectangle winPos = AutoItX.WinGetPos(dofus, "");
			CS$<>8__locals1.captureRect = new Rectangle(winPos.Left, winPos.Top, winPos.Width, winPos.Height);
			(await Task.Run<Bitmap>(() => CS$<>8__locals1.<>4__this._dofusHunt.CaptureWindow(CS$<>8__locals1.captureRect))).Save(this._logPathImg + "/screenshot.png", ImageFormat.Png);
			await Task.Run(delegate
			{
				CS$<>8__locals1.<>4__this._dofusHunt.DetectCurrentMap();
			});
			CS$<>8__locals1.croppedMapPath = this._logPathImg + "/cropped_map.png";
			if (File.Exists(CS$<>8__locals1.croppedMapPath))
			{
				string map = await Task.Run<string>(() => CS$<>8__locals1.<>4__this._dofusHunt.PerformOCRTesseractMap(CS$<>8__locals1.croppedMapPath));
				if (!this._dofusHunt.ExtractCoordinatesSimple(map, out this._currentX, out this._currentY))
				{
					string mapGoogle = await Task.Run<string>(() => CS$<>8__locals1.<>4__this._dofusHunt.PerformOCRMapWithGoogleVision(CS$<>8__locals1.croppedMapPath, CS$<>8__locals1.<>4__this.googleAPI));
					this._dofusHunt.ExtractCoordinatesSimple(mapGoogle, out this._currentX, out this._currentY);
					this.labelControl_huntAutoStart.Text = string.Concat(new string[]
					{
						"Map de départ : [",
						this._currentX.ToString(),
						", ",
						this._currentY.ToString(),
						"]"
					});
					if (this._advancedLog == "True")
					{
						DofusHunt dofusHunt = this._dofusHunt;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 2);
						defaultInterpolatedStringHandler.AppendLiteral("Coordonnées extraites avec Google Vision [");
						defaultInterpolatedStringHandler.AppendFormatted<int>(this._currentX);
						defaultInterpolatedStringHandler.AppendLiteral(", ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(this._currentY);
						defaultInterpolatedStringHandler.AppendLiteral("]");
						dofusHunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
				}
				else
				{
					this.labelControl_huntAutoStart.Text = string.Concat(new string[]
					{
						"Map de départ : [",
						this._currentX.ToString(),
						", ",
						this._currentY.ToString(),
						"]"
					});
					if (this._advancedLog == "True")
					{
						DofusHunt dofusHunt2 = this._dofusHunt;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 2);
						defaultInterpolatedStringHandler.AppendLiteral("Coordonnées extraites avec Tesseract [");
						defaultInterpolatedStringHandler.AppendFormatted<int>(this._currentX);
						defaultInterpolatedStringHandler.AppendLiteral(", ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(this._currentY);
						defaultInterpolatedStringHandler.AppendLiteral("]");
						dofusHunt2.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
				}
				await Task.Run(delegate
				{
					CS$<>8__locals1.<>4__this._dofusHunt.DetectAndExtractHuntInfo();
				});
				Mat template = CvInvoke.Imread("ressources/img/coche_blanche.png", ImreadModes.Color);
				if (template.IsEmpty)
				{
					this._dofusHunt.AddLog("Erreur : image de la Coche introuvable (coche_blanche.png)");
					this.ResetInterfaceChasse();
				}
				else
				{
					Mat screenMat = new Mat(this._logPathImg + "/cropped_hunt.png", ImreadModes.Color);
					Mat result = new Mat();
					CvInvoke.MatchTemplate(screenMat, template, result, TemplateMatchingType.CcoeffNormed, null);
					double minVal = 0.0;
					double maxVal = 0.0;
					Point minLoc = default(Point);
					Point maxLoc = default(Point);
					CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc, null);
					if (this._advancedLog == "True")
					{
						DofusHunt dofusHunt3 = this._dofusHunt;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(51, 2);
						defaultInterpolatedStringHandler.AppendLiteral("Valeur de correspondance maximale : ");
						defaultInterpolatedStringHandler.AppendFormatted<double>(maxVal);
						defaultInterpolatedStringHandler.AppendLiteral(" à la position ");
						defaultInterpolatedStringHandler.AppendFormatted<Point>(maxLoc);
						dofusHunt3.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					if (maxVal >= 0.8)
					{
						FormHome.<>c__DisplayClass61_1 CS$<>8__locals2 = new FormHome.<>c__DisplayClass61_1();
						CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
						if (this._advancedLog == "True")
						{
							DofusHunt dofusHunt4 = this._dofusHunt;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
							defaultInterpolatedStringHandler.AppendLiteral("Coche détectée : ");
							defaultInterpolatedStringHandler.AppendFormatted<Point>(maxLoc);
							dofusHunt4.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						int offsetX = maxLoc.X - 450;
						int offsetY = maxLoc.Y - 10;
						int largeurTexte = 190;
						int hauteurTexte = 40;
						if (offsetX < 0)
						{
							offsetX = 0;
						}
						if (offsetY < 0)
						{
							offsetY = 0;
						}
						Rectangle textArea = new Rectangle(offsetX, offsetY, largeurTexte, hauteurTexte);
						if (this._advancedLog == "True")
						{
							DofusHunt dofusHunt5 = this._dofusHunt;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(87, 4);
							defaultInterpolatedStringHandler.AppendLiteral("Dimensions de la zone de texte capturée : Position (X = ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(textArea.X);
							defaultInterpolatedStringHandler.AppendLiteral(", Y = ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(textArea.Y);
							defaultInterpolatedStringHandler.AppendLiteral("), Largeur = ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(textArea.Width);
							defaultInterpolatedStringHandler.AppendLiteral(", Hauteur = ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(textArea.Height);
							dofusHunt5.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						CS$<>8__locals2.croppedMat = new Mat(screenMat, textArea);
						CS$<>8__locals2.croppedMat.Save(this._logPathImg + "/cropped_text.png");
						if (this._advancedLog == "True")
						{
							this._dofusHunt.AddLog("Zone de texte recadrée et sauvegardée : cropped_text.png");
						}
						File.ReadAllBytes(this._logPathImg + "/cropped_text.png");
						string extractedText = await Task.Run<string>(() => CS$<>8__locals2.CS$<>8__locals1.<>4__this._dofusHunt.PerformOCRTesseract(CS$<>8__locals2.CS$<>8__locals1.<>4__this._logPathImg + "/cropped_text.png"));
						string correctedText = this._dofusHunt.GetCorrectedText(extractedText);
						this._lastDetectedIndice = correctedText;
						this.labelControl_huntAutoIndice.Text = "Indice : " + correctedText;
						CS$<>8__locals2.arrow = await Task.Run<string>(() => CS$<>8__locals2.CS$<>8__locals1.<>4__this._dofusHunt.DetectArrowDirectionAfterOCR(CS$<>8__locals2.croppedMat));
						string arrowDirection = this._dofusHunt.GetArrowIcon(CS$<>8__locals2.arrow);
						this.labelControl_huntAutoDir.Text = "Direction : " + arrowDirection;
						TaskAwaiter<int> taskAwaiter = Task.Run<int>(() => CS$<>8__locals2.CS$<>8__locals1.<>4__this._dofusHunt.DetectPhorreur(CS$<>8__locals2.CS$<>8__locals1.<>4__this._lastDetectedIndice)).GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							TaskAwaiter<int> taskAwaiter2;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter<int>);
						}
						if (taskAwaiter.GetResult() == 1)
						{
							this._lastIndiceIsPhorreur = true;
							if (this._advancedLog == "True")
							{
								this._dofusHunt.AddLog("L'indice est un Phorreur.");
							}
							this.toastNotificationsManager.ShowNotification("Phorreur");
							this.labelControl_huntAutoIndiceCor.Text = "Indice corrigé :";
							this.StartMonitorigChasse();
						}
						else
						{
							FormHome.<>c__DisplayClass61_2 CS$<>8__locals3 = new FormHome.<>c__DisplayClass61_2();
							CS$<>8__locals3.CS$<>8__locals2 = CS$<>8__locals2;
							this._lastIndiceIsPhorreur = false;
							CS$<>8__locals3.indice = await Task.Run<string>(() => CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this._dofusHunt.GetIndice(CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this._token, CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this._currentX.ToString(), CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this._currentY.ToString(), CS$<>8__locals3.CS$<>8__locals2.arrow));
							ValueTuple<int, int, string> position = await Task.Run<ValueTuple<int, int, string>>(() => CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this._dofusHunt.GetIndicePosition(CS$<>8__locals3.indice, CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this._lastDetectedIndice, CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this._currentX, CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this._currentY));
							if (correctedText != position.Item3)
							{
								this.labelControl_huntAutoIndiceCor.Text = "Indice corrigé : " + position.Item3;
							}
							else
							{
								this.labelControl_huntAutoIndiceCor.Text = "Indice corrigé :";
							}
							if (position.Item1 == -99 && position.Item2 == -99)
							{
								this._dofusHunt.AddLog("Erreur de la récupération de la position de l'indice.");
								this.ResetInterfaceChasse();
								return;
							}
							Control control = this.labelControl_huntAutoMInd;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
							defaultInterpolatedStringHandler.AppendLiteral("Map de l'indice : [");
							defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item1);
							defaultInterpolatedStringHandler.AppendLiteral(", ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item2);
							defaultInterpolatedStringHandler.AppendLiteral("]");
							control.Text = defaultInterpolatedStringHandler.ToStringAndClear();
							if (this._advancedLog == "True")
							{
								DofusHunt dofusHunt6 = this._dofusHunt;
								defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 2);
								defaultInterpolatedStringHandler.AppendLiteral("Position de l'indice : [");
								defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item1);
								defaultInterpolatedStringHandler.AppendLiteral(", ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item2);
								defaultInterpolatedStringHandler.AppendLiteral("]");
								dofusHunt6.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
							}
							this._currentX = position.Item1;
							this._currentY = position.Item2;
							if (this.checkEdit_huntAutoTravel.Checked)
							{
								defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
								defaultInterpolatedStringHandler.AppendLiteral("/travel ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item1);
								defaultInterpolatedStringHandler.AppendLiteral(" ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(position.Item2);
								Clipboard.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
							}
							this.toastNotificationsManager.ShowNotification("IndiceOk");
							this.StartMonitorigChasse();
							CS$<>8__locals3 = null;
						}
						CS$<>8__locals2 = null;
						correctedText = null;
					}
					else
					{
						this.simpleButton_startHunt.Enabled = true;
						this.simpleButton_stopHunt.Enabled = false;
						this._dofusHunt.AddLog("La zone de l'indice n'a pas pu être trouvée.");
					}
				}
			}
			else
			{
				this.simpleButton_startHunt.Enabled = true;
				this.simpleButton_stopHunt.Enabled = false;
				this._dofusHunt.AddLog("L'image recadrée n'a pas été trouvée. Veuillez réessayer.");
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00006F40 File Offset: 0x00005140
		private void labelControl_huntAutoIndiceCor_Click(object sender, EventArgs e)
		{
			if (this.labelControl_huntAutoIndiceCor.Text != "Indice corrigé :")
			{
				string labelText_Ok = this.labelControl_huntAutoIndiceCor.Text;
				string prefix_Ok = "Indice corrigé : ";
				string correctedIndice_Ok = string.Empty;
				if (labelText_Ok.StartsWith(prefix_Ok))
				{
					correctedIndice_Ok = labelText_Ok.Substring(prefix_Ok.Length).Trim();
				}
				string labelText = this.labelControl_huntAutoIndice.Text;
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
					else if (!File.Exists(this._configPath + "/corrections.xml"))
					{
						new XDocument(new object[]
						{
							new XElement("Corrections", new XElement("Correction", new object[]
							{
								new XElement("Erroneous", detectedText),
								new XElement("Correct", correctedText)
							}))
						}).Save(this._configPath + "/corrections.xml");
						this.toastNotificationsManager.ShowNotification("SaveCorrections");
					}
					else
					{
						XDocument doc = XDocument.Load(this._configPath + "/corrections.xml");
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
							this.toastNotificationsManager.ShowNotification("SaveCorrections");
						}
						else
						{
							doc.Element("Corrections").Add(new XElement("Correction", new object[]
							{
								new XElement("Erroneous", detectedText),
								new XElement("Correct", correctedText)
							}));
							this.toastNotificationsManager.ShowNotification("SaveCorrections");
						}
						doc.Save(this._configPath + "/corrections.xml");
						this.textEdit_detectedindice.Text = (this.textEdit_indiceok.Text = "");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000721C File Offset: 0x0000541C
		private void ResetInterfaceChasse()
		{
			this.labelControl_huntAutoStart.Text = "Map de départ :";
			this.labelControl_huntAutoIndice.Text = "Indice :";
			this.labelControl_huntAutoIndiceCor.Text = "Indice corrigé :";
			this.labelControl_huntAutoDir.Text = "Direction :";
			this.labelControl_huntAutoMInd.Text = "Map de l'indice :";
			this.simpleButton_startHunt.Enabled = true;
			this.simpleButton_stopHunt.Enabled = false;
			this.checkEdit_huntAutoTravel.Checked = true;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000072A0 File Offset: 0x000054A0
		private void StartMonitorigChasse()
		{
			FormHome.<>c__DisplayClass64_0 CS$<>8__locals1 = new FormHome.<>c__DisplayClass64_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.erreurs = 0;
			this._cancellationTokenSource = new CancellationTokenSource();
			CS$<>8__locals1.token = this._cancellationTokenSource.Token;
			Thread thread = new Thread(delegate
			{
				FormHome.<>c__DisplayClass64_0.<<StartMonitorigChasse>b__0>d <<StartMonitorigChasse>b__0>d;
				<<StartMonitorigChasse>b__0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
				<<StartMonitorigChasse>b__0>d.<>4__this = CS$<>8__locals1;
				<<StartMonitorigChasse>b__0>d.<>1__state = -1;
				<<StartMonitorigChasse>b__0>d.<>t__builder.Start<FormHome.<>c__DisplayClass64_0.<<StartMonitorigChasse>b__0>d>(ref <<StartMonitorigChasse>b__0>d);
			});
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002372 File Offset: 0x00000572
		private void labelControl_huntAutoIndice_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this._dofusHunt.ExtractIndiceText(this.labelControl_huntAutoIndice.Text));
		}

		// Token: 0x0400001E RID: 30
		private string version;

		// Token: 0x0400001F RID: 31
		private string _logPathImg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt", "logs", "img");

		// Token: 0x04000020 RID: 32
		private string _logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt", "logs");

		// Token: 0x04000021 RID: 33
		private string _configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt");

		// Token: 0x04000022 RID: 34
		private const string RevisionFilePath = "revision.txt";

		// Token: 0x04000023 RID: 35
		private DofusHunt _dofusHunt;

		// Token: 0x04000024 RID: 36
		private ProxyServer proxyServer;

		// Token: 0x04000025 RID: 37
		private ExplicitProxyEndPoint proxyEndPoint;

		// Token: 0x04000026 RID: 38
		private CancellationTokenSource _cancellationTokenSource;

		// Token: 0x04000027 RID: 39
		[TupleElementNames(new string[] { "posX", "posY" })]
		private Dictionary<string, ValueTuple<int, int>> huntIndicePositions = new Dictionary<string, ValueTuple<int, int>>();

		// Token: 0x04000028 RID: 40
		private string _dofus;

		// Token: 0x04000029 RID: 41
		private string _opacity;

		// Token: 0x0400002A RID: 42
		private string _advancedLog;

		// Token: 0x0400002B RID: 43
		private string _token;

		// Token: 0x0400002C RID: 44
		private string _alwaysonscreen;

		// Token: 0x0400002D RID: 45
		private string _dark;

		// Token: 0x0400002E RID: 46
		private string _lastDetectedIndice = string.Empty;

		// Token: 0x0400002F RID: 47
		private bool _lastIndiceIsPhorreur;

		// Token: 0x04000030 RID: 48
		private int _currentX;

		// Token: 0x04000031 RID: 49
		private int _currentY;

		// Token: 0x04000032 RID: 50
		private Timer tokenTimer;

		// Token: 0x04000033 RID: 51
		private string googleAPI;

		// Token: 0x04000034 RID: 52
		private int _seuil;
	}
}
