using System;
using System.Collections.Generic;

namespace MobileBandSync.Common;

public class LoadStateEventArgs : EventArgs
{
	public object NavigationParameter { get; private set; }

	public Dictionary<string, object> PageState { get; private set; }

	public LoadStateEventArgs(object navigationParameter, Dictionary<string, object> pageState)
	{
		NavigationParameter = navigationParameter;
		PageState = pageState;
	}
}
