using System;

namespace MobileBandSync.OpenTcx;

public class OpenTcxException : Exception
{
	public OpenTcxException(string message)
		: base(message)
	{
	}

	public OpenTcxException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
