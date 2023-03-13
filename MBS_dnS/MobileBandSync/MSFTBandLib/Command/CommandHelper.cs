using System;
using System.Reflection;
using MobileBandSync.MSFTBandLib.Facility;
using MobileBandSync.MSFTBandLib.Includes;

namespace MobileBandSync.MSFTBandLib.Command
{
	// Token: 0x02000076 RID: 118
	public static class CommandHelper
	{
		// Token: 0x060003CC RID: 972 RVA: 0x0000BB87 File Offset: 0x00009D87
		public static ushort Create(FacilityEnum facility, bool tx, int index)
		{
			return (ushort)((int)facility << 8 | (FacilityEnum)((tx ? 1 : 0) << 7) | (FacilityEnum)index);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0000BB9C File Offset: 0x00009D9C
		public static int GetCommandDataSize(CommandEnum command)
		{
			Attribute customAttribute = typeof(CommandEnum).GetRuntimeField(command.ToString()).GetCustomAttribute(typeof(CommandDataSize));
			if (customAttribute == null)
			{
				return 8192;
			}
			return ((CommandDataSize)customAttribute).DataSize;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0000BBE9 File Offset: 0x00009DE9
		public static int GetCommandDataSize(Func<uint> BufferSize)
		{
			if (BufferSize == null)
			{
				return 8192;
			}
			return (int)BufferSize();
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0000BBFA File Offset: 0x00009DFA
		public static byte[] GetCommandDefaultArgumentsBytes(CommandEnum command)
		{
			ByteStream byteStream = new ByteStream();
			byteStream.BinaryWriter.Write(CommandHelper.GetCommandDataSize(command));
			return byteStream.GetBytes();
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000BC18 File Offset: 0x00009E18
		public static byte[] GetCommandDefaultArgumentsBytes(Func<uint> BufferSize)
		{
			byte[] result = null;
			if (BufferSize != null)
			{
				ByteStream byteStream = new ByteStream();
				byteStream.BinaryWriter.Write(BufferSize());
				result = byteStream.GetBytes();
			}
			return result;
		}
	}
}
