using System;
using System.Threading.Tasks;
using MobileBandSync.MSFTBandLib.Command;
using MobileBandSync.MSFTBandLib.Exceptions;
using Windows.ApplicationModel.Core;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace MobileBandSync.MSFTBandLib.UWP
{
	// Token: 0x02000063 RID: 99
	public class BandSocketUWP : BandSocketInterface, IDisposable
	{
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000377 RID: 887 RVA: 0x0000B295 File Offset: 0x00009495
		// (set) Token: 0x06000378 RID: 888 RVA: 0x0000B29D File Offset: 0x0000949D
		public bool Connected { get; protected set; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000379 RID: 889 RVA: 0x0000B2A6 File Offset: 0x000094A6
		// (set) Token: 0x0600037A RID: 890 RVA: 0x0000B2AE File Offset: 0x000094AE
		public bool Disposed { get; protected set; }

		// Token: 0x0600037B RID: 891 RVA: 0x0000B2B7 File Offset: 0x000094B7
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000B2C6 File Offset: 0x000094C6
		protected virtual void Dispose(bool disposing)
		{
			if (!this.Disposed)
			{
				this.Socket.Dispose();
				this.DataReader.Dispose();
				this.DataWriter.Dispose();
				this.Disposed = true;
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0000B2F8 File Offset: 0x000094F8
		public async Task Connect(string mac, Guid uuid, Action<ulong, ulong> Progress = null)
		{
			if (!this.Connected)
			{
				try
				{
					if (Progress != null)
					{
						await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(0, delegate()
						{
							Progress(0UL, 0UL);
						});
					}
				}
				catch (Exception)
				{
				}
				HostName host = new HostName(mac);
				RfcommDeviceService rfcommDeviceService = await BandSocketUWP.GetRfcommDeviceServiceForHostFromUuid(host, uuid);
				this.Socket = new StreamSocket();
				await this.Socket.ConnectAsync(host, rfcommDeviceService.ConnectionServiceName, 3);
				DataReader dataReader = new DataReader(this.Socket.InputStream);
				dataReader.put_InputStreamOptions(1);
				this.DataReader = dataReader;
				this.DataWriter = new DataWriter(this.Socket.OutputStream);
				this.Connected = true;
			}
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000B358 File Offset: 0x00009558
		public async Task Disconnect()
		{
			if (this.Connected)
			{
				await Task.Run(delegate()
				{
					this.DataReader.DetachStream();
					this.DataReader.Dispose();
					this.DataWriter.DetachStream();
					this.DataWriter.Dispose();
					this.Socket.Dispose();
					this.Connected = false;
				});
				return;
			}
			throw new BandSocketConnectedNot();
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0000B3A0 File Offset: 0x000095A0
		public async Task Send(CommandPacket packet)
		{
			if (!this.Connected)
			{
				throw new BandSocketConnectedNot();
			}
			this.DataWriter.WriteBytes(packet.GetBytes());
			await this.DataWriter.StoreAsync();
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0000B3F0 File Offset: 0x000095F0
		public async Task Send(CommandPacket packet, byte[] bytesToSend)
		{
			if (!this.Connected)
			{
				throw new BandSocketConnectedNot();
			}
			this.DataWriter.WriteBytes(packet.GetBytes());
			await this.DataWriter.StoreAsync();
			if (bytesToSend != null)
			{
				this.DataWriter.WriteBytes(bytesToSend);
				await this.DataWriter.StoreAsync();
			}
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0000B448 File Offset: 0x00009648
		public async Task<int> SendStatus(CommandPacket packet, byte[] bytesToSend)
		{
			if (!this.Connected)
			{
				throw new BandSocketConnectedNot();
			}
			this.DataWriter.WriteBytes(packet.GetBytes());
			await this.DataWriter.StoreAsync();
			if (bytesToSend != null)
			{
				this.DataWriter.WriteBytes(bytesToSend);
				await this.DataWriter.StoreAsync();
			}
			uint count = await this.DataReader.LoadAsync(12U);
			byte[] array = this.ReadBytes(count);
			int num = (int)array[0];
			int num2 = (int)array[1];
			int result;
			if (num == 254 || num2 == 166)
			{
				result = 0;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0000B4A0 File Offset: 0x000096A0
		public async Task<CommandResponse> Receive(uint buffer, Action<ulong, ulong> Progress = null)
		{
			BandSocketUWP.<>c__DisplayClass18_1 CS$<>8__locals1 = new BandSocketUWP.<>c__DisplayClass18_1();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.buffer = buffer;
			CS$<>8__locals1.Progress = Progress;
			return await Task.Run<CommandResponse>(async delegate()
			{
				BandSocketUWP.<>c__DisplayClass18_2 CS$<>8__locals2 = new BandSocketUWP.<>c__DisplayClass18_2();
				CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
				CS$<>8__locals2.response = new CommandResponse();
				if (!CS$<>8__locals1.<>4__this.Connected)
				{
					throw new BandSocketConnectedNot();
				}
				for (;;)
				{
					BandSocketUWP.<>c__DisplayClass18_0 CS$<>8__locals3 = new BandSocketUWP.<>c__DisplayClass18_0();
					CS$<>8__locals3.CS$<>8__locals2 = CS$<>8__locals2;
					CS$<>8__locals3.bytes = 0U;
					BandSocketUWP.<>c__DisplayClass18_2 CS$<>8__locals4 = CS$<>8__locals3.CS$<>8__locals2;
					CommandResponse response = CS$<>8__locals4.response;
					CommandResponse response2 = await Task.Run<CommandResponse>(async delegate()
					{
						BandSocketUWP.<>c__DisplayClass18_0 CS$<>8__locals5 = CS$<>8__locals3;
						uint bytes = CS$<>8__locals5.bytes;
						uint bytes2 = await CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.DataReader.LoadAsync(CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.buffer);
						CS$<>8__locals5.bytes = bytes2;
						CS$<>8__locals5 = null;
						CS$<>8__locals3.CS$<>8__locals2.response.AddResponse(CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.<>4__this.ReadBytes(CS$<>8__locals3.bytes));
						return CS$<>8__locals3.CS$<>8__locals2.response;
					});
					CS$<>8__locals4.response = response2;
					CS$<>8__locals4 = null;
					try
					{
						if (CS$<>8__locals1.Progress != null)
						{
							await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(0, delegate()
							{
								CS$<>8__locals3.CS$<>8__locals2.CS$<>8__locals1.Progress((ulong)CS$<>8__locals3.bytes, 0UL);
							});
						}
					}
					catch (Exception)
					{
					}
					if (CS$<>8__locals3.CS$<>8__locals2.response.StatusReceived() || CS$<>8__locals3.bytes == 0U)
					{
						break;
					}
					CS$<>8__locals3 = null;
				}
				return CS$<>8__locals2.response;
			});
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0000B4F8 File Offset: 0x000096F8
		public async Task<CommandResponse> Request(CommandPacket packet, uint buffer, Action<ulong, ulong> Progress = null)
		{
			if (this.Connected)
			{
				await this.Send(packet);
				return await this.Receive(buffer, Progress);
			}
			throw new BandSocketConnectedNot();
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0000B558 File Offset: 0x00009758
		public async Task<CommandResponse> Put(CommandPacket packet, uint buffer)
		{
			if (this.Connected)
			{
				await this.Send(packet);
				return await this.Receive(buffer, null);
			}
			throw new BandSocketConnectedNot();
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000B5B0 File Offset: 0x000097B0
		protected byte[] ReadBytes(uint count)
		{
			byte[] array = new byte[count];
			this.DataReader.ReadBytes(array);
			return array;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0000B5D4 File Offset: 0x000097D4
		public static async Task<RfcommDeviceService> GetRfcommDeviceServiceForHostFromUuid(HostName host, Guid uuid)
		{
			RfcommServiceId.FromUuid(uuid);
			return (await BluetoothDevice.FromHostNameAsync(host)).RfcommServices[0];
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0000B621 File Offset: 0x00009821
		public DataReader GetDataReader()
		{
			return this.DataReader;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0000B629 File Offset: 0x00009829
		public DataWriter GetDataWriter()
		{
			return this.DataWriter;
		}

		// Token: 0x040001E3 RID: 483
		protected StreamSocket Socket;

		// Token: 0x040001E4 RID: 484
		protected DataReader DataReader;

		// Token: 0x040001E5 RID: 485
		protected DataWriter DataWriter;
	}
}
