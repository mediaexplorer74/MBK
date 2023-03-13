using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MobileBandSync.OpenTcx.Entities;
using Windows.Storage;

namespace MobileBandSync.OpenTcx;

public class Tcx
{
	public async Task<TrainingCenterDatabase_t> AnalyzeTcxFile(string tcxFile)
	{
		_ = ApplicationData.Current.LocalFolder;
		await CopyLocally(tcxFile);
		return null;
	}

	public async Task<string> CopyLocally(string tcxFile)
	{
		return "";
	}

	public TrainingCenterDatabase_t AnalyzeTcxStream(Stream fs)
	{
		return new XmlSerializer(typeof(TrainingCenterDatabase_t)).Deserialize(fs) as TrainingCenterDatabase_t;
	}

	public string GenerateTcx(TrainingCenterDatabase_t data)
	{
		string result = null;
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(TrainingCenterDatabase_t));
			using StringWriter stringWriter = new StringWriter();
			xmlSerializer.Serialize(stringWriter, data);
			result = stringWriter.GetStringBuilder().ToString();
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public bool ValidateTcx(string tckFile)
	{
		try
		{
			return new Validator().Validate(tckFile, LocationDefined: false);
		}
		catch (Exception)
		{
			return false;
		}
	}
}
