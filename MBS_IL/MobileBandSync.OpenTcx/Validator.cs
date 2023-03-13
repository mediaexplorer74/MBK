using System;
using System.Xml;

namespace MobileBandSync.OpenTcx;

internal sealed class Validator
{
	private string errMsg;

	public string validationErrMsg
	{
		get
		{
			return errMsg;
		}
		set
		{
			errMsg = value;
		}
	}

	public bool Validate(string XMLFile, bool LocationDefined)
	{
		bool flag = true;
		try
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			using XmlReader xmlReader = XmlReader.Create(XMLFile, settings);
			while (xmlReader.Read() && flag)
			{
				_ = xmlReader.Name;
			}
			return flag;
		}
		catch (Exception ex)
		{
			validationErrMsg = validationErrMsg + "Exception occured when validating. " + ex.Message;
			return false;
		}
	}
}
