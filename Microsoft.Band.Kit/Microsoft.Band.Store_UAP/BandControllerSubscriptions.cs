// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.BandControllerSubscriptions
// Assembly: Microsoft.Band.Store_UAP, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 018DB8C7-131F-4953-86CB-5B9FE6B445B8
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Store_UAP.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace Microsoft.Band
{
  internal class BandControllerSubscriptions
  {
    internal static async Task<AppServiceResponse> SendRequestToBandControllerServiceAsync(
      ValueSet requestMessage)
    {
      string forAppServiceAsync = await BandControllerSubscriptions.GetPackageFamilyNameForAppServiceAsync(InternalBandControllerNames.BandControllerServiceName);
      AppServiceResponse controllerServiceAsync;
      using (AppServiceConnection bandControllerService = new AppServiceConnection())
      {
                //RnD
        //bandControllerService.AppServiceName(InternalBandControllerNames.BandControllerServiceName);
        //bandControllerService.PackageFamilyName(forAppServiceAsync);
        AppServiceConnectionStatus connectionStatus = await bandControllerService.OpenAsync();
        if (connectionStatus != null)
          throw new BandException(string.Format("Unable to connect to service, error {0}", (object) connectionStatus.ToString()));
        controllerServiceAsync = await bandControllerService.SendMessageAsync(requestMessage);
      }
      return controllerServiceAsync;
    }

    internal static void CheckResponse(AppServiceResponse response)
    {
      if (response.Status != null)
        throw new BandException(string.Format("Response error {0}", (object) response.Status));
      bool? nullable = ((IDictionary<string, object>) response.Message)[InternalBandControllerNames.ResponseSucceededParameterName] as bool?;
      if (!nullable.HasValue)
        throw new BandException("Response missing 'Succeeded'");
      if (nullable.Value)
        return;
      if (!(((IDictionary<string, object>) response.Message)[InternalBandControllerNames.ResponseStatusParameterName] is string str))
        throw new BandException("Response missing 'Status'");
      throw new BandException(string.Format("Response Status {0}", (object) str));
    }

    private static async Task<string> GetPackageFamilyNameForAppServiceAsync(
      string appServiceName)
    {
      IReadOnlyList<AppInfo> serviceProvidersAsync = 
                await AppServiceCatalog.FindAppServiceProvidersAsync(appServiceName);

      if (serviceProvidersAsync == null || ((IReadOnlyCollection<AppInfo>) serviceProvidersAsync).Count == 0)
        throw new BandException(string.Format("No service installed for AppService {0}", (object) appServiceName));
      return ((IEnumerable<AppInfo>) serviceProvidersAsync).Count<AppInfo>() <= 1 ? serviceProvidersAsync[0].PackageFamilyName : throw new BandException(string.Format("Multiple services installed for AppService {0}", (object) appServiceName));
    }
  }
}
