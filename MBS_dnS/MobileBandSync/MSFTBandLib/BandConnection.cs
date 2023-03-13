using System;
using System.Threading.Tasks;
using MobileBandSync.MSFTBandLib.Command;
using MobileBandSync.MSFTBandLib.Exceptions;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x02000057 RID: 87
	public class BandConnection<T> : BandConnectionInterface, IDisposable where T : class, BandSocketInterface
	{
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000331 RID: 817 RVA: 0x0000A25D File Offset: 0x0000845D
		// (set) Token: 0x06000332 RID: 818 RVA: 0x0000A265 File Offset: 0x00008465
		public bool Connected { get; protected set; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000333 RID: 819 RVA: 0x0000A26E File Offset: 0x0000846E
		// (set) Token: 0x06000334 RID: 820 RVA: 0x0000A276 File Offset: 0x00008476
		public bool Disposed { get; protected set; }

		// Token: 0x06000335 RID: 821 RVA: 0x0000A280 File Offset: 0x00008480
		public BandConnection()
		{
			this.Cargo = (Activator.CreateInstance(typeof(T), new object[0]) as T);
			this.Push = (Activator.CreateInstance(typeof(T), new object[0]) as T);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0000A2E7 File Offset: 0x000084E7
		public BandConnection(BandInterface Band) : this()
		{
			this.Band = Band;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000A2F6 File Offset: 0x000084F6
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000A305 File Offset: 0x00008505
		protected virtual void Dispose(bool disposing)
		{
			if (!this.Disposed)
			{
				this.Cargo.Dispose();
				this.Push.Dispose();
				this.Disposed = true;
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000A32C File Offset: 0x0000852C
		public async Task Connect(Action<ulong, ulong> Progress = null)
		{
			if (!this.Connected)
			{
				this.Connected = true;
				string mac = this.Band.GetMac();
				await this.Cargo.Connect(mac, Guid.Parse("a502ca97-2ba5-413c-a4e0-13804e47b38f"), Progress);
				return;
			}
			throw new BandConnectionConnected();
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000A37C File Offset: 0x0000857C
		public async Task Connect(BandInterface Band)
		{
			if (!this.Connected)
			{
				this.Band = Band;
				await this.Connect(null);
				return;
			}
			throw new BandConnectionConnected();
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000A3CC File Offset: 0x000085CC
		public async Task Disconnect()
		{
			if (this.Connected)
			{
				await this.Cargo.Disconnect();
				await this.Push.Disconnect();
				this.Connected = false;
				return;
			}
			throw new BandConnectionConnectedNot();
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000A414 File Offset: 0x00008614
		public async Task<CommandResponse> Command(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 8192U, Action<ulong, ulong> Progress = null)
		{
			if (!this.Connected)
			{
				throw new BandConnectionConnectedNot();
			}
			CommandPacket packet = new CommandPacket(command, BufferSize, args);
			return await this.Cargo.Request(packet, buffer, Progress);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000A484 File Offset: 0x00008684
		public async Task CommandStore(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 8192U, Action<ulong, ulong> Progress = null)
		{
			if (!this.Connected)
			{
				throw new BandConnectionConnectedNot();
			}
			CommandPacket packet = new CommandPacket(command, BufferSize, null);
			await this.Cargo.Send(packet, args);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000A4E4 File Offset: 0x000086E4
		public async Task<CommandResponse> CommandStoreStatus(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 8192U, Action<ulong, ulong> Progress = null)
		{
			if (!this.Connected)
			{
				throw new BandConnectionConnectedNot();
			}
			CommandPacket packet = new CommandPacket(command, BufferSize, null);
			return await this.Cargo.Request(packet, buffer, Progress);
		}

		// Token: 0x04000156 RID: 342
		protected BandInterface Band;

		// Token: 0x04000159 RID: 345
		public readonly BandSocketInterface Cargo;

		// Token: 0x0400015A RID: 346
		public readonly BandSocketInterface Push;
	}
}
