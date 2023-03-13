using System;
using System.Xml;

namespace MobileBandSync.OpenTcx
{
	// Token: 0x02000013 RID: 19
	internal sealed class Validator
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00008E78 File Offset: 0x00007078
		// (set) Token: 0x0600017E RID: 382 RVA: 0x00008E80 File Offset: 0x00007080
		public string validationErrMsg
		{
			get
			{
				return this.errMsg;
			}
			set
			{
				this.errMsg = value;
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00008E8C File Offset: 0x0000708C
		public bool Validate(string XMLFile, bool LocationDefined)
		{
			bool flag = true;
			try
			{
				XmlReaderSettings settings = new XmlReaderSettings();
				using (XmlReader xmlReader = XmlReader.Create(XMLFile, settings))
				{
					while (xmlReader.Read() && flag)
					{
						string name = xmlReader.Name;
					}
				}
			}
			catch (Exception ex)
			{
				this.validationErrMsg = this.validationErrMsg + "Exception occured when validating. " + ex.Message;
				flag = false;
			}
			return flag;
		}

		// Token: 0x0400007C RID: 124
		private string errMsg;
	}
}
