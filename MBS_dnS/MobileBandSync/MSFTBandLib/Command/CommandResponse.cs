using System;
using System.Collections.Generic;
using System.Linq;
using MobileBandSync.MSFTBandLib.Includes;

namespace MobileBandSync.MSFTBandLib.Command
{
	// Token: 0x02000078 RID: 120
	public class CommandResponse
	{
		// Token: 0x060003D6 RID: 982 RVA: 0x0000BD38 File Offset: 0x00009F38
		public void AddResponse(byte[] bytes)
		{
			if (CommandResponse.ResponseBytesStartWithStatus(bytes))
			{
				this.Status = CommandResponse.GetResponseStatusBytesStart(bytes);
				if (CommandResponse.ResponseBytesContainData(bytes))
				{
					this.AddResponseData(CommandResponse.GetResponseDataBytesStart(bytes));
					return;
				}
			}
			else if (CommandResponse.ResponseBytesEndWithStatus(bytes))
			{
				this.Status = CommandResponse.GetResponseStatusBytesEnd(bytes);
				if (CommandResponse.ResponseBytesContainData(bytes))
				{
					this.AddResponseData(CommandResponse.GetResponseDataBytesEnd(bytes));
					return;
				}
			}
			else
			{
				this.AddResponseData(bytes);
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000BD9E File Offset: 0x00009F9E
		protected void AddResponseData(byte[] bytes)
		{
			this.Data.Add(bytes);
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000BDAC File Offset: 0x00009FAC
		public byte[] GetData(int index = 0)
		{
			byte[] result = null;
			if (this.Data.Count > index && this.Data[index].Length != 0)
			{
				result = this.Data[index];
			}
			return result;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000BDE8 File Offset: 0x00009FE8
		public static byte[] Combine(byte[] first, byte[] second)
		{
			byte[] array = new byte[first.Length + second.Length];
			Buffer.BlockCopy(first, 0, array, 0, first.Length);
			Buffer.BlockCopy(second, 0, array, first.Length, second.Length);
			return array;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000BE20 File Offset: 0x0000A020
		public byte[] GetAllData()
		{
			int num = 0;
			byte[] array = null;
			while (this.Data.Count > num && this.Data[num].Length != 0)
			{
				if (num == 0)
				{
					array = this.Data[num];
				}
				else if (array != null)
				{
					array = CommandResponse.Combine(array, this.Data[num]);
				}
				num++;
			}
			return array;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0000BE80 File Offset: 0x0000A080
		public ByteStream GetByteStream(int index = 0)
		{
			byte[] data = this.GetData(index);
			if (data == null)
			{
				return null;
			}
			return new ByteStream(data);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000BEA0 File Offset: 0x0000A0A0
		public bool StatusReceived()
		{
			return !this.Status.All((byte s) => s == 0);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000BECF File Offset: 0x0000A0CF
		public static byte[] GetResponseDataBytesStart(byte[] bytes)
		{
			return bytes.Skip(6).ToArray<byte>();
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0000BEE0 File Offset: 0x0000A0E0
		public static byte[] GetResponseDataBytesEnd(byte[] bytes)
		{
			int count = bytes.Length - 6;
			return bytes.Take(count).ToArray<byte>();
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000BEFF File Offset: 0x0000A0FF
		public static byte[] GetResponseStatusBytesStart(byte[] bytes)
		{
			return bytes.Take(6).ToArray<byte>();
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0000BF10 File Offset: 0x0000A110
		public static byte[] GetResponseStatusBytesEnd(byte[] bytes)
		{
			int count = bytes.Length - 6;
			return bytes.Skip(count).ToArray<byte>();
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0000BF30 File Offset: 0x0000A130
		public static bool ResponseBytesAreStatus(byte[] bytes)
		{
			int[] array = (from b in bytes
			select (int)b).ToArray<int>();
			return array[0] == 254 && array[1] == 166;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0000BF7E File Offset: 0x0000A17E
		public static bool ResponseBytesContainData(byte[] bytes)
		{
			return bytes.Length > 6;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000BF86 File Offset: 0x0000A186
		public static bool ResponseBytesStartWithStatus(byte[] bytes)
		{
			return CommandResponse.ResponseBytesAreStatus(CommandResponse.GetResponseStatusBytesStart(bytes));
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0000BF93 File Offset: 0x0000A193
		public static bool ResponseBytesEndWithStatus(byte[] bytes)
		{
			return CommandResponse.ResponseBytesAreStatus(CommandResponse.GetResponseStatusBytesEnd(bytes));
		}

		// Token: 0x040002DC RID: 732
		public byte[] Status = new byte[6];

		// Token: 0x040002DD RID: 733
		public List<byte[]> Data = new List<byte[]>();

		// Token: 0x040002DE RID: 734
		public const int RESPONSE_STATUS_LENGTH = 6;
	}
}
