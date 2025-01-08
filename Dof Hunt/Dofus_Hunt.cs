using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Dof_Hunt
{
	// Token: 0x02000002 RID: 2
	[NullableContext(1)]
	[Nullable(0)]
	public class Dofus_Hunt
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Dofus_Hunt()
		{
			this.initDirectory();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002318 File Offset: 0x00000518
		public void initDirectory()
		{
			bool flag = !Directory.Exists(this._logPath);
			if (flag)
			{
				Directory.CreateDirectory(this._logPath);
			}
			bool flag2 = !Directory.Exists(this._logPathImg);
			if (flag2)
			{
				Directory.CreateDirectory(this._logPathImg);
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002368 File Offset: 0x00000568
		public bool AddLog(string message)
		{
			bool flag;
			try
			{
				string logPath = this._logPath;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendFormatted<DateTime>(DateTime.Now, "dd-MM-yyyy");
				defaultInterpolatedStringHandler.AppendLiteral(".log");
				string text = Path.Combine(logPath, defaultInterpolatedStringHandler.ToStringAndClear());
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
				defaultInterpolatedStringHandler.AppendLiteral("[");
				defaultInterpolatedStringHandler.AppendFormatted<DateTime>(DateTime.Now, "HH:mm:ss");
				defaultInterpolatedStringHandler.AppendLiteral("] ");
				defaultInterpolatedStringHandler.AppendFormatted(message);
				defaultInterpolatedStringHandler.AppendFormatted(Environment.NewLine);
				string text2 = defaultInterpolatedStringHandler.ToStringAndClear();
				File.AppendAllText(text, text2);
				flag = true;
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002428 File Offset: 0x00000628
		public async Task<bool> PingUrlAsync(string url)
		{
			bool flag;
			using (HttpClient client = new HttpClient())
			{
				try
				{
					HttpResponseMessage httpResponseMessage = await client.GetAsync(url);
					HttpResponseMessage response = httpResponseMessage;
					httpResponseMessage = null;
					flag = response.IsSuccessStatusCode;
				}
				catch (Exception ex)
				{
					this.AddLog("Erreur lors du ping : " + ex.Message);
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002474 File Offset: 0x00000674
		public bool CreateDefaultConfigFileIfNotExists(string filePath)
		{
			bool flag = !File.Exists(filePath);
			bool flag2;
			if (flag)
			{
				using (XmlWriter xmlWriter = XmlWriter.Create(filePath))
				{
					xmlWriter.WriteStartDocument();
					xmlWriter.WriteStartElement("Settings");
					foreach (KeyValuePair<string, string> keyValuePair in this.defaultParameters)
					{
						xmlWriter.WriteStartElement("Parameter");
						xmlWriter.WriteAttributeString("Name", keyValuePair.Key);
						xmlWriter.WriteAttributeString("Value", keyValuePair.Value);
						xmlWriter.WriteEndElement();
					}
					xmlWriter.WriteEndElement();
					xmlWriter.WriteEndDocument();
				}
				flag2 = true;
			}
			else
			{
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002560 File Offset: 0x00000760
		public void EnsureConfigParameters(string filePath)
		{
			bool flag = File.Exists(filePath);
			XDocument xdocument;
			if (flag)
			{
				xdocument = XDocument.Load(filePath);
			}
			else
			{
				xdocument = new XDocument(new object[]
				{
					new XElement("Settings")
				});
			}
			XElement xelement = xdocument.Element("Settings");
			bool flag2 = xelement == null;
			if (flag2)
			{
				xelement = new XElement("Settings");
				xdocument.Add(xelement);
			}
			using (Dictionary<string, string>.Enumerator enumerator = this.defaultParameters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> parameter = enumerator.Current;
					XElement xelement2 = xelement.Elements("Parameter").FirstOrDefault(delegate(XElement p)
					{
						XAttribute xattribute = p.Attribute("Name");
						return ((xattribute != null) ? xattribute.Value : null) == parameter.Key;
					});
					bool flag3 = xelement2 == null;
					if (flag3)
					{
						xelement.Add(new XElement("Parameter", new object[]
						{
							new XAttribute("Name", parameter.Key),
							new XAttribute("Value", parameter.Value)
						}));
					}
				}
			}
			xdocument.Save(filePath);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000026C0 File Offset: 0x000008C0
		public string GetConfigValue(string filePath, string parameterName)
		{
			string text2;
			try
			{
				XDocument xdocument = XDocument.Load(filePath);
				XElement xelement = xdocument.Descendants("Parameter").FirstOrDefault(delegate(XElement p)
				{
					XAttribute xattribute2 = p.Attribute("Name");
					return ((xattribute2 != null) ? xattribute2.Value : null) == parameterName;
				});
				string text;
				if (xelement == null)
				{
					text = null;
				}
				else
				{
					XAttribute xattribute = xelement.Attribute("Value");
					text = ((xattribute != null) ? xattribute.Value : null);
				}
				text2 = text ?? string.Empty;
			}
			catch (Exception)
			{
				text2 = string.Empty;
			}
			return text2;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002750 File Offset: 0x00000950
		public void UpdateParameterValue(string filePath, string parameterName, string newValue)
		{
			XDocument xdocument = XDocument.Load(filePath);
			XElement xelement = xdocument.Descendants("Parameter").FirstOrDefault(delegate(XElement p)
			{
				XAttribute xattribute = p.Attribute("Name");
				return ((xattribute != null) ? xattribute.Value : null) == parameterName;
			});
			bool flag = xelement != null;
			if (flag)
			{
				xelement.SetAttributeValue("Value", newValue);
			}
			else
			{
				XElement xelement2 = new XElement("Parameter", new object[]
				{
					new XAttribute("Name", parameterName),
					new XAttribute("Value", newValue)
				});
				XElement xelement3 = xdocument.Element("Settings");
				if (xelement3 != null)
				{
					xelement3.Add(xelement2);
				}
			}
			xdocument.Save(filePath);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000281C File Offset: 0x00000A1C
		public List<Dofus_Hunt.Correction> LoadCorrections()
		{
			string text = Path.Combine(this._configPath, this._correctionsFile);
			List<Dofus_Hunt.Correction> list = new List<Dofus_Hunt.Correction>();
			bool flag = !File.Exists(text);
			List<Dofus_Hunt.Correction> list2;
			if (flag)
			{
				list2 = list;
			}
			else
			{
				try
				{
					XDocument xdocument = XDocument.Load(text);
					foreach (XElement xelement in xdocument.Descendants("Correction"))
					{
						XElement xelement2 = xelement.Element("Erroneous");
						string text2 = ((xelement2 != null) ? xelement2.Value : null) ?? string.Empty;
						XElement xelement3 = xelement.Element("Correct");
						string text3 = ((xelement3 != null) ? xelement3.Value : null) ?? string.Empty;
						list.Add(new Dofus_Hunt.Correction
						{
							Erroneous = text2,
							Correct = text3
						});
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Erreur lors du chargement des corrections : " + ex.Message, ex);
				}
				list2 = list;
			}
			return list2;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002950 File Offset: 0x00000B50
		public string ReadVersionFromFile(string filePath)
		{
			string text;
			try
			{
				text = File.ReadAllText(filePath).Trim();
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors de la lecture du fichier de version : " + ex.Message);
				text = "Version inconnue";
			}
			return text;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000029A0 File Offset: 0x00000BA0
		public void DeleteOldLogFiles(int daysThreshold)
		{
			try
			{
				bool flag = !Directory.Exists(this._logPath);
				if (!flag)
				{
					string[] files = Directory.GetFiles(this._logPath);
					foreach (string text in files)
					{
						DateTime lastWriteTime = File.GetLastWriteTime(text);
						bool flag2 = lastWriteTime < DateTime.Now.AddDays((double)(-(double)daysThreshold));
						if (flag2)
						{
							File.Delete(text);
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors de la suppression des fichiers de log : " + ex.Message);
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002A4C File Offset: 0x00000C4C
		public string GetJsonUrlFromFile()
		{
			string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update_url.txt");
			bool flag = !File.Exists(text);
			if (flag)
			{
				this.AddLog("Fichier 'update_url.txt' introuvable. Veuillez vérifier son emplacement.");
			}
			string text2 = File.ReadAllText(text).Trim();
			bool flag2 = string.IsNullOrEmpty(text2);
			if (flag2)
			{
				this.AddLog("Le fichier 'update_url.txt' est vide ou invalide.");
			}
			return text2;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002AB8 File Offset: 0x00000CB8
		public string GetVersion()
		{
			string text = this.GetJsonUrlFromFile();
			string text2 = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
			defaultInterpolatedStringHandler.AppendLiteral("?t=");
			defaultInterpolatedStringHandler.AppendFormatted<long>(DateTime.UtcNow.Ticks);
			text = text2 + defaultInterpolatedStringHandler.ToStringAndClear();
			string text4;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
				httpWebRequest.Method = "GET";
				using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
				{
					using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
					{
						string text3 = streamReader.ReadToEnd();
						Dofus_Hunt.UpdateInfo updateInfo = JsonConvert.DeserializeObject<Dofus_Hunt.UpdateInfo>(text3);
						text4 = updateInfo.LatestVersion;
					}
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur : " + ex.Message);
				text4 = null;
			}
			return text4;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002BCC File Offset: 0x00000DCC
		public string GetVersionUpdate()
		{
			string text = this.GetJsonUrlFromFile();
			string text2 = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
			defaultInterpolatedStringHandler.AppendLiteral("?t=");
			defaultInterpolatedStringHandler.AppendFormatted<long>(DateTime.UtcNow.Ticks);
			text = text2 + defaultInterpolatedStringHandler.ToStringAndClear();
			string text4;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
				httpWebRequest.Method = "GET";
				using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
				{
					using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
					{
						string text3 = streamReader.ReadToEnd();
						Dofus_Hunt.UpdateInfo updateInfo = JsonConvert.DeserializeObject<Dofus_Hunt.UpdateInfo>(text3);
						text4 = updateInfo.latestVersionUpdate;
					}
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur : " + ex.Message);
				text4 = null;
			}
			return text4;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002CE0 File Offset: 0x00000EE0
		public static Dofus_Hunt.UpdateInfo GetUpdateInfo()
		{
			string jsonUrlFromFile = new Dofus_Hunt().GetJsonUrlFromFile();
			Dofus_Hunt.UpdateInfo updateInfo;
			using (HttpClient httpClient = new HttpClient())
			{
				string result = httpClient.GetStringAsync(jsonUrlFromFile).Result;
				updateInfo = JsonConvert.DeserializeObject<Dofus_Hunt.UpdateInfo>(result);
			}
			return updateInfo;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002D34 File Offset: 0x00000F34
		public async Task<string> DownloadUpdateAsync(string updateUrl)
		{
			string tempPath = Path.Combine(Path.GetTempPath(), "update.zip");
			using (WebClient client = new WebClient())
			{
				Dofus_Hunt.<>c__DisplayClass22_0 CS$<>8__locals1 = new Dofus_Hunt.<>c__DisplayClass22_0();
				CS$<>8__locals1.tcs = new TaskCompletionSource<bool>();
				client.DownloadFileCompleted += delegate([Nullable(2)] object s, AsyncCompletedEventArgs e)
				{
					bool flag = e.Error != null;
					if (flag)
					{
						CS$<>8__locals1.tcs.SetException(new Exception("Erreur lors du téléchargement : " + e.Error.Message));
					}
					else
					{
						CS$<>8__locals1.tcs.SetResult(true);
					}
				};
				client.DownloadFileAsync(new Uri(updateUrl), tempPath);
				await CS$<>8__locals1.tcs.Task;
				CS$<>8__locals1 = null;
			}
			WebClient client = null;
			return tempPath;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002D80 File Offset: 0x00000F80
		public string SkinIsDark()
		{
			return this.GetConfigValue(this._configPath + "/appSettings.xml", "Dark");
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002DB0 File Offset: 0x00000FB0
		private bool IsFileLocked(string filePath)
		{
			bool flag;
			try
			{
				using (new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
				{
					flag = false;
				}
			}
			catch (IOException)
			{
				flag = true;
			}
			return flag;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002DFC File Offset: 0x00000FFC
		public void ApplyUpdate(string zipPath)
		{
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string text = Path.Combine(Path.GetTempPath(), "DofusHuntUpdate");
			bool flag = Directory.Exists(text);
			if (flag)
			{
				Directory.Delete(text, true);
			}
			Directory.CreateDirectory(text);
			this.AddLog("Fichier ZIP téléchargé à : " + zipPath);
			this.AddLog("Fichiers extraits dans " + text + " : " + string.Join(", ", Directory.GetFiles(text)));
			foreach (string text2 in Directory.GetFiles(text))
			{
				string fileName = Path.GetFileName(text2);
				string text3 = Path.Combine(baseDirectory, fileName);
				this.AddLog("Tentative de copie : " + text2 + " vers " + text3);
				try
				{
					File.Copy(text2, text3, true);
				}
				catch (Exception ex)
				{
					this.AddLog("Erreur lors de la copie de " + fileName + " : " + ex.Message);
				}
			}
			ZipFile.ExtractToDirectory(zipPath, text, true);
			foreach (string text4 in Directory.GetFiles(text))
			{
				string fileName2 = Path.GetFileName(text4);
				bool flag2 = !fileName2.StartsWith("DevExpress") && !fileName2.Equals("Newtonsoft.Json.dll");
				if (flag2)
				{
					string text5 = Path.Combine(baseDirectory, fileName2);
					File.Copy(text4, text5, true);
				}
			}
			File.Delete(zipPath);
			Directory.Delete(text, true);
		}

		// Token: 0x04000001 RID: 1
		private readonly string _logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt", "logs");

		// Token: 0x04000002 RID: 2
		private readonly string _logPathImg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt", "logs", "img");

		// Token: 0x04000003 RID: 3
		private string _configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt");

		// Token: 0x04000004 RID: 4
		private string _correctionsFile = "corrections.xml";

		// Token: 0x04000005 RID: 5
		private Dictionary<string, string> defaultParameters = new Dictionary<string, string>
		{
			{ "Opacity", "100" },
			{ "AlwaysOnScreen", "True" },
			{ "Dark", "True" },
			{ "AdvancedLog", "False" },
			{ "DeleteTempFiles", "True" },
			{ "DeleteLogs", "True" },
			{ "Notify", "True" },
			{ "UpdateDHU", "True" },
			{ "HuntAuto_GoogleVision", "False" },
			{ "HuntAuto_Offline", "False" },
			{ "HuntAutoPosition_X", "0" },
			{ "HuntAutoPosition_Y", "0" },
			{ "HuntAutoPosition_width", "300" },
			{ "HuntAutoPosition_height", "300" },
			{ "HuntAutoPosition_threshold", "0,4" },
			{ "HuntAutoPosition_largeurTexte", "85" },
			{ "HuntAutoPosition_hauteurTexte", "25" },
			{ "HuntAutoIndice_OCRStart", "0,7" },
			{ "HuntAutoIndice_LStart", "300" },
			{ "HuntAutoIndice_HStart", "500" },
			{ "HuntAutoIndice_OCRCoche", "0,8" },
			{ "HuntAutoIndice_LIndice", "190" },
			{ "HuntAutoIndice_HIndice", "40" },
			{ "HuntAutoIndice_OCRArrow", "0,8" },
			{ "HuntAutoIndice_similarityThreshold", "70" },
			{ "Notify_App_Update", "Une mise à jour est disponible !" },
			{ "Notify_App_Connect", "Problème de connexion, vérifier votre connexion ou réessayer plus tard." },
			{ "Notify_App_GetData", "Erreur lors de la récupération des données." },
			{ "Notify_App_Restart", "L'application demande un redémarrage." },
			{ "Notify_Hunt_NoData", "Aucune données trouvée à la position." },
			{ "Notify_Indice_OK", "Merci de vous rendre à la position pour continuer." },
			{ "Notify_Indice_KO", "Erreur lors de la récupération de la position de l'indice ...\nPeut être vérifier l'indice détecté et faire une correction manuelle." },
			{ "Notify_Indice_Phorreur", "L'indice en cours semble être un Phorreur, pourquoi ne pas le faire manuellement ?" },
			{ "Notify_Indice_Correct", "Correction d'indice ajoutée avec succès." }
		};

		// Token: 0x02000008 RID: 8
		[Nullable(0)]
		public class Correction
		{
			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000048 RID: 72 RVA: 0x00005FA8 File Offset: 0x000041A8
			// (set) Token: 0x06000049 RID: 73 RVA: 0x00005FB0 File Offset: 0x000041B0
			public string Erroneous { get; set; }

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x0600004A RID: 74 RVA: 0x00005FB9 File Offset: 0x000041B9
			// (set) Token: 0x0600004B RID: 75 RVA: 0x00005FC1 File Offset: 0x000041C1
			public string Correct { get; set; }
		}

		// Token: 0x02000009 RID: 9
		[Nullable(0)]
		public class UpdateInfo
		{
			// Token: 0x1700000B RID: 11
			// (get) Token: 0x0600004D RID: 77 RVA: 0x00005FD3 File Offset: 0x000041D3
			// (set) Token: 0x0600004E RID: 78 RVA: 0x00005FDB File Offset: 0x000041DB
			[JsonProperty("latestVersion")]
			public string LatestVersion { get; set; }

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x0600004F RID: 79 RVA: 0x00005FE4 File Offset: 0x000041E4
			// (set) Token: 0x06000050 RID: 80 RVA: 0x00005FEC File Offset: 0x000041EC
			[JsonProperty("latestVersionUpdate")]
			public string latestVersionUpdate { get; set; }

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000051 RID: 81 RVA: 0x00005FF5 File Offset: 0x000041F5
			// (set) Token: 0x06000052 RID: 82 RVA: 0x00005FFD File Offset: 0x000041FD
			[JsonProperty("updateUrlUpdate")]
			public string updateUrlUpdate { get; set; }
		}
	}
}
