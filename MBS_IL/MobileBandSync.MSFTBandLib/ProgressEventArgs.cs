using System;

namespace MobileBandSync.MSFTBandLib;

public class ProgressEventArgs : EventArgs
{
	public ulong Completed { get; private set; }

	public ulong Total { get; private set; }

	public string StatusText { get; private set; }

	public ProgressEventArgs(ulong uiCompleted, ulong uiTotal, string strStatusText)
	{
		Completed = uiCompleted;
		Total = uiTotal;
		StatusText = strStatusText;
	}
}
