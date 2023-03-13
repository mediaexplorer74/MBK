using System;
using MobileBandSync.MSFTBandLib.Includes;

namespace MobileBandSync.MSFTBandLib.Command
{
	// Token: 0x02000077 RID: 119
	public class CommandPacket
	{
		// Token: 0x060003D1 RID: 977 RVA: 0x0000BC47 File Offset: 0x00009E47
		public CommandPacket(CommandEnum command, Func<uint> BufferSize, byte[] args = null)
		{
			this.Command = command;
			this.CmdBufferSize = BufferSize;
			if (args != null)
			{
				this.args = args;
				return;
			}
			this.args = this.GetCommandDefaultArgumentsBytes();
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0000BC74 File Offset: 0x00009E74
		public int GetCommandDataSize()
		{
			if (this.CmdBufferSize != null)
			{
				return CommandHelper.GetCommandDataSize(this.CmdBufferSize);
			}
			return CommandHelper.GetCommandDataSize(this.Command);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0000BC95 File Offset: 0x00009E95
		public byte[] GetArgsSizeBytes()
		{
			return new byte[]
			{
				(byte)(8 + this.args.Length)
			};
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000BCAB File Offset: 0x00009EAB
		public byte[] GetCommandDefaultArgumentsBytes()
		{
			if (this.CmdBufferSize != null)
			{
				return CommandHelper.GetCommandDefaultArgumentsBytes(this.CmdBufferSize);
			}
			return CommandHelper.GetCommandDefaultArgumentsBytes(this.Command);
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000BCCC File Offset: 0x00009ECC
		public byte[] GetBytes()
		{
			ByteStream byteStream = new ByteStream();
			byteStream.BinaryWriter.Write(this.GetArgsSizeBytes());
			byteStream.BinaryWriter.Write(12025);
			byteStream.BinaryWriter.Write((ushort)this.Command);
			byteStream.BinaryWriter.Write(this.GetCommandDataSize());
			byteStream.BinaryWriter.Write(this.args);
			return byteStream.GetBytes();
		}

		// Token: 0x040002D9 RID: 729
		protected CommandEnum Command;

		// Token: 0x040002DA RID: 730
		protected byte[] args;

		// Token: 0x040002DB RID: 731
		protected Func<uint> CmdBufferSize;
	}
}
