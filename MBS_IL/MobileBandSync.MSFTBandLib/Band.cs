using System;
using System.IO;
using System.Runtime.CompilerServices;
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
using Windows.UI.Core;

namespace MobileBandSync.MSFTBandLib;

public class Band<T> : BandInterface where T : class, BandSocketInterface
{
	internal BluetoothDevice _device;

	public string Mac { get; protected set; }

	public string Name { get; protected set; }

	public bool Connected
	{
		get
		{
			return Connection.Connected;
		}
		set
		{
			throw new Exception("Can't change connection directly!");
		}
	}

	public BandConnection<T> Connection { get; protected set; }

	public BluetoothDevice GetDevice()
	{
		return _device;
	}

	public Band(string mac, string name)
	{
		Mac = mac;
		Name = name;
		Connection = new BandConnection<T>(this);
		_device = null;
	}

	public Band(BluetoothDevice device)
	{
		if (device != null)
		{
			Mac = device.HostName.ToString();
			Name = device.Name;
			Connection = new BandConnection<T>(this);
			_device = device;
		}
	}

	public string GetMac()
	{
		return Mac;
	}

	public string GetName()
	{
		return Name;
	}

	public async Task Connect(Action<ulong, ulong> Progress = null)
	{
		if (!Connected)
		{
			await Connection.Connect(Progress);
			return;
		}
		throw new BandConnected();
	}

	public async Task Disconnect()
	{
		if (Connected)
		{
			await Connection.Disconnect();
		}
	}

	public async Task<CommandResponse> Command(CommandEnum Command, Func<uint> BufferSize, Action<ulong, ulong> Progress = null)
	{
		if (!Connected)
		{
			throw new BandConnectedNot();
		}
		return await Connection.Command(Command, BufferSize, null, 8192u, Progress);
	}

	public async Task<CommandResponse> Command(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs, uint uiBufferSize = 8192u, Action<ulong, ulong> Progress = null)
	{
		if (!Connected)
		{
			throw new BandConnectedNot();
		}
		return await Connection.Command(Command, BufferSize, btArgs, 8192u, Progress);
	}

	public async Task CommandStore(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs = null, uint uiBufferSize = 8192u, Action<ulong, ulong> Progress = null)
	{
		if (!Connected)
		{
			throw new BandConnectedNot();
		}
		await Connection.CommandStore(Command, BufferSize, btArgs, uiBufferSize, Progress);
	}

	public async Task<CommandResponse> CommandStoreStatus(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs = null, uint uiBufferSize = 8192u, Action<ulong, ulong> Progress = null)
	{
		if (!Connected)
		{
			throw new BandConnectedNot();
		}
		return await Connection.CommandStoreStatus(Command, BufferSize, btArgs, uiBufferSize, Progress);
	}

	public async Task<DateTime> GetDeviceTime()
	{
		return TimeHelper.DateTimeResponse(await Command(CommandEnum.GetDeviceTime, null));
	}

	public async Task<Sleep> GetLastSleep()
	{
		return new Sleep(await Command(CommandEnum.GetStatisticsSleep, null));
	}

	public async Task<string> GetSerialNumber()
	{
		return (await Command((CommandEnum)DeviceCommands.CargoGetProductSerialNumber, null)).GetByteStream().GetString(0, 0L);
	}

	public static byte[] Combine(byte[] first, byte[] second)
	{
		byte[] array = new byte[first.Length + second.Length];
		Buffer.BlockCopy(first, 0, array, 0, first.Length);
		Buffer.BlockCopy(second, 0, array, first.Length, second.Length);
		return array;
	}

