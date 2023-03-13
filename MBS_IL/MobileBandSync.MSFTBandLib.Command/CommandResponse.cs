using System;
using System.Collections.Generic;
using System.Linq;
using MobileBandSync.MSFTBandLib.Includes;

namespace MobileBandSync.MSFTBandLib.Command;

public class CommandResponse
{
	public byte[] Status = new byte[6];

	public List<byte[]> Data = new List<byte[]>();

	public const int RESPONSE_STATUS_LENGTH = 6;

	public void AddResponse(byte[] bytes)
	{
		if (ResponseBytesStartWithStatus(bytes))
		{
			Status = GetResponseStatusBytesStart(bytes);
			if (ResponseBytesContainData(bytes))
			{
				AddResponseData(GetResponseDataBytesStart(bytes));
			}
		}
		else if (ResponseBytesEndWithStatus(bytes))
		{
			Status = GetResponseStatusBytesEnd(bytes);
			if (ResponseBytesContainData(bytes))
			{
				AddResponseData(GetResponseDataBytesEnd(bytes));
			}
		}
		else
		{
			AddResponseData(bytes);
		}
	}

	protected void AddResponseData(byte[] bytes)
	{
		Data.Add(bytes);
	}

	public byte[] GetData(int index = 0)
	{
		byte[] result = null;
		if (Data.Count > index && Data[index].Length != 0)
		{
			result = Data[index];
		}
		return result;
	}

	public static byte[] Combine(byte[] first, byte[] second)
	{
		byte[] array = new byte[first.Length + second.Length];
		Buffer.BlockCopy(first, 0, array, 0, first.Length);
		Buffer.BlockCopy(second, 0, array, first.Length, second.Length);
		return array;
	}

	public byte[] GetAllData()
	{
		int i = 0;
		byte[] array = null;
		for (; Data.Count > i && Data[i].Length != 0; i++)
		{
			if (i == 0)
			{
				array = Data[i];
			}
			else if (array != null)
			{
				array = Combine(array, Data[i]);
			}
		}
		return array;
	}

	public ByteStream GetByteStream(int index = 0)
	{
		byte[] data = GetData(index);
		if (data == null)
		{
			return null;
		}
		return new ByteStream(data);
	}

	public bool StatusReceived()
	{
		return !Status.All((byte s) => s == 0);
	}

	public static byte[] GetResponseDataBytesStart(byte[] bytes)
	{
		return bytes.Skip(6).ToArray();
	}

	public static byte[] GetResponseDataBytesEnd(byte[] bytes)
	{
		int count = bytes.Length - 6;
		return bytes.Take(count).ToArray();
	}

	public static byte[] GetResponseStatusBytesStart(byte[] bytes)
	{
		return bytes.Take(6).ToArray();
	}

	public static byte[] GetResponseStatusBytesEnd(byte[] bytes)
	{
		int count = bytes.Length - 6;
		return bytes.Skip(count).ToArray();
	}

	public static bool ResponseBytesAreStatus(byte[] bytes)
	{
		int[] array = ((IEnumerable<byte>)bytes).Select((Func<byte, int>)((byte b) => b)).ToArray();
		if (array[0] == 254)
		{
			return array[1] == 166;
		}
		return false;
	}

	public static bool ResponseBytesContainData(byte[] bytes)
	{
		return bytes.Length > 6;
	}

	public static bool ResponseBytesStartWithStatus(byte[] bytes)
	{
		return ResponseBytesAreStatus(GetResponseStatusBytesStart(bytes));
	}

	public static bool ResponseBytesEndWithStatus(byte[] bytes)
	{
		return ResponseBytesAreStatus(GetResponseStatusBytesEnd(bytes));
	}
}
