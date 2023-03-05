// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.StoreApplicationPlatformProvider
// Assembly: Microsoft.Band.Store_UAP, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 018DB8C7-131F-4953-86CB-5B9FE6B445B8
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Store_UAP.dll

using Microsoft.Band.Tiles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Store;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace Microsoft.Band
{
  public sealed class StoreApplicationPlatformProvider : IApplicationPlatformProvider
  {
    private static readonly IApplicationPlatformProvider current = (IApplicationPlatformProvider) new StoreApplicationPlatformProvider();

    private StoreApplicationPlatformProvider()
    {
    }

    public static IApplicationPlatformProvider Current => StoreApplicationPlatformProvider.current;

    [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
    public Task<Guid> GetApplicationIdAsync(CancellationToken token)
    {
      Guid result;
      try
      {
        result = CurrentApp.AppId;
      }
      catch
      {
        IBuffer binary = CryptographicBuffer.ConvertStringToBinary(Package.Current.Id.Name, (BinaryStringEncoding) 0);
        result = new Guid(CryptographicBuffer.EncodeToHexString(HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5).HashData(binary)));
      }
      if (result == Guid.Empty)
        result = new Guid(Encoding.UTF8.GetBytes("#DEBUG-ONLY-GUID"));
      return Task.FromResult<Guid>(result);
    }

    public Task<bool> GetAddTileConsentAsync(BandTile tile, CancellationToken token) => StoreApplicationPlatformProvider.RequestConsentAsync(string.Format(BandResources.AddTileConsentPrompt, (object) tile.Name), token);

    public UserConsent GetCurrentSensorConsent(Type sensorType)
    {
      object obj = ((IDictionary<string, object>) ApplicationData.Current.LocalSettings.Values)[StoreApplicationPlatformProvider.CreateSensorAccessConsentSettingsKey(sensorType)];
      if (obj == null || !(obj is bool flag))
        return UserConsent.NotSpecified;
      return !flag ? UserConsent.Declined : UserConsent.Granted;
    }

    public async Task<bool> RequestSensorConsentAsync(
      Type sensorType,
      string prompt,
      CancellationToken token)
    {
      bool flag = await StoreApplicationPlatformProvider.RequestConsentAsync(prompt, token);
      ((IDictionary<string, object>) ApplicationData.Current.LocalSettings.Values)[StoreApplicationPlatformProvider.CreateSensorAccessConsentSettingsKey(sensorType)] = (object) flag;
      return flag;
    }

    private static async Task<bool> RequestConsentAsync(string prompt, CancellationToken token)
    {
      token.ThrowIfCancellationRequested();
      MessageDialog messageDialog = new MessageDialog(prompt, BandResources.ConsentDialogTitle);
      ((ICollection<IUICommand>) messageDialog.Commands).Add((IUICommand) new UICommand(BandResources.UICommandLabelYes, (UICommandInvokedHandler) null, (object) 0U));
      ((ICollection<IUICommand>) messageDialog.Commands).Add((IUICommand) new UICommand(BandResources.UICommandLabelNo, (UICommandInvokedHandler) null, (object) 1U));
      
      //RnD
      //messageDialog.put_DefaultCommandIndex(0U);
      //messageDialog.put_CancelCommandIndex(1U);
      return Convert.ToUInt32((await messageDialog.ShowAsync()).Id) == 0U;
    }

    private static string CreateSensorAccessConsentSettingsKey(Type sensorType) => string.Format("BandSensorAccessConcent-{0}", (object) sensorType);
  }
}
