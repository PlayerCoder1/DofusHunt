using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Tesseract;

namespace Dofus_Hunt
{
	// Token: 0x02000003 RID: 3
	internal class DofusHunt
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000029B0 File Offset: 0x00000BB0
		public DofusHunt(int log, int seuil)
		{
			this._advencedLog = log;
			this._seuil = seuil;
			this.initDirectory();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002A38 File Offset: 0x00000C38
		public async Task<bool> PingUrlAsync(string url)
		{
			bool flag;
			using (HttpClient client = new HttpClient())
			{
				try
				{
					flag = (await client.GetAsync(url)).IsSuccessStatusCode;
				}
				catch (Exception ex)
				{
					this.AddLog("Erreur lors du ping : " + ex.Message);
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020CD File Offset: 0x000002CD
		public void initDirectory()
		{
			if (!Directory.Exists(this._logPath))
			{
				Directory.CreateDirectory(this._logPath);
			}
			if (!Directory.Exists(this._logPathImg))
			{
				Directory.CreateDirectory(this._logPathImg);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002A84 File Offset: 0x00000C84
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
				string logMessage = defaultInterpolatedStringHandler.ToStringAndClear();
				File.AppendAllText(text, logMessage);
				flag = true;
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002B38 File Offset: 0x00000D38
		public bool checkLicence()
		{
			bool flag;
			try
			{
				string publicKey = "<RSAKeyValue>\r\n  <Modulus>xBm7x56q8H2ZJRZ7fDtKe0kjSR2w/MlrjxuSerK+tPyQR4o4qWmvdwAoVRpnOAN2r43BovMSeSXT5GC/ZMupafW9JXqH5A7Fi6Di6L6lw7RFMfcAgrWmLk7pr2VGFFEjcN5NQKIH8nTgKQkn9D0TKClSuDzhb5KhWWhy3fVgjUmNuBF9o8+pijg0PEMWpchGBGed33D4isSvNJchvLDpQfUpcNGBo7M/swwweJv9vj1HfehAa0BM6TVsNvCva5l6S+Ib0f5RG8qZmbEU5vDnAyK1eQd7gqVXBB7JBprDTEqBiHT8/iodHTLpSKQ78po2jSDrBRnahvFpqUpiiTQvTQ==</Modulus>\r\n  <Exponent>AQAB</Exponent>\r\n</RSAKeyValue>";
				string licenseFilePath = Path.Combine(new string[] { this._keyPath + "/licence.lic" });
				string pcIdentifier = this.GetPcIdentifier();
				if (File.Exists(licenseFilePath) && this.VerifyLicense(licenseFilePath, pcIdentifier, publicKey))
				{
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors de la validation de la licence :\n" + ex.Message);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002BBC File Offset: 0x00000DBC
		private string GetMacAddress()
		{
			string text;
			try
			{
				foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
				{
					if (adapter.OperationalStatus == OperationalStatus.Up && adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback)
					{
						return adapter.GetPhysicalAddress().ToString();
					}
				}
				text = "UNKNOWN";
			}
			catch
			{
				text = "UNKNOWN";
			}
			return text;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002C24 File Offset: 0x00000E24
		public string GetPcIdentifier()
		{
			string text2;
			try
			{
				string serialNumber = string.Empty;
				foreach (ManagementBaseObject obj in new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia").Get())
				{
					if (obj != null && obj["SerialNumber"] != null)
					{
						string text = obj["SerialNumber"].ToString();
						serialNumber = ((text != null) ? text.Trim() : null);
						break;
					}
				}
				string macAddress = this.GetMacAddress();
				text2 = serialNumber + "_" + macAddress;
			}
			catch
			{
				text2 = "UNKNOWN";
			}
			return text2;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002CD8 File Offset: 0x00000ED8
		private bool VerifyLicense(string licenseFilePath, string pcIdentifier, string publicKey)
		{
			byte[] signedData = File.ReadAllBytes(licenseFilePath);
			byte[] dataToVerify = Encoding.UTF8.GetBytes(pcIdentifier);
			bool flag;
			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				rsa.FromXmlString(publicKey);
				using (SHA256 sha256 = SHA256.Create())
				{
					flag = rsa.VerifyData(dataToVerify, sha256, signedData);
				}
			}
			return flag;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002D4C File Offset: 0x00000F4C
		public void ListRunningPrograms(ListBoxControl listBoxControl)
		{
			foreach (Process process in from p in Process.GetProcesses()
				where p.MainWindowHandle != IntPtr.Zero && !string.IsNullOrWhiteSpace(p.MainWindowTitle)
				select p)
			{
				string windowTitle = process.MainWindowTitle;
				listBoxControl.Items.Add(windowTitle);
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002101 File Offset: 0x00000301
		public void SetSkin(string skinName)
		{
			UserLookAndFeel.Default.SkinName = skinName;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002DC8 File Offset: 0x00000FC8
		public bool CreateDefaultConfigFileIfNotExists(string filePath)
		{
			if (!File.Exists(filePath))
			{
				Dictionary<string, string> defaultParameters = new Dictionary<string, string>
				{
					{ "Opacity", "100" },
					{ "AlwaysOnScreen", "True" },
					{ "LogAdvanced", "False" },
					{ "Dark", "True" },
					{ "Detection", "70" }
				};
				using (XmlWriter writer = XmlWriter.Create(filePath))
				{
					writer.WriteStartDocument();
					writer.WriteStartElement("Settings");
					foreach (KeyValuePair<string, string> parameter in defaultParameters)
					{
						writer.WriteStartElement("Parameter");
						writer.WriteAttributeString("Name", parameter.Key);
						writer.WriteAttributeString("Value", parameter.Value);
						writer.WriteEndElement();
					}
					writer.WriteEndElement();
					writer.WriteEndDocument();
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002EE4 File Offset: 0x000010E4
		public void EnsureConfigParameters(string filePath)
		{
			Dictionary<string, string> defaultParameters = new Dictionary<string, string>
			{
				{ "Opacity", "100" },
				{ "AlwaysOnScreen", "True" },
				{ "LogAdvanced", "False" },
				{ "Dark", "True" },
				{ "Detection", "70" }
			};
			XDocument doc;
			if (File.Exists(filePath))
			{
				doc = XDocument.Load(filePath);
			}
			else
			{
				doc = new XDocument(new object[]
				{
					new XElement("Settings")
				});
			}
			XElement settingsElement = doc.Element("Settings");
			if (settingsElement == null)
			{
				settingsElement = new XElement("Settings");
				doc.Add(settingsElement);
			}
			using (Dictionary<string, string>.Enumerator enumerator = defaultParameters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> parameter = enumerator.Current;
					if (settingsElement.Elements("Parameter").FirstOrDefault(delegate(XElement p)
					{
						XAttribute xattribute = p.Attribute("Name");
						return ((xattribute != null) ? xattribute.Value : null) == parameter.Key;
					}) == null)
					{
						settingsElement.Add(new XElement("Parameter", new object[]
						{
							new XAttribute("Name", parameter.Key),
							new XAttribute("Value", parameter.Value)
						}));
					}
				}
			}
			doc.Save(filePath);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00003070 File Offset: 0x00001270
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

		// Token: 0x06000010 RID: 16 RVA: 0x000030BC File Offset: 0x000012BC
		public string GetConfigValue(string filePath, string parameterName)
		{
			string text2;
			try
			{
				XElement xelement = XDocument.Load(filePath).Descendants("Parameter").FirstOrDefault(delegate(XElement p)
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

		// Token: 0x06000011 RID: 17 RVA: 0x00003144 File Offset: 0x00001344
		public void UpdateParameterValue(string filePath, string parameterName, string newValue)
		{
			XDocument doc = XDocument.Load(filePath);
			XElement parameter = doc.Descendants("Parameter").FirstOrDefault(delegate(XElement p)
			{
				XAttribute xattribute = p.Attribute("Name");
				return ((xattribute != null) ? xattribute.Value : null) == parameterName;
			});
			if (parameter != null)
			{
				parameter.SetAttributeValue("Value", newValue);
			}
			else
			{
				XElement newParameter = new XElement("Parameter", new object[]
				{
					new XAttribute("Name", parameterName),
					new XAttribute("Value", newValue)
				});
				XElement xelement = doc.Element("Settings");
				if (xelement != null)
				{
					xelement.Add(newParameter);
				}
			}
			doc.Save(filePath);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003204 File Offset: 0x00001404
		public void DeleteOldLogFiles(int daysThreshold = 3)
		{
			try
			{
				if (Directory.Exists(this._logPath))
				{
					foreach (string file in Directory.GetFiles(this._logPath))
					{
						if (File.GetLastWriteTime(file) < DateTime.Now.AddDays((double)(-(double)daysThreshold)))
						{
							File.Delete(file);
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors de la suppression des fichiers de log : " + ex.Message);
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003290 File Offset: 0x00001490
		private string GetJsonUrlFromFile()
		{
			string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update_url.txt");
			if (!File.Exists(text))
			{
				this.AddLog("Fichier 'update_url.txt' introuvable. Veuillez vérifier son emplacement.");
			}
			string text2 = File.ReadAllText(text).Trim();
			if (string.IsNullOrEmpty(text2))
			{
				this.AddLog("Le fichier 'update_url.txt' est vide ou invalide.");
			}
			return text2;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000032E4 File Offset: 0x000014E4
		public string GetVersion()
		{
			string url = this.GetJsonUrlFromFile();
			string text = url;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
			defaultInterpolatedStringHandler.AppendLiteral("?t=");
			defaultInterpolatedStringHandler.AppendFormatted<long>(DateTime.UtcNow.Ticks);
			url = text + defaultInterpolatedStringHandler.ToStringAndClear();
			string text2;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
				httpWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
				httpWebRequest.Method = "GET";
				using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
				{
					using (StreamReader reader = new StreamReader(response.GetResponseStream()))
					{
						text2 = JsonConvert.DeserializeObject<DofusHunt.UpdateInfo>(reader.ReadToEnd()).LatestVersion;
					}
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur : " + ex.Message);
				text2 = null;
			}
			return text2;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000210E File Offset: 0x0000030E
		public string SkinIsDark()
		{
			return this.GetConfigValue(this._keyPath + "/appSettings.xml", "Dark");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000033E0 File Offset: 0x000015E0
		public int LevenshteinDistance(string source, string target)
		{
			if (string.IsNullOrEmpty(source))
			{
				if (!string.IsNullOrEmpty(target))
				{
					return target.Length;
				}
				return 0;
			}
			else
			{
				if (string.IsNullOrEmpty(target))
				{
					return source.Length;
				}
				int sourceLength = source.Length;
				int targetLength = target.Length;
				int[,] distance = new int[sourceLength + 1, targetLength + 1];
				int i = 0;
				while (i <= sourceLength)
				{
					distance[i, 0] = i++;
				}
				int j = 0;
				while (j <= targetLength)
				{
					distance[0, j] = j++;
				}
				for (int k = 1; k <= sourceLength; k++)
				{
					for (int l = 1; l <= targetLength; l++)
					{
						int cost = ((target[l - 1] != source[k - 1]) ? 1 : 0);
						distance[k, l] = Math.Min(Math.Min(distance[k - 1, l] + 1, distance[k, l - 1] + 1), distance[k - 1, l - 1] + cost);
					}
				}
				return distance[sourceLength, targetLength];
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000034E4 File Offset: 0x000016E4
		public string GetIndice(string token, string x, string y, string direction)
		{
			if (string.IsNullOrEmpty(token))
			{
				this.AddLog("Erreur lors de la récupération des données : token vide.");
				return "0";
			}
			string text;
			try
			{
				IRestClient restClient = new RestClient("https://api.dofusdb.fr/treasure-hunt", null, null, null);
				RestRequest request = new RestRequest();
				request.AddQueryParameter("x", x, true);
				request.AddQueryParameter("y", y, true);
				request.AddQueryParameter("direction", direction, true);
				request.AddQueryParameter("$limit", "50", true);
				request.AddQueryParameter("lang", "fr", true);
				request.AddHeader("Accept", "application/json, text/plain, */*");
				request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/128.0.0.0 Safari/537.36 OPR/114.0.0.0");
				request.AddHeader("Origin", "https://dofusdb.fr");
				request.AddHeader("Referer", "https://dofusdb.fr/");
				request.AddHeader("Token", token);
				RestResponse response = restClient.Get(request);
				if (this._advencedLog == 1)
				{
					this.AddLog("Réponse API :\n" + response.Content);
				}
				if (response.IsSuccessful)
				{
					text = response.Content;
				}
				else
				{
					this.AddLog("Erreur lors de l'appel à l'API : " + response.StatusDescription);
					text = "0";
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors de l'appel à l'API : " + ex.Message);
				text = "0";
			}
			return text;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003654 File Offset: 0x00001854
		[return: TupleElementNames(new string[] { "posX", "posY", "indiceChecked" })]
		public ValueTuple<int, int, string> GetIndicePosition(string jsonContent, string indiceRechercher, int currentX, int currentY)
		{
			ValueTuple<int, int, string> valueTuple;
			try
			{
				IEnumerable<JToken> enumerable = JObject.Parse(jsonContent)["data"];
				int bestPosX = -99;
				int bestPosY = -99;
				string bestnameStr = "";
				int bestDistance = int.MaxValue;
				double bestSimilarity = 0.0;
				int similarityThreshold = this._seuil;
				foreach (JToken data in enumerable)
				{
					foreach (JToken jtoken in ((IEnumerable<JToken>)data["pois"]))
					{
						JToken name = jtoken["name"];
						if (name != null && name["fr"] != null)
						{
							string nameStr = name["fr"].ToString();
							int distance = this.LevenshteinDistance(indiceRechercher, nameStr);
							int maxLength = Math.Max(indiceRechercher.Length, nameStr.Length);
							double similarity = (1.0 - (double)distance / (double)maxLength) * 100.0;
							if (this._advencedLog == 1)
							{
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(61, 4);
								defaultInterpolatedStringHandler.AppendLiteral("Indice : ");
								defaultInterpolatedStringHandler.AppendFormatted(nameStr);
								defaultInterpolatedStringHandler.AppendLiteral(" - Indice Recherché : ");
								defaultInterpolatedStringHandler.AppendFormatted(indiceRechercher);
								defaultInterpolatedStringHandler.AppendLiteral(" - Similarité: ");
								defaultInterpolatedStringHandler.AppendFormatted<double>(similarity);
								defaultInterpolatedStringHandler.AppendLiteral("% - Distance : ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(distance);
								this.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
							}
							if (similarity >= (double)similarityThreshold)
							{
								JToken jtoken2 = data["posX"];
								int posX = ((jtoken2 != null) ? jtoken2.Value<int>() : 0);
								JToken jtoken3 = data["posY"];
								int posY = ((jtoken3 != null) ? jtoken3.Value<int>() : 0);
								int positionDistance = Math.Abs(posX - currentX) + Math.Abs(posY - currentY);
								if (similarity > bestSimilarity || (similarity == bestSimilarity && positionDistance < bestDistance))
								{
									bestSimilarity = similarity;
									bestDistance = positionDistance;
									bestPosX = posX;
									bestPosY = posY;
									bestnameStr = nameStr;
								}
							}
						}
					}
				}
				if (bestPosX != -99 && bestPosY != -99)
				{
					valueTuple = new ValueTuple<int, int, string>(bestPosX, bestPosY, bestnameStr);
				}
				else
				{
					this.AddLog("Indice " + indiceRechercher + " non trouvé dans le fichier JSON.");
					if (this._advencedLog == 1)
					{
						this.AddLog("JSON :\n" + jsonContent);
					}
					valueTuple = new ValueTuple<int, int, string>(-99, -99, null);
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors du traitement du JSON : " + ex.Message);
				valueTuple = new ValueTuple<int, int, string>(-99, -99, null);
			}
			return valueTuple;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003924 File Offset: 0x00001B24
		public Bitmap CaptureWindow(Rectangle rect)
		{
			Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
			using (Graphics g = Graphics.FromImage(bitmap))
			{
				g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
			}
			return bitmap;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000398C File Offset: 0x00001B8C
		public void DetectCurrentMap()
		{
			Mat niveauTemplate = CvInvoke.Imread("ressources/img/niveau.png", ImreadModes.Color);
			if (niveauTemplate.IsEmpty)
			{
				this.AddLog("Erreur : image de 'Niveau' introuvable (niveau.png)");
				return;
			}
			Mat screenMat = new Mat(this._logPathImg + "/screenshot.png", ImreadModes.Color);
			if (screenMat.IsEmpty)
			{
				this.AddLog("Erreur : image source introuvable (screenshot.png)");
				return;
			}
			Rectangle cropRect = new Rectangle(0, 0, 300, 300);
			Mat croppedMap = new Mat(screenMat, cropRect);
			if (this._advencedLog == 1)
			{
				this.AddLog("Image recadrée pour traitement.");
			}
			Mat result = new Mat();
			CvInvoke.MatchTemplate(croppedMap, niveauTemplate, result, TemplateMatchingType.CcoeffNormed, null);
			double minVal = 0.0;
			double maxVal = 0.0;
			Point minLoc = default(Point);
			Point maxLoc = default(Point);
			CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc, null);
			if (this._advencedLog == 1)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Valeur de correspondance maximale pour 'Niveau' : ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(maxVal);
				this.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			double threshold = 0.4;
			if (maxVal >= threshold)
			{
				if (this._advencedLog == 1)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Section 'Niveau' détectée à la position ");
					defaultInterpolatedStringHandler.AppendFormatted<Point>(maxLoc);
					this.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				int offsetX = maxLoc.X - 100;
				int offsetY = maxLoc.Y;
				int largeurTexte = 85;
				int hauteurTexte = 25;
				offsetX = Math.Max(offsetX, 0);
				offsetY = Math.Max(offsetY, 0);
				Rectangle huntArea = new Rectangle(offsetX, offsetY, largeurTexte, hauteurTexte);
				if (this._advencedLog == 1)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(96, 4);
					defaultInterpolatedStringHandler.AppendLiteral("Dimensions de la zone de texte 'Niveau' capturée : Position (X = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(huntArea.X);
					defaultInterpolatedStringHandler.AppendLiteral(", Y = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(huntArea.Y);
					defaultInterpolatedStringHandler.AppendLiteral("), Largeur = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(huntArea.Width);
					defaultInterpolatedStringHandler.AppendLiteral(", Hauteur = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(huntArea.Height);
					this.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				if (huntArea.Right > croppedMap.Width || huntArea.Bottom > croppedMap.Height)
				{
					this.AddLog("Erreur : la zone de texte 'Niveau' à capturer est en dehors des limites de l'image.");
					return;
				}
				Mat croppedDepartMat = new Mat(croppedMap, huntArea);
				CvInvoke.Imwrite(this._logPathImg + "/cropped_map.png", croppedDepartMat, Array.Empty<KeyValuePair<ImwriteFlags, int>>());
				if (this._advencedLog == 1)
				{
					this.AddLog("Zone de texte 'Niveau' recadrée et sauvegardée : cropped_map.png");
					return;
				}
			}
			else
			{
				this.AddLog("Section 'Niveau' non détectée.");
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003C20 File Offset: 0x00001E20
		public bool ExtractCoordinatesSimple(string text, out int x, out int y)
		{
			x = 0;
			y = 0;
			bool flag;
			try
			{
				this.AddLog("Texte fourni pour l'extraction des coordonnées simples : '" + text + "'");
				text = new string(text.Where((char c) => char.IsDigit(c) || c == ',' || c == '-' || c == ' ').ToArray<char>()).Trim();
				if (this._advencedLog == 1)
				{
					this.AddLog("Texte nettoyé pour extraction : '" + text + "'");
				}
				if (text.EndsWith("-"))
				{
					text = text.TrimEnd('-').Trim();
					if (this._advencedLog == 1)
					{
						this.AddLog("Texte après suppression des '-' en fin de chaîne : '" + text + "'");
					}
				}
				if (!text.Contains(","))
				{
					if (this._advencedLog == 1)
					{
						this.AddLog("Le texte ne contient pas de virgule. Extraction impossible.");
					}
					flag = false;
				}
				else
				{
					string[] parts = text.Split(',', StringSplitOptions.None);
					if (this._advencedLog == 1)
					{
						this.AddLog("Parties après division : " + string.Join(" | ", parts));
					}
					if (parts.Length == 2)
					{
						parts[0] = parts[0].TrimStart();
						parts[1] = parts[1].TrimStart();
						parts[0] = (parts[0].StartsWith("-") ? ((parts[0].Length > 3) ? parts[0].Substring(0, 3).Trim() : parts[0].Trim()) : ((parts[0].Length > 2) ? parts[0].Substring(0, 2).Trim() : parts[0].Trim()));
						parts[1] = (parts[1].StartsWith("-") ? ((parts[1].Length > 3) ? parts[1].Substring(0, 3).Trim() : parts[1].Trim()) : ((parts[1].Length > 2) ? parts[1].Substring(0, 2).Trim() : parts[1].Trim()));
						int parsedX;
						int parsedY;
						if (int.TryParse(parts[0], out parsedX) && int.TryParse(parts[1], out parsedY))
						{
							x = parsedX;
							y = parsedY;
							if (this._advencedLog == 1)
							{
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 2);
								defaultInterpolatedStringHandler.AppendLiteral("Coordonnées simples extraites : X = ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(x);
								defaultInterpolatedStringHandler.AppendLiteral(", Y = ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(y);
								this.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
							}
							flag = true;
						}
						else
						{
							this.AddLog("Impossible de convertir les coordonnées.");
							flag = false;
						}
					}
					else
					{
						this.AddLog("Le texte divisé ne contient pas exactement deux parties.");
						flag = false;
					}
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors de l'extraction des coordonnées simples : " + ex.Message);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003ED4 File Offset: 0x000020D4
		public string PerformOCRTesseractMap(string imagePath)
		{
			string text2;
			try
			{
				using (Bitmap preprocessedImage = this.PreprocessImageTesseract(imagePath))
				{
					int newWidth = preprocessedImage.Width * 4;
					int newHeight = preprocessedImage.Height * 4;
					Bitmap enlargedImage = new Bitmap(preprocessedImage, newWidth, newHeight);
					string preprocessedImagePath = Path.Combine(Path.GetDirectoryName(imagePath), "preprocessed_" + Path.GetFileName(imagePath));
					if (this._advencedLog == 1)
					{
						enlargedImage.Save(preprocessedImagePath, global::System.Drawing.Imaging.ImageFormat.Png);
						this.AddLog("Image prétraitée et agrandie sauvegardée : " + preprocessedImagePath);
					}
					using (TesseractEngine engine = new TesseractEngine("./ressources/tessdata", "fra", EngineMode.Default))
					{
						engine.SetVariable("tessedit_char_whitelist", "0123456789-, ");
						engine.SetVariable("tessedit_pageseg_mode", "3");
						engine.SetVariable("load_system_dawg", "F");
						engine.SetVariable("load_freq_dawg", "F");
						engine.SetVariable("user_words_suffix", "user-words");
						engine.SetVariable("user_patterns_suffix", "user-patterns");
						using (Pix img = this.BitmapToPixTesseract(enlargedImage))
						{
							using (Page page = engine.Process(img, null))
							{
								string text = page.GetText();
								if (string.IsNullOrEmpty(text))
								{
									this.AddLog("Aucun texte détecté dans l'image.");
								}
								else if (this._advencedLog == 1)
								{
									this.AddLog("Texte extrait : " + text);
								}
								text2 = text;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors de l'analyse OCR : " + ex.Message);
				text2 = string.Empty;
			}
			return text2;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000040F8 File Offset: 0x000022F8
		private Bitmap PreprocessImageTesseract(string imagePath)
		{
			Bitmap bitmap2;
			using (Bitmap bitmap = new Bitmap(imagePath))
			{
				for (int y = 0; y < bitmap.Height; y++)
				{
					for (int x = 0; x < bitmap.Width; x++)
					{
						Color c = bitmap.GetPixel(x, y);
						int gray = (int)((double)c.R * 0.3 + (double)c.G * 0.59 + (double)c.B * 0.11);
						bitmap.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
					}
				}
				for (int y2 = 0; y2 < bitmap.Height; y2++)
				{
					for (int x2 = 0; x2 < bitmap.Width; x2++)
					{
						int binary = ((bitmap.GetPixel(x2, y2).R > 128) ? 255 : 0);
						bitmap.SetPixel(x2, y2, Color.FromArgb(binary, binary, binary));
					}
				}
				using (Graphics g = Graphics.FromImage(bitmap))
				{
					g.SmoothingMode = SmoothingMode.AntiAlias;
					g.InterpolationMode = InterpolationMode.HighQualityBicubic;
					g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				}
				float contrast = 2f;
				float adjustedBrightness = 1f - contrast;
				float[][] array = new float[5][];
				int num = 0;
				float[] array2 = new float[5];
				array2[0] = contrast;
				array[num] = array2;
				int num2 = 1;
				float[] array3 = new float[5];
				array3[1] = contrast;
				array[num2] = array3;
				int num3 = 2;
				float[] array4 = new float[5];
				array4[2] = contrast;
				array[num3] = array4;
				int num4 = 3;
				float[] array5 = new float[5];
				array5[3] = 1f;
				array[num4] = array5;
				array[4] = new float[] { adjustedBrightness, adjustedBrightness, adjustedBrightness, 0f, 1f };
				float[][] ptsArray = array;
				using (Graphics g2 = Graphics.FromImage(bitmap))
				{
					using (ImageAttributes imageAttributes = new ImageAttributes())
					{
						imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
						g2.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
					}
				}
				bitmap2 = (Bitmap)bitmap.Clone();
			}
			return bitmap2;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00004374 File Offset: 0x00002574
		private Pix BitmapToPixTesseract(Bitmap bitmap)
		{
			Pix pix;
			using (MemoryStream stream = new MemoryStream())
			{
				bitmap.Save(stream, global::System.Drawing.Imaging.ImageFormat.Png);
				stream.Position = 0L;
				pix = Pix.LoadFromMemory(stream.ToArray());
			}
			return pix;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000043C4 File Offset: 0x000025C4
		public void DetectAndExtractHuntInfo()
		{
			Mat departTemplate = CvInvoke.Imread("ressources/img/depart_template.png", ImreadModes.Color);
			if (departTemplate.IsEmpty)
			{
				this.AddLog("Erreur : image de 'Départ' introuvable (depart_template.png)");
				return;
			}
			Mat screenMat = new Mat(this._logPathImg + "/screenshot.png", ImreadModes.Color);
			Mat result = new Mat();
			CvInvoke.MatchTemplate(screenMat, departTemplate, result, TemplateMatchingType.CcoeffNormed, null);
			double minVal = 0.0;
			double maxVal = 0.0;
			Point minLoc = default(Point);
			Point maxLoc = default(Point);
			CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc, null);
			if (this._advencedLog == 1)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Valeur de correspondance maximale pour 'Départ' : ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(maxVal);
				this.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			double threshold = 0.7;
			if (maxVal >= threshold)
			{
				if (this._advencedLog == 1)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Section 'Départ' détectée à la position ");
					defaultInterpolatedStringHandler.AppendFormatted<Point>(maxLoc);
					this.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				int offsetX = maxLoc.X - 50;
				int offsetY = maxLoc.Y;
				int largeurTexte = 300;
				int hauteurTexte = 500;
				if (offsetX < 0)
				{
					offsetX = 0;
				}
				if (offsetY < 0)
				{
					offsetY = 0;
				}
				Rectangle huntArea = new Rectangle(offsetX, offsetY, largeurTexte, hauteurTexte);
				if (this._advencedLog == 1)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(96, 4);
					defaultInterpolatedStringHandler.AppendLiteral("Dimensions de la zone de texte 'Départ' capturée : Position (X = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(huntArea.X);
					defaultInterpolatedStringHandler.AppendLiteral(", Y = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(huntArea.Y);
					defaultInterpolatedStringHandler.AppendLiteral("), Largeur = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(huntArea.Width);
					defaultInterpolatedStringHandler.AppendLiteral(", Hauteur = ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(huntArea.Height);
					this.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				if (huntArea.Right > screenMat.Width || huntArea.Bottom > screenMat.Height)
				{
					this.AddLog("Erreur : la zone de texte 'Départ' à capturer est en dehors des limites de l'image.");
					return;
				}
				new Mat(screenMat, huntArea).Save(this._logPathImg + "/cropped_hunt.png");
				if (this._advencedLog == 1)
				{
					this.AddLog("Zone de texte 'Départ' recadrée et sauvegardée : cropped_hunt.png");
					return;
				}
			}
			else
			{
				this.AddLog("Section 'Départ' non détectée.");
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00004608 File Offset: 0x00002808
		public string PerformOCRTesseract(string imagePath)
		{
			string text2;
			try
			{
				using (Bitmap preprocessedImage = this.PreprocessImageTesseract(imagePath))
				{
					using (TesseractEngine engine = new TesseractEngine("./ressources/tessdata", "fra", EngineMode.Default))
					{
						engine.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZÉabcdefghijklmnopqrstuvwxyzçèéêœâ '");
						engine.SetVariable("load_system_dawg", "F");
						engine.SetVariable("load_freq_dawg", "F");
						engine.SetVariable("user_words_suffix", "user-words");
						engine.SetVariable("user_patterns_suffix", "user-patterns");
						using (Pix img = this.BitmapToPixTesseract(preprocessedImage))
						{
							using (Page page = engine.Process(img, null))
							{
								string text = page.GetText();
								if (string.IsNullOrEmpty(text))
								{
									this.AddLog("Aucun texte détecté dans l'image.");
								}
								else
								{
									if (this._advencedLog == 1)
									{
										this.AddLog("Texte extrait : " + text);
									}
									text = this.RemoveTextBeforeFirstUppercase(text);
									if (this._advencedLog == 1)
									{
										this.AddLog("Texte après suppression : '" + text + "'");
									}
								}
								text2 = text;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors de l'analyse OCR : " + ex.Message);
				text2 = string.Empty;
			}
			return text2;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000047D4 File Offset: 0x000029D4
		private string RemoveTextBeforeFirstUppercase(string text)
		{
			int index = text.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZÉ".ToCharArray());
			if (index >= 0)
			{
				while (index > 0 && char.IsWhiteSpace(text[index - 1]))
				{
					index--;
				}
				return text.Substring(index).Trim();
			}
			return text;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00004820 File Offset: 0x00002A20
		public string DetectArrowDirectionAfterOCR(Mat croppedMat)
		{
			this._logPathImg + "/cropped_hunt.png";
			this._logPathImg + "/cropped_text.png";
			string resDirectory = "ressources/img";
			string[] arrowTemplates = new string[] { "fleche_bas.png", "fleche_haut.png", "fleche_gauche.png", "fleche_droite.png" };
			string[] directions = new string[] { "2", "6", "4", "0" };
			bool arrowFound = false;
			string returnArrow = null;
			for (int i = 0; i < arrowTemplates.Length; i++)
			{
				string templatePath = Path.Combine(resDirectory, arrowTemplates[i]);
				Mat arrowTemplate = CvInvoke.Imread(templatePath, ImreadModes.Color);
				if (arrowTemplate.IsEmpty)
				{
					this.AddLog("Erreur : image de la flèche introuvable (" + templatePath + ")");
				}
				else
				{
					Mat resultArrow = new Mat();
					CvInvoke.MatchTemplate(croppedMat, arrowTemplate, resultArrow, TemplateMatchingType.CcoeffNormed, null);
					double minValArrow = 0.0;
					double maxValArrow = 0.0;
					Point minLocArrow = default(Point);
					Point maxLocArrow = default(Point);
					CvInvoke.MinMaxLoc(resultArrow, ref minValArrow, ref maxValArrow, ref minLocArrow, ref maxLocArrow, null);
					if (this._advencedLog == 1)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(54, 2);
						defaultInterpolatedStringHandler.AppendLiteral("Valeur de correspondance maximale pour la flèche '");
						defaultInterpolatedStringHandler.AppendFormatted(directions[i]);
						defaultInterpolatedStringHandler.AppendLiteral("' : ");
						defaultInterpolatedStringHandler.AppendFormatted<double>(maxValArrow);
						this.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					double arrowThreshold = 0.8;
					if (maxValArrow >= arrowThreshold)
					{
						if (this._advencedLog == 1)
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(48, 2);
							defaultInterpolatedStringHandler.AppendLiteral("Flèche détectée pointant vers la ");
							defaultInterpolatedStringHandler.AppendFormatted(directions[i]);
							defaultInterpolatedStringHandler.AppendLiteral(" à la position ");
							defaultInterpolatedStringHandler.AppendFormatted<Point>(maxLocArrow);
							this.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						arrowFound = true;
						returnArrow = directions[i];
						break;
					}
				}
			}
			if (!arrowFound)
			{
				this.AddLog("Flèche non détectée.");
				return null;
			}
			return returnArrow;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00004A10 File Offset: 0x00002C10
		public string GetArrowIcon(string arrow)
		{
			string text;
			if (!(arrow == "6"))
			{
				if (!(arrow == "0"))
				{
					if (!(arrow == "2"))
					{
						if (!(arrow == "4"))
						{
							text = "?";
						}
						else
						{
							text = "←";
						}
					}
					else
					{
						text = "↓";
					}
				}
				else
				{
					text = "→";
				}
			}
			else
			{
				text = "↑";
			}
			return text;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000212B File Offset: 0x0000032B
		public int DetectPhorreur(string indice)
		{
			if (string.IsNullOrEmpty(indice) || !indice.Contains("Phorreur", StringComparison.OrdinalIgnoreCase))
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00004A7C File Offset: 0x00002C7C
		public string GetCorrectedText(string input)
		{
			string text;
			try
			{
				string filePath = this._keyPath + "/corrections.xml";
				if (!File.Exists(filePath))
				{
					throw new FileNotFoundException("Le fichier " + filePath + " n'existe pas.");
				}
				XElement correction = XDocument.Load(filePath).Descendants("Correction").FirstOrDefault((XElement c) => (string)c.Element("Erroneous") == input);
				if (correction != null)
				{
					text = (string)correction.Element("Correct");
				}
				else
				{
					text = input;
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors de la lecture du fichier XML : " + ex.Message);
				text = input;
			}
			return text;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00004B44 File Offset: 0x00002D44
		public string GetGoogleAPIKey(string filePath)
		{
			string text;
			try
			{
				using (Aes aes = Aes.Create())
				{
					aes.Key = Encoding.UTF8.GetBytes(this.encryptionKey.PadRight(32).Substring(0, 32));
					aes.IV = new byte[16];
					ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
					using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
					{
						using (CryptoStream cs = new CryptoStream(fs, decryptor, CryptoStreamMode.Read))
						{
							using (StreamReader sr = new StreamReader(cs))
							{
								text = sr.ReadToEnd();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors du déchiffrement : " + ex.Message);
				text = string.Empty;
			}
			return text;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00004C50 File Offset: 0x00002E50
		public async Task<string> PerformOCRMapWithGoogleVision(string imagePath, string GoogleAPI)
		{
			string text2;
			try
			{
				Bitmap preprocessedImage = this.PreprocessImageGoogleMap(imagePath);
				if (preprocessedImage == null)
				{
					this.AddLog("Erreur lors du prétraitement de l'image.");
					text2 = "0";
				}
				else
				{
					string preprocessedImagePath = this._logPathImg + "/preprocessed_map.png";
					preprocessedImage.Save(preprocessedImagePath, global::System.Drawing.Imaging.ImageFormat.Png);
					if (this._advencedLog == 1)
					{
						this.AddLog("Image prétraitée sauvegardée : " + preprocessedImagePath);
					}
					byte[] imageBytes;
					using (MemoryStream ms = new MemoryStream())
					{
						preprocessedImage.Save(ms, global::System.Drawing.Imaging.ImageFormat.Png);
						imageBytes = ms.ToArray();
					}
					string base64Image = Convert.ToBase64String(imageBytes);
					JObject jobject = new JObject();
					string text3 = "requests";
					JArray jarray = new JArray();
					JObject jobject2 = new JObject();
					string text4 = "image";
					JObject jobject3 = new JObject();
					jobject3["content"] = base64Image;
					jobject2[text4] = jobject3;
					string text5 = "features";
					JArray jarray2 = new JArray();
					JObject jobject4 = new JObject();
					jobject4["type"] = "TEXT_DETECTION";
					jarray2.Add(jobject4);
					jobject2[text5] = jarray2;
					jarray.Add(jobject2);
					jobject[text3] = jarray;
					JObject requestJson = jobject;
					using (HttpClient httpClient = new HttpClient())
					{
						StringContent content = new StringContent(requestJson.ToString(), Encoding.UTF8, "application/json");
						HttpResponseMessage response = await httpClient.PostAsync("https://vision.googleapis.com/v1/images:annotate?key=" + GoogleAPI, content);
						if (!response.IsSuccessStatusCode)
						{
							this.AddLog("Erreur lors de l'appel à l'API Google Cloud Vision : " + response.ReasonPhrase);
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
							defaultInterpolatedStringHandler.AppendLiteral("Statut de la réponse : ");
							defaultInterpolatedStringHandler.AppendFormatted<HttpStatusCode>(response.StatusCode);
							this.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
							this.AddLog("Contenu de la réponse : " + await response.Content.ReadAsStringAsync());
							text2 = "0";
						}
						else
						{
							JToken jtoken = JObject.Parse(await response.Content.ReadAsStringAsync())["responses"];
							string text6;
							if (jtoken == null)
							{
								text6 = null;
							}
							else
							{
								JToken jtoken2 = jtoken[0];
								if (jtoken2 == null)
								{
									text6 = null;
								}
								else
								{
									JToken jtoken3 = jtoken2["fullTextAnnotation"];
									if (jtoken3 == null)
									{
										text6 = null;
									}
									else
									{
										JToken jtoken4 = jtoken3["text"];
										text6 = ((jtoken4 != null) ? jtoken4.ToString() : null);
									}
								}
							}
							string text = text6;
							if (string.IsNullOrEmpty(text))
							{
								this.AddLog("Le texte OCR est vide.");
								text2 = "0";
							}
							else
							{
								if (this._advencedLog == 1)
								{
									this.AddLog("Texte extrait par Google Cloud Vision OCR : " + text);
								}
								string filteredText = new string(text.Where((char c) => "0123456789,-".Contains(c)).ToArray<char>());
								if (this._advencedLog == 1)
								{
									this.AddLog("Texte filtré : " + filteredText);
								}
								string cleanedText = this.CleanExtractedText(filteredText);
								if (this._advencedLog == 1)
								{
									this.AddLog("Texte nettoyé : " + cleanedText);
								}
								text2 = cleanedText;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors de l'analyse OCR avec Google Cloud Vision : " + ex.Message);
				text2 = "0";
			}
			return text2;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002146 File Offset: 0x00000346
		private string CleanExtractedText(string text)
		{
			return Regex.Replace(text, "(?<=\\d)-", "");
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00004CA4 File Offset: 0x00002EA4
		private Bitmap PreprocessImageGoogleMap(string imagePath)
		{
			Bitmap bitmap2;
			using (Bitmap bitmap = new Bitmap(imagePath))
			{
				if (this._advencedLog == 1)
				{
					this.AddLog("Image chargée pour prétraitement : " + imagePath);
				}
				Bitmap grayBitmap = new Bitmap(bitmap.Width, bitmap.Height);
				using (Graphics g = Graphics.FromImage(grayBitmap))
				{
					float[][] array = new float[5][];
					array[0] = new float[] { 0.3f, 0.3f, 0.3f, 0f, 0f };
					array[1] = new float[] { 0.59f, 0.59f, 0.59f, 0f, 0f };
					array[2] = new float[] { 0.11f, 0.11f, 0.11f, 0f, 0f };
					int num = 3;
					float[] array2 = new float[5];
					array2[3] = 1f;
					array[num] = array2;
					array[4] = new float[] { 0f, 0f, 0f, 0f, 1f };
					ColorMatrix colorMatrix = new ColorMatrix(array);
					ImageAttributes attributes = new ImageAttributes();
					attributes.SetColorMatrix(colorMatrix);
					g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);
				}
				if (this._advencedLog == 1)
				{
					this.AddLog("Image convertie en niveaux de gris.");
				}
				Bitmap contrastBitmap = new Bitmap(grayBitmap.Width, grayBitmap.Height);
				using (Graphics g2 = Graphics.FromImage(contrastBitmap))
				{
					float contrast = 1.5f;
					float brightness = 0.2f;
					float[][] array3 = new float[5][];
					int num2 = 0;
					float[] array4 = new float[5];
					array4[0] = contrast;
					array3[num2] = array4;
					int num3 = 1;
					float[] array5 = new float[5];
					array5[1] = contrast;
					array3[num3] = array5;
					int num4 = 2;
					float[] array6 = new float[5];
					array6[2] = contrast;
					array3[num4] = array6;
					int num5 = 3;
					float[] array7 = new float[5];
					array7[3] = 1f;
					array3[num5] = array7;
					array3[4] = new float[] { brightness, brightness, brightness, 0f, 1f };
					ColorMatrix colorMatrix2 = new ColorMatrix(array3);
					ImageAttributes attributes2 = new ImageAttributes();
					attributes2.SetColorMatrix(colorMatrix2);
					g2.DrawImage(grayBitmap, new Rectangle(0, 0, grayBitmap.Width, grayBitmap.Height), 0, 0, grayBitmap.Width, grayBitmap.Height, GraphicsUnit.Pixel, attributes2);
				}
				if (this._advencedLog == 1)
				{
					this.AddLog("Contraste et luminosité ajustés.");
				}
				bitmap2 = (Bitmap)contrastBitmap.Clone();
			}
			return bitmap2;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00004F0C File Offset: 0x0000310C
		private void DeleteFile(string filePath)
		{
			try
			{
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
					if (this._advencedLog == 1)
					{
						this.AddLog("Fichier supprimé : " + filePath);
					}
				}
				else if (this._advencedLog == 1)
				{
					this.AddLog("Fichier non trouvé pour suppression : " + filePath);
				}
			}
			catch (Exception ex)
			{
				this.AddLog("Erreur lors de la suppression du fichier " + filePath + " : " + ex.Message);
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002158 File Offset: 0x00000358
		public string ExtractIndiceText(string labelText)
		{
			if (labelText.StartsWith("Indice : "))
			{
				return labelText.Substring("Indice : ".Length).Trim();
			}
			return labelText;
		}

		// Token: 0x04000001 RID: 1
		private int _advencedLog;

		// Token: 0x04000002 RID: 2
		private readonly string _logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt", "logs");

		// Token: 0x04000003 RID: 3
		private readonly string _logPathImg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt", "logs", "img");

		// Token: 0x04000004 RID: 4
		private readonly string _keyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt");

		// Token: 0x04000005 RID: 5
		private readonly string encryptionKey = "PYDmkmFw5keiTsIhEA4Az6SUnxabZug8l8wSCqfUeDc=";

		// Token: 0x04000006 RID: 6
		private int _seuil;

		// Token: 0x02000004 RID: 4
		private class UpdateInfo
		{
			// Token: 0x17000001 RID: 1
			// (get) Token: 0x0600002C RID: 44 RVA: 0x0000217E File Offset: 0x0000037E
			// (set) Token: 0x0600002D RID: 45 RVA: 0x00002186 File Offset: 0x00000386
			[JsonProperty("latestVersion")]
			public string LatestVersion { get; set; }
		}
	}
}
