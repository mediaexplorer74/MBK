using System;
using System.Collections.Generic;

namespace MobileBandSync.Common;

public class SaveStateEventArgs : EventArgs
{
	public Dictionary<string, object> PageState { get; private set; }

	public SaveStateEventArgs(Dictionary<string, object> pageState)
	{
		PageState = pageState;
	}
}
