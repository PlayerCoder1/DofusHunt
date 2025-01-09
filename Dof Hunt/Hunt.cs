using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoIt;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using Tesseract;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Http;
using Titanium.Web.Proxy.Models;

namespace Dof_Hunt
{
	// Token: 0x02000005 RID: 5
	[NullableContext(1)]
	[Nullable(0)]
	public class Hunt
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00003040 File Offset: 0x00001240
		public Hunt(string dofus, string log, int seuil)
		{
			this._dofus = dofus;
			this._AdvancedLog = log;
			this._seuil = seuil;
			bool flag = this._AdvancedLog == "True";
			if (flag)
			{
				this._logAdvanced = 1;
			}
			else
			{
				this._logAdvanced = 0;
			}
			this._token = string.Empty;
			this.proxyServer = new ProxyServer(true, false, false);
			this.proxyEndPoint = new ExplicitProxyEndPoint(IPAddress.Loopback, 8000, true);
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00003144 File Offset: 0x00001344
		// (set) Token: 0x06000026 RID: 38 RVA: 0x0000315C File Offset: 0x0000135C
		public string Token
		{
			get
			{
				return this._token;
			}
			private set
			{
				this._token = value;
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003168 File Offset: 0x00001368
		private Task OnRequestCapture(object sender, SessionEventArgs e)
		{
			HeaderCollection headers = e.HttpClient.Request.Headers;
			foreach (HttpHeader httpHeader in headers)
			{
				bool flag = httpHeader.Name.Equals("Token", StringComparison.OrdinalIgnoreCase);
				if (flag)
				{
					this._token = httpHeader.Value;
					bool flag2 = this._logAdvanced == 1;
					if (flag2)
					{
						this._Dofus_Hunt.AddLog("Token mis à jour : " + this._token);
					}
					break;
				}
			}
			return Task.CompletedTask;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000321C File Offset: 0x0000141C
		public async Task GetToken()
		{
			this._Dofus_Hunt.AddLog("Mise à jour du token en cours ...");
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
				this._Dofus_Hunt.AddLog("Token mis à jour avec succès");
				chromeDriverService = null;
				options = null;
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors de la mise à jour du token : " + ex.Message);
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003260 File Offset: 0x00001460
		private Bitmap CaptureWindow(Rectangle rect)
		{
			Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
			}
			return bitmap;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000032D0 File Offset: 0x000014D0
		public void CaptureGame(string Path)
		{
			try
			{
				string dofus = this._dofus;
				Rectangle rectangle = AutoItX.WinGetPos(dofus, "");
				Rectangle rectangle2 = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
				Bitmap bitmap = this.CaptureWindow(rectangle2);
				bitmap.Save(Path, global::System.Drawing.Imaging.ImageFormat.Png);
				bool flag = this._logAdvanced == 1;
				if (flag)
				{
					this._Dofus_Hunt.AddLog("Capture du jeu effectuée avec succès");
				}
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors de la capture du jeu : " + ex.Message);
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003384 File Offset: 0x00001584
		public int LevenshteinDistance(string source, string target)
		{
			bool flag = string.IsNullOrEmpty(source);
			int num;
			if (flag)
			{
				num = (string.IsNullOrEmpty(target) ? 0 : target.Length);
			}
			else
			{
				bool flag2 = string.IsNullOrEmpty(target);
				if (flag2)
				{
					num = source.Length;
				}
				else
				{
					int length = source.Length;
					int length2 = target.Length;
					int[,] array = new int[length + 1, length2 + 1];
					int i = 0;
					while (i <= length)
					{
						array[i, 0] = i++;
					}
					int j = 0;
					while (j <= length2)
					{
						array[0, j] = j++;
					}
					for (int k = 1; k <= length; k++)
					{
						for (int l = 1; l <= length2; l++)
						{
							int num2 = ((target[l - 1] == source[k - 1]) ? 0 : 1);
							array[k, l] = Math.Min(Math.Min(array[k - 1, l] + 1, array[k, l - 1] + 1), array[k - 1, l - 1] + num2);
						}
					}
					num = array[length, length2];
				}
			}
			return num;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000034DC File Offset: 0x000016DC
		public string GetIndice(string token, string x, string y, string direction)
		{
			bool flag = string.IsNullOrEmpty(token);
			string text;
			if (flag)
			{
				this._Dofus_Hunt.AddLog("Erreur lors de la récupération des données : Token d'API vide.");
				text = "0";
			}
			else
			{
				try
				{
					RestClient restClient = new RestClient("https://api.dofusdb.fr/treasure-hunt", null, null, null);
					RestRequest restRequest = new RestRequest();
					restRequest.AddQueryParameter("x", x, true);
					restRequest.AddQueryParameter("y", y, true);
					restRequest.AddQueryParameter("direction", direction, true);
					restRequest.AddQueryParameter("$limit", "50", true);
					restRequest.AddQueryParameter("lang", "fr", true);
					restRequest.AddHeader("Accept", "application/json, text/plain, */*");
					restRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/128.0.0.0 Safari/537.36 OPR/114.0.0.0");
					restRequest.AddHeader("Origin", "https://dofusdb.fr");
					restRequest.AddHeader("Referer", "https://dofusdb.fr/");
					restRequest.AddHeader("Token", token);
					RestResponse restResponse = restClient.Get(restRequest);
					bool flag2 = this._logAdvanced == 1;
					if (flag2)
					{
						this._Dofus_Hunt.AddLog("Réponse API :\n" + restResponse.Content);
					}
					bool isSuccessful = restResponse.IsSuccessful;
					if (isSuccessful)
					{
						text = restResponse.Content;
					}
					else
					{
						this._Dofus_Hunt.AddLog("Erreur lors de l'appel à l'API : " + restResponse.StatusDescription);
						text = "0";
					}
				}
				catch (Exception ex)
				{
					this._Dofus_Hunt.AddLog("Erreur lors de l'appel à l'API : " + ex.Message);
					text = "0";
				}
			}
			return text;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003684 File Offset: 0x00001884
		[return: TupleElementNames(new string[] { "posX", "posY", "indiceChecked" })]
		[return: Nullable(new byte[] { 0, 1 })]
		public ValueTuple<int, int, string> GetIndicePosition(string jsonContent, string indiceRechercher, int currentX, int currentY)
		{
			ValueTuple<int, int, string> valueTuple;
			try
			{
				JObject jobject = JObject.Parse(jsonContent);
				JToken jtoken = jobject["data"];
				int num = -99;
				int num2 = -99;
				string text = "";
				int num3 = int.MaxValue;
				double num4 = 0.0;
				int seuil = this._seuil;
				foreach (JToken jtoken2 in ((IEnumerable<JToken>)jtoken))
				{
					JToken jtoken3 = jtoken2["pois"];
					foreach (JToken jtoken4 in ((IEnumerable<JToken>)jtoken3))
					{
						JToken jtoken5 = jtoken4["name"];
						bool flag = jtoken5 != null && jtoken5["fr"] != null;
						if (flag)
						{
							string text2 = jtoken5["fr"].ToString();
							int num5 = this.LevenshteinDistance(indiceRechercher, text2);
							int num6 = Math.Max(indiceRechercher.Length, text2.Length);
							double num7 = (1.0 - (double)num5 / (double)num6) * 100.0;
							bool flag2 = this._logAdvanced == 1;
							if (flag2)
							{
								Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(61, 4);
								defaultInterpolatedStringHandler.AppendLiteral("Indice : ");
								defaultInterpolatedStringHandler.AppendFormatted(text2);
								defaultInterpolatedStringHandler.AppendLiteral(" - Indice Recherché : ");
								defaultInterpolatedStringHandler.AppendFormatted(indiceRechercher);
								defaultInterpolatedStringHandler.AppendLiteral(" - Similarité: ");
								defaultInterpolatedStringHandler.AppendFormatted<double>(num7);
								defaultInterpolatedStringHandler.AppendLiteral("% - Distance : ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(num5);
								dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
							}
							bool flag3 = num7 >= (double)seuil;
							if (flag3)
							{
								JToken jtoken6 = jtoken2["posX"];
								int num8 = ((jtoken6 != null) ? jtoken6.Value<int>() : 0);
								JToken jtoken7 = jtoken2["posY"];
								int num9 = ((jtoken7 != null) ? jtoken7.Value<int>() : 0);
								int num10 = Math.Abs(num8 - currentX) + Math.Abs(num9 - currentY);
								bool flag4 = num7 > num4 || (num7 == num4 && num10 < num3);
								if (flag4)
								{
									num4 = num7;
									num3 = num10;
									num = num8;
									num2 = num9;
									text = text2;
								}
							}
						}
					}
				}
				bool flag5 = num != -99 && num2 != -99;
				if (flag5)
				{
					valueTuple = new ValueTuple<int, int, string>(num, num2, text);
				}
				else
				{
					this._Dofus_Hunt.AddLog("Indice " + indiceRechercher + " non trouvé dans le fichier JSON.");
					bool flag6 = this._logAdvanced == 1;
					if (flag6)
					{
						this._Dofus_Hunt.AddLog("JSON :\n" + jsonContent);
					}
					valueTuple = new ValueTuple<int, int, string>(-99, -99, null);
				}
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors du traitement du JSON : " + ex.Message);
				valueTuple = new ValueTuple<int, int, string>(-99, -99, null);
			}
			return valueTuple;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000039D0 File Offset: 0x00001BD0
		public void DetectCurrentMap(int x, int y, int width, int height, double threshold, int largeurTexte, int hauteurTexte)
		{
			Mat mat = CvInvoke.Imread("ressources/img/niveau.png", ImreadModes.Color);
			bool isEmpty = mat.IsEmpty;
			if (isEmpty)
			{
				this._Dofus_Hunt.AddLog("Erreur lors de la détection de la map, l'image \"niveau.png\" n'existe pas.");
			}
			else
			{
				Mat mat2 = new Mat(this._logPathImg + "/screenshot.png", ImreadModes.Color);
				bool isEmpty2 = mat2.IsEmpty;
				if (isEmpty2)
				{
					this._Dofus_Hunt.AddLog("Erreur lors de la détection de la map, l'image \"screenshot.png\" n'existe pas.");
				}
				else
				{
					Rectangle rectangle = new Rectangle(x, y, width, height);
					Mat mat3 = new Mat(mat2, rectangle);
					bool flag = this._logAdvanced == 1;
					if (flag)
					{
						this._Dofus_Hunt.AddLog("Image recadrée pour traitement de la poisition.");
					}
					Mat mat4 = new Mat();
					CvInvoke.MatchTemplate(mat3, mat, mat4, TemplateMatchingType.CcoeffNormed, null);
					double num = 0.0;
					double num2 = 0.0;
					Point point = default(Point);
					Point point2 = default(Point);
					CvInvoke.MinMaxLoc(mat4, ref num, ref num2, ref point, ref point2, null);
					bool flag2 = this._logAdvanced == 1;
					if (flag2)
					{
						Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(56, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Valeur de correspondance maximale pour la zone de map : ");
						defaultInterpolatedStringHandler.AppendFormatted<double>(num2);
						dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					bool flag3 = num2 >= threshold;
					if (flag3)
					{
						bool flag4 = this._logAdvanced == 1;
						if (flag4)
						{
							Dofus_Hunt dofus_Hunt2 = this._Dofus_Hunt;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
							defaultInterpolatedStringHandler.AppendLiteral("Section 'Niveau' détectée à la position ");
							defaultInterpolatedStringHandler.AppendFormatted<Point>(point2);
							dofus_Hunt2.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						int num3 = point2.X - 100;
						int num4 = point2.Y;
						num3 = Math.Max(num3, 0);
						num4 = Math.Max(num4, 0);
						Rectangle rectangle2 = new Rectangle(num3, num4, largeurTexte, hauteurTexte);
						bool flag5 = this._logAdvanced == 1;
						if (flag5)
						{
							Dofus_Hunt dofus_Hunt3 = this._Dofus_Hunt;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(96, 4);
							defaultInterpolatedStringHandler.AppendLiteral("Dimensions de la zone de texte 'Niveau' capturée : Position (X = ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle2.X);
							defaultInterpolatedStringHandler.AppendLiteral(", Y = ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle2.Y);
							defaultInterpolatedStringHandler.AppendLiteral("), Largeur = ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle2.Width);
							defaultInterpolatedStringHandler.AppendLiteral(", Hauteur = ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle2.Height);
							dofus_Hunt3.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						bool flag6 = rectangle2.Right > mat3.Width || rectangle2.Bottom > mat3.Height;
						if (flag6)
						{
							this._Dofus_Hunt.AddLog("Erreur : la zone de texte 'Niveau' à capturer est en dehors des limites de l'image.");
						}
						else
						{
							Mat mat5 = new Mat(mat3, rectangle2);
							CvInvoke.Imwrite(this._logPathImg + "/cropped_map.png", mat5, Array.Empty<KeyValuePair<ImwriteFlags, int>>());
							bool flag7 = this._logAdvanced == 1;
							if (flag7)
							{
								this._Dofus_Hunt.AddLog("Zone de texte 'Niveau' recadrée et sauvegardée : cropped_map.png");
							}
						}
					}
					else
					{
						this._Dofus_Hunt.AddLog("Section 'Niveau' non détectée.");
					}
				}
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003CD8 File Offset: 0x00001ED8
		public string PerformOCRTesseractMap(string imagePath)
		{
			string text3;
			try
			{
				using (Bitmap bitmap = this.PreprocessImageGoogleMap(imagePath))
				{
					int num = bitmap.Width * 4;
					int num2 = bitmap.Height * 4;
					Bitmap bitmap2 = new Bitmap(bitmap, num, num2);
					string text = Path.Combine(Path.GetDirectoryName(imagePath), "preprocessed_" + Path.GetFileName(imagePath));
					bool flag = this._logAdvanced == 1;
					if (flag)
					{
						bitmap2.Save(text, global::System.Drawing.Imaging.ImageFormat.Png);
						this._Dofus_Hunt.AddLog("Image prétraitée et agrandie sauvegardée : " + text);
					}
					using (TesseractEngine tesseractEngine = new TesseractEngine("./ressources/tessdata", "fra", EngineMode.Default))
					{
						tesseractEngine.SetVariable("tessedit_char_whitelist", "0123456789-, ");
						tesseractEngine.SetVariable("tessedit_pageseg_mode", "3");
						tesseractEngine.SetVariable("load_system_dawg", "F");
						tesseractEngine.SetVariable("load_freq_dawg", "F");
						tesseractEngine.SetVariable("user_words_suffix", "user-words");
						tesseractEngine.SetVariable("user_patterns_suffix", "user-patterns");
						using (Pix pix = this.BitmapToPixTesseract(bitmap2))
						{
							using (Page page = tesseractEngine.Process(pix, null))
							{
								string text2 = page.GetText();
								bool flag2 = string.IsNullOrEmpty(text2);
								if (flag2)
								{
									this._Dofus_Hunt.AddLog("Aucun texte détecté dans l'image.");
								}
								else
								{
									bool flag3 = this._logAdvanced == 1;
									if (flag3)
									{
										this._Dofus_Hunt.AddLog("Texte extrait : " + text2);
									}
								}
								text3 = text2;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors de l'analyse OCR : " + ex.Message);
				text3 = string.Empty;
			}
			return text3;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003F34 File Offset: 0x00002134
		public async Task<string> PerformOCRMapWithGoogleVision(string imagePath, string GoogleAPI)
		{
			string text2;
			try
			{
				Bitmap preprocessedImage = this.PreprocessImageGoogleMap(imagePath);
				bool flag = preprocessedImage == null;
				if (flag)
				{
					this._Dofus_Hunt.AddLog("Erreur lors du prétraitement de l'image.");
					text2 = "0";
				}
				else
				{
					string preprocessedImagePath = this._logPathImg + "/preprocessed_map.png";
					preprocessedImage.Save(preprocessedImagePath, global::System.Drawing.Imaging.ImageFormat.Png);
					bool flag2 = this._logAdvanced == 1;
					if (flag2)
					{
						this._Dofus_Hunt.AddLog("Image prétraitée sauvegardée : " + preprocessedImagePath);
					}
					byte[] imageBytes;
					using (MemoryStream ms = new MemoryStream())
					{
						preprocessedImage.Save(ms, global::System.Drawing.Imaging.ImageFormat.Png);
						imageBytes = ms.ToArray();
					}
					MemoryStream ms = null;
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
						HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("https://vision.googleapis.com/v1/images:annotate?key=" + GoogleAPI, content);
						HttpResponseMessage response = httpResponseMessage;
						httpResponseMessage = null;
						if (!response.IsSuccessStatusCode)
						{
							this._Dofus_Hunt.AddLog("Erreur lors de l'appel à l'API Google Cloud Vision : " + response.ReasonPhrase);
							Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
							defaultInterpolatedStringHandler.AppendLiteral("Statut de la réponse : ");
							defaultInterpolatedStringHandler.AppendFormatted<HttpStatusCode>(response.StatusCode);
							dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
							Dofus_Hunt dofus_Hunt2 = this._Dofus_Hunt;
							string text6 = await response.Content.ReadAsStringAsync();
							dofus_Hunt2.AddLog("Contenu de la réponse : " + text6);
							dofus_Hunt2 = null;
							text6 = null;
							text2 = "0";
						}
						else
						{
							string text7 = await response.Content.ReadAsStringAsync();
							string responseJson = text7;
							text7 = null;
							JObject responseObject = JObject.Parse(responseJson);
							JToken jtoken = responseObject["responses"];
							string text8;
							if (jtoken == null)
							{
								text8 = null;
							}
							else
							{
								JToken jtoken2 = jtoken[0];
								if (jtoken2 == null)
								{
									text8 = null;
								}
								else
								{
									JToken jtoken3 = jtoken2["fullTextAnnotation"];
									if (jtoken3 == null)
									{
										text8 = null;
									}
									else
									{
										JToken jtoken4 = jtoken3["text"];
										text8 = ((jtoken4 != null) ? jtoken4.ToString() : null);
									}
								}
							}
							string text = text8;
							if (string.IsNullOrEmpty(text))
							{
								this._Dofus_Hunt.AddLog("Le texte OCR est vide.");
								text2 = "0";
							}
							else
							{
								if (this._logAdvanced == 1)
								{
									this._Dofus_Hunt.AddLog("Texte extrait par Google Cloud Vision OCR : " + text);
								}
								string filteredText = new string(text.Where((char c) => "0123456789,-".Contains(c)).ToArray<char>());
								if (this._logAdvanced == 1)
								{
									this._Dofus_Hunt.AddLog("Texte filtré : " + filteredText);
								}
								string cleanedText = this.CleanExtractedText(filteredText);
								if (this._logAdvanced == 1)
								{
									this._Dofus_Hunt.AddLog("Texte nettoyé : " + cleanedText);
								}
								text2 = cleanedText;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors de l'analyse OCR avec Google Cloud Vision : " + ex.Message);
				text2 = "0";
			}
			return text2;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003F88 File Offset: 0x00002188
		private string CleanExtractedText(string text)
		{
			return Regex.Replace(text, "(?<=\\d)-", "");
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003FAC File Offset: 0x000021AC
		private Bitmap PreprocessImageTesseract(string imagePath)
		{
			Bitmap bitmap2;
			using (Bitmap bitmap = new Bitmap(imagePath))
			{
				for (int i = 0; i < bitmap.Height; i++)
				{
					for (int j = 0; j < bitmap.Width; j++)
					{
						Color pixel = bitmap.GetPixel(j, i);
						int num = (int)((double)pixel.R * 0.3 + (double)pixel.G * 0.59 + (double)pixel.B * 0.11);
						bitmap.SetPixel(j, i, Color.FromArgb(num, num, num));
					}
				}
				for (int k = 0; k < bitmap.Height; k++)
				{
					for (int l = 0; l < bitmap.Width; l++)
					{
						int num2 = ((bitmap.GetPixel(l, k).R > 128) ? 255 : 0);
						bitmap.SetPixel(l, k, Color.FromArgb(num2, num2, num2));
					}
				}
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.SmoothingMode = SmoothingMode.AntiAlias;
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				}
				float num3 = 2f;
				float num4 = 1f - num3;
				float[][] array = new float[5][];
				int num5 = 0;
				float[] array2 = new float[5];
				array2[0] = num3;
				array[num5] = array2;
				int num6 = 1;
				float[] array3 = new float[5];
				array3[1] = num3;
				array[num6] = array3;
				int num7 = 2;
				float[] array4 = new float[5];
				array4[2] = num3;
				array[num7] = array4;
				int num8 = 3;
				float[] array5 = new float[5];
				array5[3] = 1f;
				array[num8] = array5;
				array[4] = new float[] { num4, num4, num4, 0f, 1f };
				float[][] array6 = array;
				using (Graphics graphics2 = Graphics.FromImage(bitmap))
				{
					using (ImageAttributes imageAttributes = new ImageAttributes())
					{
						imageAttributes.SetColorMatrix(new ColorMatrix(array6), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
						graphics2.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
					}
				}
				bitmap2 = (Bitmap)bitmap.Clone();
			}
			return bitmap2;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004260 File Offset: 0x00002460
		private Pix BitmapToPixTesseract(Bitmap bitmap)
		{
			Pix pix;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bitmap.Save(memoryStream, global::System.Drawing.Imaging.ImageFormat.Png);
				memoryStream.Position = 0L;
				pix = Pix.LoadFromMemory(memoryStream.ToArray());
			}
			return pix;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000042B8 File Offset: 0x000024B8
		public int DetectPhorreur(string indice)
		{
			return (!string.IsNullOrEmpty(indice) && indice.Contains("Phorreur", StringComparison.OrdinalIgnoreCase)) ? 1 : 0;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000042E4 File Offset: 0x000024E4
		public bool ExtractCoordinatesSimple(string text, out int x, out int y)
		{
			x = 0;
			y = 0;
			bool flag7;
			try
			{
				bool flag = this._logAdvanced == 1;
				if (flag)
				{
					this._Dofus_Hunt.AddLog("Texte fourni pour l'extraction des coordonnées simples : '" + text + "'");
				}
				text = new string(text.Where((char c) => char.IsDigit(c) || c == ',' || c == '-' || c == ' ').ToArray<char>()).Trim();
				bool flag2 = this._logAdvanced == 1;
				if (flag2)
				{
					this._Dofus_Hunt.AddLog("Texte nettoyé pour extraction : '" + text + "'");
				}
				bool flag3 = text.EndsWith("-");
				if (flag3)
				{
					text = text.TrimEnd('-').Trim();
					bool flag4 = this._logAdvanced == 1;
					if (flag4)
					{
						this._Dofus_Hunt.AddLog("Texte après suppression des '-' en fin de chaîne : '" + text + "'");
					}
				}
				bool flag5 = !text.Contains(",");
				if (flag5)
				{
					bool flag6 = this._logAdvanced == 1;
					if (flag6)
					{
						this._Dofus_Hunt.AddLog("Le texte ne contient pas de virgule. Extraction impossible.");
					}
					flag7 = false;
				}
				else
				{
					string[] array = text.Split(',', StringSplitOptions.None);
					bool flag8 = this._logAdvanced == 1;
					if (flag8)
					{
						this._Dofus_Hunt.AddLog("Parties après division : " + string.Join(" | ", array));
					}
					bool flag9 = array.Length == 2;
					if (flag9)
					{
						array[0] = array[0].TrimStart();
						array[1] = array[1].TrimStart();
						array[0] = (array[0].StartsWith("-") ? ((array[0].Length > 3) ? array[0].Substring(0, 3).Trim() : array[0].Trim()) : ((array[0].Length > 2) ? array[0].Substring(0, 2).Trim() : array[0].Trim()));
						array[1] = (array[1].StartsWith("-") ? ((array[1].Length > 3) ? array[1].Substring(0, 3).Trim() : array[1].Trim()) : ((array[1].Length > 2) ? array[1].Substring(0, 2).Trim() : array[1].Trim()));
						int num;
						int num2;
						bool flag10 = int.TryParse(array[0], out num) && int.TryParse(array[1], out num2);
						if (flag10)
						{
							x = num;
							y = num2;
							bool flag11 = this._logAdvanced == 1;
							if (flag11)
							{
								Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 2);
								defaultInterpolatedStringHandler.AppendLiteral("Coordonnées simples extraites : X = ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(x);
								defaultInterpolatedStringHandler.AppendLiteral(", Y = ");
								defaultInterpolatedStringHandler.AppendFormatted<int>(y);
								dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
							}
							flag7 = true;
						}
						else
						{
							this._Dofus_Hunt.AddLog("Impossible de convertir les coordonnées.");
							flag7 = false;
						}
					}
					else
					{
						this._Dofus_Hunt.AddLog("Le texte divisé ne contient pas exactement deux parties.");
						flag7 = false;
					}
				}
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors de l'extraction des coordonnées simples : " + ex.Message);
				flag7 = false;
			}
			return flag7;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00004628 File Offset: 0x00002828
		private Bitmap PreprocessImageGoogleMap(string imagePath)
		{
			Bitmap bitmap4;
			using (Bitmap bitmap = new Bitmap(imagePath))
			{
				bool flag = this._logAdvanced == 1;
				if (flag)
				{
					this._Dofus_Hunt.AddLog("Image chargée pour prétraitement : " + imagePath);
				}
				Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height);
				using (Graphics graphics = Graphics.FromImage(bitmap2))
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
					ImageAttributes imageAttributes = new ImageAttributes();
					imageAttributes.SetColorMatrix(colorMatrix);
					graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
				}
				bool flag2 = this._logAdvanced == 1;
				if (flag2)
				{
					this._Dofus_Hunt.AddLog("Image convertie en niveaux de gris.");
				}
				Bitmap bitmap3 = new Bitmap(bitmap2.Width, bitmap2.Height);
				using (Graphics graphics2 = Graphics.FromImage(bitmap3))
				{
					float num2 = 1.5f;
					float num3 = 0.2f;
					float[][] array3 = new float[5][];
					int num4 = 0;
					float[] array4 = new float[5];
					array4[0] = num2;
					array3[num4] = array4;
					int num5 = 1;
					float[] array5 = new float[5];
					array5[1] = num2;
					array3[num5] = array5;
					int num6 = 2;
					float[] array6 = new float[5];
					array6[2] = num2;
					array3[num6] = array6;
					int num7 = 3;
					float[] array7 = new float[5];
					array7[3] = 1f;
					array3[num7] = array7;
					array3[4] = new float[] { num3, num3, num3, 0f, 1f };
					float[][] array8 = array3;
					ColorMatrix colorMatrix2 = new ColorMatrix(array8);
					ImageAttributes imageAttributes2 = new ImageAttributes();
					imageAttributes2.SetColorMatrix(colorMatrix2);
					graphics2.DrawImage(bitmap2, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), 0, 0, bitmap2.Width, bitmap2.Height, GraphicsUnit.Pixel, imageAttributes2);
				}
				bool flag3 = this._logAdvanced == 1;
				if (flag3)
				{
					this._Dofus_Hunt.AddLog("Contraste et luminosité ajustés.");
				}
				bitmap4 = (Bitmap)bitmap3.Clone();
			}
			return bitmap4;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000048C8 File Offset: 0x00002AC8
		public string GetGoogleAPIKey(string filePath)
		{
			string text2;
			try
			{
				using (Aes aes = Aes.Create())
				{
					aes.Key = Encoding.UTF8.GetBytes(this.encryptionKey.PadRight(32).Substring(0, 32));
					aes.IV = new byte[16];
					ICryptoTransform cryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV);
					using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
					{
						using (CryptoStream cryptoStream = new CryptoStream(fileStream, cryptoTransform, CryptoStreamMode.Read))
						{
							using (StreamReader streamReader = new StreamReader(cryptoStream))
							{
								string text = streamReader.ReadToEnd();
								text2 = text;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors du déchiffrement : " + ex.Message);
				text2 = string.Empty;
			}
			return text2;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000049E8 File Offset: 0x00002BE8
		private void DetectAndExtractHuntInfo(double threshold, int largeurTexte, int hauteurTexte)
		{
			Mat mat = CvInvoke.Imread("ressources/img/depart_template.png", ImreadModes.Color);
			bool isEmpty = mat.IsEmpty;
			if (isEmpty)
			{
				this._Dofus_Hunt.AddLog("Erreur : image de 'Départ' introuvable (depart_template.png)");
			}
			else
			{
				Mat mat2 = new Mat(this._logPathImg + "/screenshot.png", ImreadModes.Color);
				Mat mat3 = new Mat();
				CvInvoke.MatchTemplate(mat2, mat, mat3, TemplateMatchingType.CcoeffNormed, null);
				double num = 0.0;
				double num2 = 0.0;
				Point point = default(Point);
				Point point2 = default(Point);
				CvInvoke.MinMaxLoc(mat3, ref num, ref num2, ref point, ref point2, null);
				bool flag = this._logAdvanced == 1;
				if (flag)
				{
					Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Valeur de correspondance maximale pour 'Départ' : ");
					defaultInterpolatedStringHandler.AppendFormatted<double>(num2);
					dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				bool flag2 = num2 >= threshold;
				if (flag2)
				{
					bool flag3 = this._logAdvanced == 1;
					if (flag3)
					{
						Dofus_Hunt dofus_Hunt2 = this._Dofus_Hunt;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Section 'Départ' détectée à la position ");
						defaultInterpolatedStringHandler.AppendFormatted<Point>(point2);
						dofus_Hunt2.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					int num3 = point2.X - 50;
					int num4 = point2.Y;
					bool flag4 = num3 < 0;
					if (flag4)
					{
						num3 = 0;
					}
					bool flag5 = num4 < 0;
					if (flag5)
					{
						num4 = 0;
					}
					Rectangle rectangle = new Rectangle(num3, num4, largeurTexte, hauteurTexte);
					bool flag6 = this._logAdvanced == 1;
					if (flag6)
					{
						Dofus_Hunt dofus_Hunt3 = this._Dofus_Hunt;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(96, 4);
						defaultInterpolatedStringHandler.AppendLiteral("Dimensions de la zone de texte 'Départ' capturée : Position (X = ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle.X);
						defaultInterpolatedStringHandler.AppendLiteral(", Y = ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle.Y);
						defaultInterpolatedStringHandler.AppendLiteral("), Largeur = ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle.Width);
						defaultInterpolatedStringHandler.AppendLiteral(", Hauteur = ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle.Height);
						dofus_Hunt3.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					bool flag7 = rectangle.Right > mat2.Width || rectangle.Bottom > mat2.Height;
					if (flag7)
					{
						this._Dofus_Hunt.AddLog("Erreur : la zone de texte 'Départ' à capturer est en dehors des limites de l'image.");
					}
					else
					{
						Mat mat4 = new Mat(mat2, rectangle);
						mat4.Save(this._logPathImg + "/cropped_hunt.png");
						bool flag8 = this._logAdvanced == 1;
						if (flag8)
						{
							this._Dofus_Hunt.AddLog("Zone de texte 'Départ' recadrée et sauvegardée : cropped_hunt.png");
						}
					}
				}
				else
				{
					this._Dofus_Hunt.AddLog("Section 'Départ' non détectée.");
				}
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00004C94 File Offset: 0x00002E94
		private string RemoveTextBeforeFirstUppercase(string text)
		{
			int num = text.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZÉÀ".ToCharArray());
			bool flag = num >= 0;
			string text2;
			if (flag)
			{
				while (num > 0 && char.IsWhiteSpace(text[num - 1]))
				{
					num--;
				}
				text2 = text.Substring(num).Trim();
			}
			else
			{
				text2 = text;
			}
			return text2;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004CF4 File Offset: 0x00002EF4
		public string PerformOCRTesseract(string imagePath)
		{
			string text2;
			try
			{
				using (Bitmap bitmap = this.PreprocessImageTesseract(imagePath))
				{
					using (TesseractEngine tesseractEngine = new TesseractEngine("./ressources/tessdata", "fra", EngineMode.Default))
					{
						tesseractEngine.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZÉabcdefghijklmnopqrstuvwxyzçèéêœâ '");
						tesseractEngine.SetVariable("load_system_dawg", "F");
						tesseractEngine.SetVariable("load_freq_dawg", "F");
						tesseractEngine.SetVariable("user_words_suffix", "user-words");
						tesseractEngine.SetVariable("user_patterns_suffix", "user-patterns");
						using (Pix pix = this.BitmapToPixTesseract(bitmap))
						{
							using (Page page = tesseractEngine.Process(pix, null))
							{
								string text = page.GetText();
								bool flag = string.IsNullOrEmpty(text);
								if (flag)
								{
									this._Dofus_Hunt.AddLog("Aucun texte détecté dans l'image.");
								}
								else
								{
									bool flag2 = this._logAdvanced == 1;
									if (flag2)
									{
										this._Dofus_Hunt.AddLog("Texte extrait : " + text);
									}
									text = this.RemoveTextBeforeFirstUppercase(text);
									bool flag3 = this._logAdvanced == 1;
									if (flag3)
									{
										this._Dofus_Hunt.AddLog("Texte après suppression : '" + text + "'");
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
				this._Dofus_Hunt.AddLog("Erreur lors de l'analyse OCR : " + ex.Message);
				text2 = string.Empty;
			}
			return text2;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00004EF8 File Offset: 0x000030F8
		public int CountCocheOccurrences(double threshold)
		{
			Mat mat = CvInvoke.Imread("ressources/img/coche_jaune.png", ImreadModes.Color);
			bool isEmpty = mat.IsEmpty;
			int num;
			if (isEmpty)
			{
				this._Dofus_Hunt.AddLog("Erreur : image de la Coche introuvable (coche_jaune.png)");
				num = 0;
			}
			else
			{
				Mat mat2 = new Mat(this._logPathImg + "/cropped_hunt.png", ImreadModes.Color);
				Mat mat3 = new Mat();
				CvInvoke.MatchTemplate(mat2, mat, mat3, TemplateMatchingType.CcoeffNormed, null);
				double num2 = 0.0;
				double num3 = 0.0;
				Point point = default(Point);
				Point point2 = default(Point);
				CvInvoke.MinMaxLoc(mat3, ref num2, ref num3, ref point, ref point2, null);
				int num4 = 0;
				float[] array = new float[mat3.Rows * mat3.Cols];
				mat3.CopyTo<float>(array);
				for (int i = 0; i < mat3.Rows; i++)
				{
					for (int j = 0; j < mat3.Cols; j++)
					{
						bool flag = (double)array[i * mat3.Cols + j] >= threshold;
						if (flag)
						{
							num4++;
							CvInvoke.Rectangle(mat3, new Rectangle(j, i, mat.Width, mat.Height), new MCvScalar(0.0), -1, LineType.EightConnected, 0);
						}
					}
				}
				bool flag2 = this._logAdvanced == 1;
				if (flag2)
				{
					Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Nombre de coches jaune détectées : ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(num4);
					dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				num = num4;
			}
			return num;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005090 File Offset: 0x00003290
		public bool IsCombatDetected(double threshold)
		{
			Mat mat = CvInvoke.Imread("ressources/img/combat.png", ImreadModes.Color);
			bool isEmpty = mat.IsEmpty;
			bool flag;
			if (isEmpty)
			{
				flag = false;
			}
			else
			{
				Mat mat2 = new Mat(this._logPathImg + "/cropped_hunt.png", ImreadModes.Color);
				Mat mat3 = new Mat();
				CvInvoke.MatchTemplate(mat2, mat, mat3, TemplateMatchingType.CcoeffNormed, null);
				double num = 0.0;
				double num2 = 0.0;
				Point point = default(Point);
				Point point2 = default(Point);
				CvInvoke.MinMaxLoc(mat3, ref num, ref num2, ref point, ref point2, null);
				bool flag2 = this._logAdvanced == 1;
				if (flag2)
				{
					Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(69, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Valeur de correspondance maximale pour 'combat.png' : ");
					defaultInterpolatedStringHandler.AppendFormatted<double>(num2);
					defaultInterpolatedStringHandler.AppendLiteral(" à la position ");
					defaultInterpolatedStringHandler.AppendFormatted<Point>(point2);
					dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				bool flag3 = num2 >= threshold;
				flag = flag3;
			}
			return flag;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00005194 File Offset: 0x00003394
		public string getIndiceTexte(double thresholdHuntInfo, int largeurTexteHuntInfo, int hauteurTexteHuntInfo, double threshold, int largeurTexte, int hauteurTexte)
		{
			this.DetectAndExtractHuntInfo(thresholdHuntInfo, largeurTexteHuntInfo, hauteurTexteHuntInfo);
			Mat mat = CvInvoke.Imread("ressources/img/coche_blanche.png", ImreadModes.Color);
			bool isEmpty = mat.IsEmpty;
			string text;
			if (isEmpty)
			{
				this._Dofus_Hunt.AddLog("Erreur : image de la Coche introuvable (coche_blanche.png)");
				text = string.Empty;
			}
			else
			{
				Mat mat2 = new Mat(this._logPathImg + "/cropped_hunt.png", ImreadModes.Color);
				Mat mat3 = new Mat();
				CvInvoke.MatchTemplate(mat2, mat, mat3, TemplateMatchingType.CcoeffNormed, null);
				double num = 0.0;
				double num2 = 0.0;
				Point point = default(Point);
				Point point2 = default(Point);
				CvInvoke.MinMaxLoc(mat3, ref num, ref num2, ref point, ref point2, null);
				bool flag = this._logAdvanced == 1;
				if (flag)
				{
					Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(51, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Valeur de correspondance maximale : ");
					defaultInterpolatedStringHandler.AppendFormatted<double>(num2);
					defaultInterpolatedStringHandler.AppendLiteral(" à la position ");
					defaultInterpolatedStringHandler.AppendFormatted<Point>(point2);
					dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				bool flag2 = num2 >= threshold;
				if (flag2)
				{
					bool flag3 = this._logAdvanced == 1;
					if (flag3)
					{
						Dofus_Hunt dofus_Hunt2 = this._Dofus_Hunt;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Coche détectée : ");
						defaultInterpolatedStringHandler.AppendFormatted<Point>(point2);
						dofus_Hunt2.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					int num3 = point2.X - 450;
					int num4 = point2.Y - 10;
					bool flag4 = num3 < 0;
					if (flag4)
					{
						num3 = 0;
					}
					bool flag5 = num4 < 0;
					if (flag5)
					{
						num4 = 0;
					}
					Rectangle rectangle = new Rectangle(num3, num4, largeurTexte, hauteurTexte);
					bool flag6 = this._logAdvanced == 1;
					if (flag6)
					{
						Dofus_Hunt dofus_Hunt3 = this._Dofus_Hunt;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(87, 4);
						defaultInterpolatedStringHandler.AppendLiteral("Dimensions de la zone de texte capturée : Position (X = ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle.X);
						defaultInterpolatedStringHandler.AppendLiteral(", Y = ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle.Y);
						defaultInterpolatedStringHandler.AppendLiteral("), Largeur = ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle.Width);
						defaultInterpolatedStringHandler.AppendLiteral(", Hauteur = ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(rectangle.Height);
						dofus_Hunt3.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					Mat mat4 = new Mat(mat2, rectangle);
					mat4.Save(this._logPathImg + "/cropped_text.png");
					bool flag7 = this._logAdvanced == 1;
					if (flag7)
					{
						this._Dofus_Hunt.AddLog("Zone de texte recadrée et sauvegardée : cropped_text.png");
					}
					byte[] array = File.ReadAllBytes(this._logPathImg + "/cropped_text.png");
					string text2 = this.PerformOCRTesseract(this._logPathImg + "/cropped_text.png");
					text2 = text2.Replace("\r", "").Replace("\n", "");
					text2 = text2.TrimStart();
					text = text2;
				}
				else
				{
					text = string.Empty;
				}
			}
			return text;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000548C File Offset: 0x0000368C
		public string DetectArrowDirectionAfterOCR(double threshold)
		{
			Mat mat = new Mat(this._logPathImg + "/cropped_text.png", ImreadModes.Color);
			string text = this._logPathImg + "/cropped_hunt.png";
			string text2 = this._logPathImg + "/cropped_text.png";
			string text3 = "ressources/img";
			string[] array = new string[] { "fleche_bas.png", "fleche_haut.png", "fleche_gauche.png", "fleche_droite.png" };
			string[] array2 = new string[] { "2", "6", "4", "0" };
			bool flag = false;
			string text4 = null;
			for (int i = 0; i < array.Length; i++)
			{
				string text5 = Path.Combine(text3, array[i]);
				Mat mat2 = CvInvoke.Imread(text5, ImreadModes.Color);
				bool isEmpty = mat2.IsEmpty;
				if (isEmpty)
				{
					this._Dofus_Hunt.AddLog("Erreur : image de la flèche introuvable (" + text5 + ")");
				}
				else
				{
					Mat mat3 = new Mat();
					CvInvoke.MatchTemplate(mat, mat2, mat3, TemplateMatchingType.CcoeffNormed, null);
					double num = 0.0;
					double num2 = 0.0;
					Point point = default(Point);
					Point point2 = default(Point);
					CvInvoke.MinMaxLoc(mat3, ref num, ref num2, ref point, ref point2, null);
					bool flag2 = this._logAdvanced == 1;
					if (flag2)
					{
						Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(54, 2);
						defaultInterpolatedStringHandler.AppendLiteral("Valeur de correspondance maximale pour la flèche '");
						defaultInterpolatedStringHandler.AppendFormatted(array2[i]);
						defaultInterpolatedStringHandler.AppendLiteral("' : ");
						defaultInterpolatedStringHandler.AppendFormatted<double>(num2);
						dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					bool flag3 = num2 >= threshold;
					if (flag3)
					{
						bool flag4 = this._logAdvanced == 1;
						if (flag4)
						{
							Dofus_Hunt dofus_Hunt2 = this._Dofus_Hunt;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(48, 2);
							defaultInterpolatedStringHandler.AppendLiteral("Flèche détectée pointant vers la ");
							defaultInterpolatedStringHandler.AppendFormatted(array2[i]);
							defaultInterpolatedStringHandler.AppendLiteral(" à la position ");
							defaultInterpolatedStringHandler.AppendFormatted<Point>(point2);
							dofus_Hunt2.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						flag = true;
						text4 = array2[i];
						break;
					}
				}
			}
			bool flag5 = !flag;
			string text6;
			if (flag5)
			{
				this._Dofus_Hunt.AddLog("Flèche non détectée.");
				text6 = string.Empty;
			}
			else
			{
				text6 = text4;
			}
			return text6;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000056EC File Offset: 0x000038EC
		public string GetArrowIcon(string arrow)
		{
			if (!true)
			{
			}
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
			if (!true)
			{
			}
			return text;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005768 File Offset: 0x00003968
		public List<IndiceData> GetHuntData(string x, string y, string dir)
		{
			this.indicePositions.Clear();
			List<IndiceData> list2;
			try
			{
				string text = File.ReadAllText(this._jsonFilePath);
				List<HuntData> list = JsonConvert.DeserializeObject<List<HuntData>>(text);
				HuntData huntData = list.Find((HuntData h) => h.startX == x && h.startY == y && h.direction == dir);
				bool flag = huntData != null;
				if (flag)
				{
					Dictionary<string, IndiceData> dictionary = new Dictionary<string, IndiceData>();
					foreach (IndiceData indiceData in huntData.data)
					{
						bool flag2 = dictionary.ContainsKey(indiceData.indice);
						if (flag2)
						{
							IndiceData indiceData2 = dictionary[indiceData.indice];
							int num = Math.Abs(indiceData2.posX - int.Parse(x)) + Math.Abs(indiceData2.posY - int.Parse(y));
							int num2 = Math.Abs(indiceData.posX - int.Parse(x)) + Math.Abs(indiceData.posY - int.Parse(y));
							bool flag3 = num2 < num;
							if (flag3)
							{
								dictionary[indiceData.indice] = indiceData;
							}
						}
						else
						{
							dictionary[indiceData.indice] = indiceData;
						}
					}
					foreach (IndiceData indiceData3 in dictionary.Values)
					{
						this.indicePositions[indiceData3.indice] = new ValueTuple<int, int>(indiceData3.posX, indiceData3.posY);
					}
					list2 = dictionary.Values.ToList<IndiceData>();
				}
				else
				{
					list2 = new List<IndiceData>();
				}
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors de la lecture du fichier JSON : " + ex.Message);
				list2 = new List<IndiceData>();
			}
			return list2;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000059C4 File Offset: 0x00003BC4
		[return: TupleElementNames(new string[] { "posX", "posY", "indiceChecked" })]
		[return: Nullable(new byte[] { 0, 1 })]
		public ValueTuple<int, int, string> GetIndicePositionOffline(string indice)
		{
			ValueTuple<int, int> valueTuple;
			bool flag = this.indicePositions.TryGetValue(indice, out valueTuple);
			ValueTuple<int, int, string> valueTuple2;
			if (flag)
			{
				valueTuple2 = new ValueTuple<int, int, string>(valueTuple.Item1, valueTuple.Item2, indice);
			}
			else
			{
				int num = -99;
				int num2 = -99;
				string text = "";
				double num3 = 0.0;
				int seuil = this._seuil;
				foreach (KeyValuePair<string, ValueTuple<int, int>> keyValuePair in this.indicePositions)
				{
					string key = keyValuePair.Key;
					int num4 = this.LevenshteinDistance(indice, key);
					int num5 = Math.Max(indice.Length, key.Length);
					double num6 = (1.0 - (double)num4 / (double)num5) * 100.0;
					bool flag2 = this._logAdvanced == 1;
					if (flag2)
					{
						Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 3);
						defaultInterpolatedStringHandler.AppendLiteral("Similarité entre '");
						defaultInterpolatedStringHandler.AppendFormatted(indice);
						defaultInterpolatedStringHandler.AppendLiteral("' et '");
						defaultInterpolatedStringHandler.AppendFormatted(key);
						defaultInterpolatedStringHandler.AppendLiteral("' : ");
						defaultInterpolatedStringHandler.AppendFormatted<double>(num6);
						defaultInterpolatedStringHandler.AppendLiteral("%");
						dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					bool flag3 = num6 >= (double)seuil && num6 > num3;
					if (flag3)
					{
						num3 = num6;
						num = keyValuePair.Value.Item1;
						num2 = keyValuePair.Value.Item2;
						text = key;
					}
				}
				bool flag4 = num != -99 && num2 != -99;
				if (flag4)
				{
					valueTuple2 = new ValueTuple<int, int, string>(num, num2, text);
				}
				else
				{
					valueTuple2 = new ValueTuple<int, int, string>(-99, -99, string.Empty);
				}
			}
			return valueTuple2;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005BAC File Offset: 0x00003DAC
		[return: TupleElementNames(new string[] { "posX", "posY", "indiceChecked" })]
		[return: Nullable(new byte[] { 0, 1 })]
		public ValueTuple<int, int, string> GetIndicePositionOfflineAuto(string indiceRechercher, string direction, int startX, int startY)
		{
			ValueTuple<int, int, string> valueTuple;
			try
			{
				string text = File.ReadAllText(this._jsonFilePath);
				List<HuntData> list = JsonConvert.DeserializeObject<List<HuntData>>(text);
				HuntData huntData = list.Find((HuntData h) => h.startX == startX.ToString() && h.startY == startY.ToString() && h.direction == direction.ToString());
				bool flag = huntData != null;
				if (flag)
				{
					int num = -99;
					int num2 = -99;
					string text2 = "";
					int num3 = int.MaxValue;
					double num4 = 0.0;
					int seuil = this._seuil;
					foreach (IndiceData indiceData in huntData.data)
					{
						string indice = indiceData.indice;
						int num5 = this.LevenshteinDistance(indiceRechercher, indice);
						int num6 = Math.Max(indiceRechercher.Length, indice.Length);
						double num7 = (1.0 - (double)num5 / (double)num6) * 100.0;
						bool flag2 = this._logAdvanced == 1;
						if (flag2)
						{
							Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(61, 4);
							defaultInterpolatedStringHandler.AppendLiteral("Indice : ");
							defaultInterpolatedStringHandler.AppendFormatted(indice);
							defaultInterpolatedStringHandler.AppendLiteral(" - Indice Recherché : ");
							defaultInterpolatedStringHandler.AppendFormatted(indiceRechercher);
							defaultInterpolatedStringHandler.AppendLiteral(" - Similarité: ");
							defaultInterpolatedStringHandler.AppendFormatted<double>(num7);
							defaultInterpolatedStringHandler.AppendLiteral("% - Distance : ");
							defaultInterpolatedStringHandler.AppendFormatted<int>(num5);
							dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
						}
						bool flag3 = num7 >= (double)seuil;
						if (flag3)
						{
							int posX = indiceData.posX;
							int posY = indiceData.posY;
							int num8 = Math.Abs(posX - startX) + Math.Abs(posY - startY);
							bool flag4 = num7 > num4 || (num7 == num4 && num8 < num3);
							if (flag4)
							{
								num4 = num7;
								num3 = num8;
								num = posX;
								num2 = posY;
								text2 = indice;
							}
						}
					}
					bool flag5 = num != -99 && num2 != -99;
					if (flag5)
					{
						valueTuple = new ValueTuple<int, int, string>(num, num2, text2);
					}
					else
					{
						this._Dofus_Hunt.AddLog("Indice " + indiceRechercher + " non trouvé dans le fichier JSON.");
						valueTuple = new ValueTuple<int, int, string>(-99, -99, string.Empty);
					}
				}
				else
				{
					Dofus_Hunt dofus_Hunt2 = this._Dofus_Hunt;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(58, 3);
					defaultInterpolatedStringHandler.AppendLiteral("Aucune donnée trouvée pour startX: ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(startX);
					defaultInterpolatedStringHandler.AppendLiteral(", startY: ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(startY);
					defaultInterpolatedStringHandler.AppendLiteral(", direction: ");
					defaultInterpolatedStringHandler.AppendFormatted(direction);
					dofus_Hunt2.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					valueTuple = new ValueTuple<int, int, string>(-99, -99, string.Empty);
				}
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors de la lecture du fichier JSON : " + ex.Message);
				valueTuple = new ValueTuple<int, int, string>(-99, -99, string.Empty);
			}
			return valueTuple;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00005EFC File Offset: 0x000040FC
		public string GetCorrectedText(string input)
		{
			string text2;
			try
			{
				string text = this._keyPath + "/corrections.xml";
				bool flag = !File.Exists(text);
				if (flag)
				{
					throw new FileNotFoundException("Le fichier " + text + " n'existe pas.");
				}
				XDocument xdocument = XDocument.Load(text);
				XElement xelement = xdocument.Descendants("Correction").FirstOrDefault((XElement c) => string.Equals((string)c.Element("Erroneous"), input, StringComparison.OrdinalIgnoreCase));
				bool flag2 = xelement != null;
				if (flag2)
				{
					Dofus_Hunt dofus_Hunt = this._Dofus_Hunt;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Correction trouvée pour '");
					defaultInterpolatedStringHandler.AppendFormatted(input);
					defaultInterpolatedStringHandler.AppendLiteral("' : ");
					defaultInterpolatedStringHandler.AppendFormatted<XElement>(xelement.Element("Correct"));
					dofus_Hunt.AddLog(defaultInterpolatedStringHandler.ToStringAndClear());
					text2 = (string)xelement.Element("Correct");
				}
				else
				{
					this._Dofus_Hunt.AddLog("Aucune correction trouvée pour '" + input + "'.");
					text2 = input;
				}
			}
			catch (Exception ex)
			{
				this._Dofus_Hunt.AddLog("Erreur lors de la lecture du fichier XML : " + ex.Message);
				text2 = input;
			}
			return text2;
		}

		// Token: 0x0400000D RID: 13
		private Dofus_Hunt _Dofus_Hunt = new Dofus_Hunt();

		// Token: 0x0400000E RID: 14
		private ProxyServer proxyServer;

		// Token: 0x0400000F RID: 15
		private ExplicitProxyEndPoint proxyEndPoint;

		// Token: 0x04000010 RID: 16
		private string _AdvancedLog;

		// Token: 0x04000011 RID: 17
		private string _token;

		// Token: 0x04000012 RID: 18
		private string _dofus;

		// Token: 0x04000013 RID: 19
		private int _seuil;

		// Token: 0x04000014 RID: 20
		private int _logAdvanced;

		// Token: 0x04000015 RID: 21
		private readonly string _logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt", "logs");

		// Token: 0x04000016 RID: 22
		private readonly string _logPathImg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt", "logs", "img");

		// Token: 0x04000017 RID: 23
		private readonly string _keyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt");

		// Token: 0x04000018 RID: 24
		private readonly string encryptionKey = "PYDmkmFw5keiTsIhEA4Az6SUnxabZug8l8wSCqfUeDc=";

		// Token: 0x04000019 RID: 25
		private readonly string _jsonFilePath = "indices.json";

		// Token: 0x0400001A RID: 26
		[TupleElementNames(new string[] { "posX", "posY" })]
		[Nullable(new byte[] { 1, 1, 0 })]
		private Dictionary<string, ValueTuple<int, int>> indicePositions = new Dictionary<string, ValueTuple<int, int>>();
	}
}
