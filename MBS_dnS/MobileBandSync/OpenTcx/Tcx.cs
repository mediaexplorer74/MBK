using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MobileBandSync.OpenTcx.Entities;
using Windows.Storage;

namespace MobileBandSync.OpenTcx
{
	// Token: 0x02000012 RID: 18
	public class Tcx
	{
		// Token: 0x06000177 RID: 375 RVA: 0x00008D28 File Offset: 0x00006F28
		public async Task<TrainingCenterDatabase_t> AnalyzeTcxFile(string tcxFile)
		{
			StorageFolder localFolder = ApplicationData.Current.LocalFolder;
			await this.CopyLocally(tcxFile);
			return null;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00008D78 File Offset: 0x00006F78
		public async Task<string> CopyLocally(string tcxFile)
		{
			return "";
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00008DB5 File Offset: 0x00006FB5
		public TrainingCenterDatabase_t AnalyzeTcxStream(Stream fs)
		{
			return new XmlSerializer(typeof(TrainingCenterDatabase_t)).Deserialize(fs) as TrainingCenterDatabase_t;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00008DD4 File Offset: 0x00006FD4
		public string GenerateTcx(TrainingCenterDatabase_t data)
		{
			string result = null;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(TrainingCenterDatabase_t));
				using (StringWriter stringWriter = new StringWriter())
				{
					xmlSerializer.Serialize(stringWriter, data);
					result = stringWriter.GetStringBuilder().ToString();
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00008E3C File Offset: 0x0000703C
		public bool ValidateTcx(string tckFile)
		{
			bool result;
			try
			{
				result = new Validator().Validate(tckFile, false);
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
