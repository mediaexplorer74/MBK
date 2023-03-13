using System;
using System.Threading;

namespace MobileBandSync.MSFTBandLib;

internal static class CancellationTokenExtension
{
	public static void WaitAndThrowIfCancellationRequested(this CancellationToken token, TimeSpan timeout)
	{
		token.WaitHandle.WaitOne(timeout);
		token.ThrowIfCancellationRequested();
	}

	public static void WaitAndThrowIfCancellationRequested(this CancellationToken token, int timeout)
	{
		token.WaitHandle.WaitOne(timeout);
		token.ThrowIfCancellationRequested();
	}
}
