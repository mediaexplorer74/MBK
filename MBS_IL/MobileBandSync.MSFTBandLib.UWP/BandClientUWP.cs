using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Enumeration;

namespace MobileBandSync.MSFTBandLib.UWP;

public class BandClientUWP : BandClientInterface
{
	public async Task<List<BandInterface>> GetPairedBands()
	{
		List<BandInterface> bands = new List<BandInterface>();
		TaskAwaiter<DeviceInformationCollection> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<DeviceInformationCollection>(DeviceInformation.FindAllAsync(RfcommDeviceService.GetDeviceSelector(RfcommServiceId.FromUuid(Guid.Parse("a502ca97-2ba5-413c-a4e0-13804e47b38f")))));
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<DeviceInformationCollection> taskAwaiter2 = default(TaskAwaiter<DeviceInformationCollection>);
			taskAwaiter = taskAwaiter2;
		}
		DeviceInformationCollection result = taskAwaiter.GetResult();
		TaskAwaiter<BluetoothDevice> taskAwaiter4 = default(TaskAwaiter<BluetoothDevice>);
		foreach (DeviceInformation item in (IEnumerable<DeviceInformation>)result)
		{
			TaskAwaiter<BluetoothDevice> taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<BluetoothDevice>(BluetoothDevice.FromIdAsync(item.Id));
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter<BluetoothDevice>);
			}
			BluetoothDevice result2 = taskAwaiter3.GetResult();
			if (result2 != null)
			{
				bands.Add(new Band<BandSocketUWP>(result2));
			}
		}
		return bands;
	}
}
