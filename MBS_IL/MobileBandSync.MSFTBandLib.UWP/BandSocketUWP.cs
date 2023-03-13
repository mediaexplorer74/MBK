using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MobileBandSync.MSFTBandLib.Command;
using MobileBandSync.MSFTBandLib.Exceptions;
using Windows.ApplicationModel.Core;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Foundation;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Core;

namespace MobileBandSync.MSFTBandLib.UWP;

public class BandSocketUWP : BandSocketInterface, IDisposable
{
	protected StreamSocket Socket;

	protected DataReader DataReader;

	protected DataWriter DataWriter;

	public bool Connected { get; protected set; }

	public bool Disposed { get; protected set; }

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!Disposed)
		{
			Socket.Dispose();
			DataReader.Dispose();
			DataWriter.Dispose();
			Disposed = true;
		}
	}

	public async Task Connect(string mac, Guid uuid, Action<ulong, ulong> Progress = null)
	{
		if (Connected)
		{
			return;
		}
		TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
		TaskAwaiter taskAwaiter;
		try
		{
			if (Progress != null)
			{
				taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync((CoreDispatcherPriority)0, (DispatchedHandler)delegate
				{
					Progress(0uL, 0uL);
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
		HostName host = new HostName(mac);
		RfcommDeviceService val = await GetRfcommDeviceServiceForHostFromUuid(host, uuid);
		Socket = new StreamSocket();
		taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(Socket.ConnectAsync(host, val.ConnectionServiceName, (SocketProtectionLevel)3));
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			taskAwaiter = taskAwaiter2;
		}
		taskAwaiter.GetResult();
		BandSocketUWP bandSocketUWP = this;
		DataReader val2 = new DataReader(Socket.InputStream);
		val2.put_InputStreamOptions((InputStreamOptions)1);
		bandSocketUWP.DataReader = val2;
		DataWriter = new DataWriter(Socket.OutputStream);
		Connected = true;
	}

	public async Task Disconnect()
	{
		if (Connected)
		{
			await Task.Run(delegate
			{
				DataReader.DetachStream();
				DataReader.Dispose();
				DataWriter.DetachStream();
				DataWriter.Dispose();
				Socket.Dispose();
				Connected = false;
			});
			return;
		}
		throw new BandSocketConnectedNot();
	}

	public async Task Send(CommandPacket packet)
	{
		if (!Connected)
		{
			throw new BandSocketConnectedNot();
		}
		DataWriter.WriteBytes(packet.GetBytes());
		TaskAwaiter<uint> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<uint>((IAsyncOperation<uint>)(object)DataWriter.StoreAsync());
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<uint> taskAwaiter2 = default(TaskAwaiter<uint>);
			taskAwaiter = taskAwaiter2;
		}
		taskAwaiter.GetResult();
	}

	public async Task Send(CommandPacket packet, byte[] bytesToSend)
	{
		if (!Connected)
		{
			throw new BandSocketConnectedNot();
		}
		DataWriter.WriteBytes(packet.GetBytes());
		TaskAwaiter<uint> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<uint>((IAsyncOperation<uint>)(object)DataWriter.StoreAsync());
		TaskAwaiter<uint> taskAwaiter2 = default(TaskAwaiter<uint>);
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<uint>);
		}
		taskAwaiter.GetResult();
		if (bytesToSend != null)
		{
			DataWriter.WriteBytes(bytesToSend);
			taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<uint>((IAsyncOperation<uint>)(object)DataWriter.StoreAsync());
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
			}
			taskAwaiter.GetResult();
		}
	}

	public async Task<int> SendStatus(CommandPacket packet, byte[] bytesToSend)
	{
		if (!Connected)
		{
			throw new BandSocketConnectedNot();
		}
		DataWriter.WriteBytes(packet.GetBytes());
		TaskAwaiter<uint> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<uint>((IAsyncOperation<uint>)(object)DataWriter.StoreAsync());
		TaskAwaiter<uint> taskAwaiter2 = default(TaskAwaiter<uint>);
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<uint>);
		}
		taskAwaiter.GetResult();
		if (bytesToSend != null)
		{
			DataWriter.WriteBytes(bytesToSend);
			taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<uint>((IAsyncOperation<uint>)(object)DataWriter.StoreAsync());
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<uint>);
			}
			taskAwaiter.GetResult();
		}
		taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<uint>((IAsyncOperation<uint>)(object)DataReader.LoadAsync(12u));
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			taskAwaiter = taskAwaiter2;
		}
		uint result = taskAwaiter.GetResult();
		byte[] array = ReadBytes(result);
		int num = array[0];
		int num2 = array[1];
		if (num == 254 || num2 == 166)
		{
			return 0;
		}
		return 1;
	}

	public async Task<CommandResponse> Receive(uint buffer, Action<ulong, ulong> Progress = null)
	{
		return await Task.Run(async delegate
		{
			CommandResponse response = new CommandResponse();
			if (!Connected)
			{
				throw new BandSocketConnectedNot();
			}
			TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
			while (true)
			{
				uint bytes = 0u;
				_ = response;
				response = await Task.Run(async delegate
				{
					_ = bytes;
					TaskAwaiter<uint> taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<uint>((IAsyncOperation<uint>)(object)DataReader.LoadAsync(buffer));
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						TaskAwaiter<uint> taskAwaiter4 = default(TaskAwaiter<uint>);
						taskAwaiter3 = taskAwaiter4;
					}
					uint result = taskAwaiter3.GetResult();
					bytes = result;
					response.AddResponse(ReadBytes(bytes));
					return response;
				});
				try
				{
					if (Progress != null)
					{
						TaskAwaiter taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync((CoreDispatcherPriority)0, (DispatchedHandler)delegate
						{
							Progress(bytes, 0uL);
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
				if (response.StatusReceived() || bytes == 0)
				{
					break;
				}
			}
			return response;
		});
	}

	public async Task<CommandResponse> Request(CommandPacket packet, uint buffer, Action<ulong, ulong> Progress = null)
	{
		if (Connected)
		{
			await Send(packet);
			return await Receive(buffer, Progress);
		}
		throw new BandSocketConnectedNot();
	}

	public async Task<CommandResponse> Put(CommandPacket packet, uint buffer)
	{
		if (Connected)
		{
			await Send(packet);
			return await Receive(buffer);
		}
		throw new BandSocketConnectedNot();
	}

	protected byte[] ReadBytes(uint count)
	{
		byte[] array = new byte[count];
		DataReader.ReadBytes(array);
		return array;
	}

	public static async Task<RfcommDeviceService> GetRfcommDeviceServiceForHostFromUuid(HostName host, Guid uuid)
	{
		RfcommServiceId.FromUuid(uuid);
		TaskAwaiter<BluetoothDevice> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<BluetoothDevice>(BluetoothDevice.FromHostNameAsync(host));
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<BluetoothDevice> taskAwaiter2 = default(TaskAwaiter<BluetoothDevice>);
			taskAwaiter = taskAwaiter2;
		}
		return taskAwaiter.GetResult().RfcommServices[0];
	}

	public DataReader GetDataReader()
	{
		return DataReader;
	}

	public DataWriter GetDataWriter()
	{
		return DataWriter;
	}
}