	public async Task<byte[]> GetSensorLog(Action<string> Report, Action<ulong, ulong> Progress, bool bCleanupSensorLog, bool bStoreSensorLog)
	{
		byte[] btSensorLog = null;
		Progress(0uL, 0uL);
		try
		{
			BandMetadataRange metaData = null;
			await DeviceLogDataFlush();
			int num;
			try
			{
				num = await RemainingDeviceLogDataChunks();
			}
			catch (Exception)
			{
				num = 0;
			}
			if (num > 0)
			{
				int chunkCount = num;
				_ = metaData;
				metaData = await GetChunkRangeMetadata(chunkCount);
				if (metaData == null)
				{
					Report("* error: failed to get chunk range metadata!");
				}
				else
				{
					TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
					try
					{
						if (Progress != null)
						{
							TaskAwaiter taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync((CoreDispatcherPriority)0, (DispatchedHandler)delegate
							{
								Progress(0uL, metaData.ByteCount * 2);
							}));
							if (!taskAwaiter.IsCompleted)
							{
								await taskAwaiter;
								taskAwaiter = taskAwaiter2;
								taskAwaiter2 = default(TaskAwaiter);
							}
							taskAwaiter.GetResult();
						}
					}
					catch (Exception)
					{
					}
					btSensorLog = await GetChunkRangeData(metaData, Progress);
					if (btSensorLog != null && btSensorLog.Length != 0)
					{
						if (bStoreSensorLog)
						{
							string uploadId = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
							TaskAwaiter<StorageFolder> taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFolder>(KnownFolders.DocumentsLibrary.CreateFolderAsync("SensorLog", (CreationCollisionOption)3));
							if (!taskAwaiter3.IsCompleted)
							{
								await taskAwaiter3;
								TaskAwaiter<StorageFolder> taskAwaiter4 = default(TaskAwaiter<StorageFolder>);
								taskAwaiter3 = taskAwaiter4;
							}
							StorageFolder result = taskAwaiter3.GetResult();
							if (result == null)
							{
								return null;
							}
							TaskAwaiter<StorageFile> taskAwaiter5 = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(result.CreateFileAsync("band-" + uploadId + "-Data.bin", (CreationCollisionOption)1));
							if (!taskAwaiter5.IsCompleted)
							{
								await taskAwaiter5;
								TaskAwaiter<StorageFile> taskAwaiter6 = default(TaskAwaiter<StorageFile>);
								taskAwaiter5 = taskAwaiter6;
							}
							TaskAwaiter taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(FileIO.WriteBytesAsync((IStorageFile)(object)taskAwaiter5.GetResult(), btSensorLog));
							if (!taskAwaiter.IsCompleted)
							{
								await taskAwaiter;
								taskAwaiter = taskAwaiter2;
							}
							taskAwaiter.GetResult();
						}
						if (bCleanupSensorLog)
						{
							await DeleteChunkRange(metaData);
						}
					}
					else
					{
						Report("* error: failed to get chunk range data!");
					}
				}
			}
		}
		catch (Exception ex3)
		{
			Report("Error downloading the logs: " + ex3.Message);
			return null;
		}
		return btSensorLog;
	}

	public async Task<int> RemainingDeviceLogDataChunks()
	{
		return BitConverter.ToInt32((await Command((CommandEnum)DeviceCommands.CargoLoggerGetChunkCounts, null)).GetByteStream().GetBytes(), 0);
	}

	public async Task DeviceLogDataFlush()
	{
		try
		{
			BandStatus status = null;
			Func<uint> BufferSize = () => 0u;
			int iTries = 0;
			do
			{
				byte[] status2 = (await Command((CommandEnum)DeviceCommands.CargoLoggerFlush, BufferSize)).Status;
				if (CommandResponse.ResponseBytesAreStatus(status2))
				{
					status = BandStatus.DeserializeFromBytes(status2);
				}
				CancellationToken.None.WaitAndThrowIfCancellationRequested(1000);
			}
			while (status == null || status.Status != 0 || iTries++ > 5);
		}
		catch (Exception)
		{
		}
	}

	public async Task<BandMetadataRange> GetChunkRangeMetadata(int chunkCount)
	{
		BandMetadataRange metaResult = null;
		MemoryStream memoryStream = new MemoryStream(12);
		new BinaryWriter(memoryStream).Write(chunkCount);
		byte[] btArgs = memoryStream.ToArray();
		try
		{
			Func<uint> bufferSize = () => 12u;
			byte[] bytes = (await Command((CommandEnum)DeviceCommands.CargoLoggerGetChunkRangeMetadata, bufferSize, btArgs)).GetByteStream().GetBytes();
			metaResult = BandMetadataRange.DeserializeFromBytes(bytes);
			return metaResult;
		}
		catch (Exception)
		{
			return metaResult;
		}
	}

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
			btResult = (await Command((CommandEnum)DeviceCommands.CargoLoggerGetChunkRangeData, bufferSize, btArgs, 8192u, Progress)).GetAllData();
			return btResult;
		}
		catch (Exception)
		{
			return btResult;
		}
	}

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
			Func<uint> bufferSize = () => 12u;
			await CommandStore((CommandEnum)DeviceCommands.CargoLoggerDeleteChunkRange, bufferSize, btArgs);
		}
		catch (Exception)
		{
		}
		return true;
	}

	public async Task<BandVersion> GetVersion()
	{
		return new BandVersion(await Command((CommandEnum)DeviceCommands.CargoCoreModuleGetVersion, null));
	}

	public DataReader GetDataReader()
	{
		if (!(Connection is BandConnection<BandSocketUWP> bandConnection))
		{
			return null;
		}
		return bandConnection.Cargo.GetDataReader();
	}

	public DataWriter GetDataWriter()
	{
		if (!(Connection is BandConnection<BandSocketUWP> bandConnection))
		{
			return null;
		}
		return bandConnection.Cargo.GetDataWriter();
	}
}
