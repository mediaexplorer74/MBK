using System;

namespace MobileBandSync.Common;

public class UnknownData
{
	public int[] ValueInt16;

	public int[] ValueInt32;

	public byte[] Content { get; }

	public int ID { get; set; }

	public UnknownData(int iID, byte[] buffer, int iLength)
	{
		ID = iID;
		Content = new byte[iLength];
		buffer.CopyTo(Content, 0);
		ValueInt16 = new int[100];
		ValueInt32 = new int[100];
		int num = 0;
		for (int i = 0; i < iLength; i += 2)
		{
			if (i + 1 >= iLength)
			{
				ValueInt16[num] = buffer[i];
			}
			else
			{
				ValueInt16[num] = BitConverter.ToInt16(buffer, i);
			}
			if (i + 3 < iLength)
			{
				ValueInt32[num] = BitConverter.ToInt32(buffer, i);
			}
			num++;
		}
	}
}
