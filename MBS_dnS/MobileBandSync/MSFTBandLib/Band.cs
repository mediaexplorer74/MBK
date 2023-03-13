using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MobileBandSync.MSFTBandLib.Command;
using MobileBandSync.MSFTBandLib.Exceptions;
using MobileBandSync.MSFTBandLib.Helpers;
using MobileBandSync.MSFTBandLib.Metrics;
using MobileBandSync.MSFTBandLib.UWP;
using Windows.ApplicationModel.Core;
using Windows.Devices.Bluetooth;
using Windows.Storage;
using Windows.Storage.Streams;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x02000055 RID: 85
	public class Band<T> : BandInterface where T : class, BandSocketInterface
	{
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000310 RID: 784 RVA: 0x00009BB5 File Offset: 0x00007DB5
		// (set) Token: 0x06000311 RID: 785 RVA: 0x00009BBD File Offset: 0x00007DBD
		public string Mac { get; protected set; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000312 RID: 786 RVA: 0x00009BC6 File Offset: 0x00007DC6
		// (set) Token: 0x06000313 RID: 787 RVA: 0x00009BCE File Offset: 0x00007DCE
		public string Name { get; protected set; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000314 RID: 788 RVA: 0x00009BD7 File Offset: 0x00007DD7
		// (set) Token: 0x06000315 RID: 789 RVA: 0x00009BE4 File Offset: 0x00007DE4
		public bool Connected
		{
			get
			{
				return this.Connection.Connected;
			}
			set
			{
				throw new Exception("Can't change connection directly!");
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000316 RID: 790 RVA: 0x00009BF0 File Offset: 0x00007DF0
		// (set) Token: 0x06000317 RID: 791 RVA: 0x00009BF8 File Offset: 0x00007DF8
		public BandConnection<T> Connection { get; protected set; }

		// Token: 0x06000318 RID: 792 RVA: 0x00009C01 File Offset: 0x00007E01
		public BluetoothDevice GetDevice()
		{
			return this._device;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00009C09 File Offset: 0x00007E09
		public Band(string mac, string name)
		{
			this.Mac = mac;
			this.Name = name;
			this.Connection = new BandConnection<T>(this);
			this._device = null;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00009C32 File Offset: 0x00007E32
		public Band(BluetoothDevice device)
		{
			if (device != null)
			{
				this.Mac = device.HostName.ToString();
				this.Name = device.Name;
				this.Connection = new BandConnection<T>(this);
				this._device = device;
			}
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00009C6D File Offset: 0x00007E6D
		public string GetMac()
		{
			return this.Mac;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00009C75 File Offset: 0x00007E75
		public string GetName()
		{
			return this.Name;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00009C80 File Offset: 0x00007E80
		public async Task Connect(Action<ulong, ulong> Progress = null)
		{
			if (!this.Connected)
			{
				await this.Connection.Connect(Progress);
				return;
			}
			throw new BandConnected();
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00009CD0 File Offset: 0x00007ED0
		public async Task Disconnect()
		{
			if (this.Connected)
			{
				await this.Connection.Disconnect();
			}
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00009D18 File Offset: 0x00007F18
		public async Task<CommandResponse> Command(CommandEnum Command, Func<uint> BufferSize, Action<ulong, ulong> Progress = null)
		{
			if (!this.Connected)
			{
				throw new BandConnectedNot();
			}
			return await this.Connection.Command(Command, BufferSize, null, 8192U, Progress);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00009D78 File Offset: 0x00007F78
		public async Task<CommandResponse> Command(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs, uint uiBufferSize = 8192U, Action<ulong, ulong> Progress = null)
		{
			if (!this.Connected)
			{
				throw new BandConnectedNot();
			}
			return await this.Connection.Command(Command, BufferSize, btArgs, 8192U, Progress);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00009DE0 File Offset: 0x00007FE0
		public async Task CommandStore(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs = null, uint uiBufferSize = 8192U, Action<ulong, ulong> Progress = null)
		{
			if (!this.Connected)
			{
				throw new BandConnectedNot();
			}
			await this.Connection.CommandStore(Command, BufferSize, btArgs, uiBufferSize, Progress);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00009E50 File Offset: 0x00008050
		public async Task<CommandResponse> CommandStoreStatus(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs = null, uint uiBufferSize = 8192U, Action<ulong, ulong> Progress = null)
		{
			if (!this.Connected)
			{
				throw new BandConnectedNot();
			}
			return await this.Connection.CommandStoreStatus(Command, BufferSize, btArgs, uiBufferSize, Progress);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00009EC0 File Offset: 0x000080C0
		public async Task<DateTime> GetDeviceTime()
		{
			return TimeHelper.DateTimeResponse(await this.Command(CommandEnum.GetDeviceTime, null, null), 0);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00009F08 File Offset: 0x00008108
		public async Task<Sleep> GetLastSleep()
		{
			return new Sleep(await this.Command(CommandEnum.GetStatisticsSleep, null, null));
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00009F50 File Offset: 0x00008150
		public async Task<string> GetSerialNumber()
		{
			return (await this.Command((CommandEnum)DeviceCommands.CargoGetProductSerialNumber, null, null)).GetByteStream(0).GetString(0, 0L);
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00009F98 File Offset: 0x00008198
		public static byte[] Combine(byte[] first, byte[] second)
		{
			byte[] array = new byte[first.Length + second.Length];
			Buffer.BlockCopy(first, 0, array, 0, first.Length);
			Buffer.BlockCopy(second, 0, array, first.Length, second.Length);
			return array;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00009FD0 File Offset: 0x000081D0
		public async Task<byte[]> GetSensorLog(Action<string> Report, Action<ulong, ulong> Progress, bool bCleanupSensorLog, bool bStoreSensorLog)
		{
			Band<T>.<>c__DisplayClass31_0 CS$<>8__locals1 = new Band<T>.<>c__DisplayClass31_0();
			CS$<>8__locals1.Progress = Progress;
			byte[] btSensorLog = null;
			CS$<>8__locals1.Progress(0UL, 0UL);
			try
			{
				Band<T>.<>c__DisplayClass31_1 CS$<>8__locals2 = new Band<T>.<>c__DisplayClass31_1();
				CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
				CS$<>8__locals2.metaData = null;
				int num = 0;
				await this.DeviceLogDataFlush();
				try
				{
					num = await this.RemainingDeviceLogDataChunks();
				}
				catch (Exception)
				{
					num = 0;
				}
				if (num > 0)
				{
					int chunkCount = num;
					Band<T>.<>c__DisplayClass31_1 CS$<>8__locals3 = CS$<>8__locals2;
					BandMetadataRange metaData = CS$<>8__locals3.metaData;
					CS$<>8__locals3.metaData = await this.GetChunkRangeMetadata(chunkCount);
					CS$<>8__locals3 = null;
					if (CS$<>8__locals2.metaData == null)
					{
						Report("* error: failed to get chunk range metadata!");
					}
					else
					{
						try
						{
							if (CS$<>8__locals2.CS$<>8__locals1.Progress != null)
							{
								await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(0, delegate()
								{
									CS$<>8__locals2.CS$<>8__locals1.Progress(0UL, (ulong)(CS$<>8__locals2.metaData.ByteCount * 2U));
								});
							}
						}
						catch (Exception)
						{
						}
						btSensorLog = await this.GetChunkRangeData(CS$<>8__locals2.metaData, CS$<>8__locals2.CS$<>8__locals1.Progress);
						if (btSensorLog != null && btSensorLog.Length != 0)
						{
							if (bStoreSensorLog)
							{
								string uploadId = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
								StorageFolder storageFolder = await KnownFolders.DocumentsLibrary.CreateFolderAsync("SensorLog", 3);
								if (storageFolder == null)
								{
									return null;
								}
								await FileIO.WriteBytesAsync(await storageFolder.CreateFileAsync("band-" + uploadId + "-Data.bin", 1), btSensorLog);
								uploadId = null;
							}
							if (bCleanupSensorLog)
							{
								await this.DeleteChunkRange(CS$<>8__locals2.metaData);
							}
						}
						else
						{
							Report("* error: failed to get chunk range data!");
						}
					}
				}
				CS$<>8__locals2 = null;
			}
			catch (Exception ex)
			{
				Report("Error downloading the logs: " + ex.Message);
				return null;
			}
			return btSensorLog;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0000A038 File Offset: 0x00008238
		public async Task<int> RemainingDeviceLogDataChunks()
		{
			return BitConverter.ToInt32((await this.Command((CommandEnum)DeviceCommands.CargoLoggerGetChunkCounts, null, null)).GetByteStream(0).GetBytes(), 0);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000A080 File Offset: 0x00008280
		public async Task DeviceLogDataFlush()
		{
			try
			{
				BandStatus status = null;
				Func<uint> BufferSize = () => 0U;
				int iTries = 0;
				do
				{
					byte[] status2 = (await this.Command((CommandEnum)DeviceCommands.CargoLoggerFlush, BufferSize, null)).Status;
					if (CommandResponse.ResponseBytesAreStatus(status2))
					{
						status = BandStatus.DeserializeFromBytes(status2);
					}
					CancellationToken.None.WaitAndThrowIfCancellationRequested(1000);
				}
				while (status == null || status.Status != 0U || iTries++ > 5);
				status = null;
				BufferSize = null;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000A0C8 File Offset: 0x000082C8
		public async Task<BandMetadataRange> GetChunkRangeMetadata(int chunkCount)
		{
			BandMetadataRange metaResult = null;
			MemoryStream memoryStream = new MemoryStream(12);
			new BinaryWriter(memoryStream).Write(chunkCount);
			byte[] btArgs = memoryStream.ToArray();
			try
			{
				Func<uint> bufferSize = () => 12U;
				byte[] bytes = (await this.Command((CommandEnum)DeviceCommands.CargoLoggerGetChunkRangeMetadata, bufferSize, btArgs, 8192U, null)).GetByteStream(0).GetBytes();
				metaResult = BandMetadataRange.DeserializeFromBytes(bytes);
			}
			catch (Exception)
			{
			}
			return metaResult;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000A118 File Offset: 0x00008318
		public async Task<byte[]> GetChunkRangeData(BandMetadataRange metaData, Action<ulong, ulong> Progress)
		{
			MemoryStream memoryStream = new MemoryStream(12);
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(metaData.StartingSeqNumber);
			binaryWriter.Write(metaData.EndingSeqNumber);
			binaryWriter.Write(metaData.ByteCount);
			byte[] btArgs = memoryStream.ToArray();
			byte[] btResult = null;
			try
			{
				Func<uint> bufferSize = () => metaData.ByteCount;
				CommandResponse commandResponse = await this.Command((CommandEnum)DeviceCommands.CargoLoggerGetChunkRangeData, bufferSize, btArgs, 8192U, Progress);
				btResult = commandResponse.GetAllData();
			}
			catch (Exception)
			{
			}
			return btResult;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000A170 File Offset: 0x00008370
		public async Task<bool> DeleteChunkRange(BandMetadataRange metaData)
		{
			MemoryStream memoryStream = new MemoryStream(12);
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(metaData.StartingSeqNumber);
			binaryWriter.Write(metaData.EndingSeqNumber);
			binaryWriter.Write(metaData.ByteCount);
			byte[] btArgs = memoryStream.ToArray();
			try
			{
				Func<uint> bufferSize = () => 12U;
				await this.CommandStore((CommandEnum)DeviceCommands.CargoLoggerDeleteChunkRange, bufferSize, btArgs, 8192U, null);
			}
			catch (Exception)
			{
			}
			return true;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000A1C0 File Offset: 0x000083C0
		public async Task<BandVersion> GetVersion()
		{
			return new BandVersion(await this.Command((CommandEnum)DeviceCommands.CargoCoreModuleGetVersion, null, null));
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0000A208 File Offset: 0x00008408
		public DataReader GetDataReader()
		{
			BandConnection<BandSocketUWP> bandConnection = this.Connection as BandConnection<BandSocketUWP>;
			if (bandConnection == null)
			{
				return null;
			}
			return bandConnection.Cargo.GetDataReader();
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000A234 File Offset: 0x00008434
		public DataWriter GetDataWriter()
		{
			BandConnection<BandSocketUWP> bandConnection = this.Connection as BandConnection<BandSocketUWP>;
			if (bandConnection == null)
			{
				return null;
			}
			return bandConnection.Cargo.GetDataWriter();
		}

		// Token: 0x04000154 RID: 340
		internal BluetoothDevice _device;
	}
}
