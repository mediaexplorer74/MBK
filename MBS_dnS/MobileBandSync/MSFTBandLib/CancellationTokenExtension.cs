using System;
using System.Threading;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x0200005A RID: 90
	internal static class CancellationTokenExtension
	{
		// Token: 0x06000343 RID: 835 RVA: 0x0000A54B File Offset: 0x0000874B
		public static void WaitAndThrowIfCancellationRequested(this CancellationToken token, TimeSpan timeout)
		{
			token.WaitHandle.WaitOne(timeout);
			token.ThrowIfCancellationRequested();
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000A562 File Offset: 0x00008762
		public static void WaitAndThrowIfCancellationRequested(this CancellationToken token, int timeout)
		{
			token.WaitHandle.WaitOne(timeout);
			token.ThrowIfCancellationRequested();
		}
	}
}
