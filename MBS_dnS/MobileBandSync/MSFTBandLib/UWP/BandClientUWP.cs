using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Enumeration;

namespace MobileBandSync.MSFTBandLib.UWP
{
	// Token: 0x02000062 RID: 98
	public class BandClientUWP : BandClientInterface
	{
		// Token: 0x06000375 RID: 885 RVA: 0x0000B258 File Offset: 0x00009458
		public async Task<List<BandInterface>> GetPairedBands()
		{
			List<BandInterface> bands = new List<BandInterface>();
			DeviceInformationCollection deviceInformationCollection = await DeviceInformation.FindAllAsync(RfcommDeviceService.GetDeviceSelector(RfcommServiceId.FromUuid(Guid.Parse("a502ca97-2ba5-413c-a4e0-13804e47b38f"))));
			foreach (DeviceInformation deviceInformation in deviceInformationCollection)
			{
				BluetoothDevice bluetoothDevice = await BluetoothDevice.FromIdAsync(deviceInformation.Id);
				if (bluetoothDevice != null)
				{
					bands.Add(new Band<BandSocketUWP>(bluetoothDevice));
				}
			}
			IEnumerator<DeviceInformation> enumerator = null;
			return bands;
		}
	}
}
