using System;

namespace MobileBandSync.Common
{
	// Token: 0x020000A2 RID: 162
	public class SuspensionManagerException : Exception
	{
		// Token: 0x0600061A RID: 1562 RVA: 0x0000FE6B File Offset: 0x0000E06B
		public SuspensionManagerException()
		{
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0000FE73 File Offset: 0x0000E073
		public SuspensionManagerException(Exception e) : base("SuspensionManager failed", e)
		{
		}
	}
}
