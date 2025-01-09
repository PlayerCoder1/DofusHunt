using System;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Dof_Hunt
{
	// Token: 0x02000006 RID: 6
	[NullableContext(1)]
	[Nullable(0)]
	public class Licence
	{
		// Token: 0x06000044 RID: 68 RVA: 0x0000606C File Offset: 0x0000426C
		private string GetMacAddress()
		{
			string text;
			try
			{
				NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
				foreach (NetworkInterface networkInterface in allNetworkInterfaces)
				{
					bool flag = networkInterface.OperationalStatus == OperationalStatus.Up && networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback;
					if (flag)
					{
						return networkInterface.GetPhysicalAddress().ToString();
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

		// Token: 0x06000045 RID: 69 RVA: 0x000060F0 File Offset: 0x000042F0
		private bool VerifyLicense(string licenseFilePath, string pcIdentifier, string publicKey)
		{
			byte[] array = File.ReadAllBytes(licenseFilePath);
			byte[] bytes = Encoding.UTF8.GetBytes(pcIdentifier);
			bool flag;
			using (RSACryptoServiceProvider rsacryptoServiceProvider = new RSACryptoServiceProvider())
			{
				rsacryptoServiceProvider.FromXmlString(publicKey);
				using (SHA256 sha = SHA256.Create())
				{
					flag = rsacryptoServiceProvider.VerifyData(bytes, sha, array);
				}
			}
			return flag;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00006168 File Offset: 0x00004368
		public string GetPcIdentifier()
		{
			string text3;
			try
			{
				string text = string.Empty;
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
				foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
				{
					bool flag = managementBaseObject != null && managementBaseObject["SerialNumber"] != null;
					if (flag)
					{
						string text2 = managementBaseObject["SerialNumber"].ToString();
						text = ((text2 != null) ? text2.Trim() : null);
						break;
					}
				}
				string macAddress = this.GetMacAddress();
				text3 = text + "_" + macAddress;
			}
			catch
			{
				text3 = "UNKNOWN";
			}
			return text3;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00006234 File Offset: 0x00004434
		public bool checkLicence()
		{
			bool flag2;
			try
			{
				string text = "<RSAKeyValue>\r\n  <Modulus>xBm7x56q8H2ZJRZ7fDtKe0kjSR2w/MlrjxuSerK+tPyQR4o4qWmvdwAoVRpnOAN2r43BovMSeSXT5GC/ZMupafW9JXqH5A7Fi6Di6L6lw7RFMfcAgrWmLk7pr2VGFFEjcN5NQKIH8nTgKQkn9D0TKClSuDzhb5KhWWhy3fVgjUmNuBF9o8+pijg0PEMWpchGBGed33D4isSvNJchvLDpQfUpcNGBo7M/swwweJv9vj1HfehAa0BM6TVsNvCva5l6S+Ib0f5RG8qZmbEU5vDnAyK1eQd7gqVXBB7JBprDTEqBiHT8/iodHTLpSKQ78po2jSDrBRnahvFpqUpiiTQvTQ==</Modulus>\r\n  <Exponent>AQAB</Exponent>\r\n</RSAKeyValue>";
				string text2 = Path.Combine(new string[] { this._keyPath + "/licence.lic" });
				string pcIdentifier = this.GetPcIdentifier();
				bool flag = File.Exists(text2) && this.VerifyLicense(text2, pcIdentifier, text);
				if (flag)
				{
					flag2 = true;
				}
				else
				{
					flag2 = false;
				}
			}
			catch (Exception ex)
			{
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000062B0 File Offset: 0x000044B0
		public bool ValidateLicence()
		{
			bool flag = this.checkLicence();
			bool flag2 = !flag;
			return !flag2;
		}

		// Token: 0x0400001B RID: 27
		private readonly string _keyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dofus Hunt");
	}
}
