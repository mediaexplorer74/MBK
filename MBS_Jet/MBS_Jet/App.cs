// Decompiled with JetBrains decompiler
// Type: MobileBandSync.App
// Assembly: MobileBandSync, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AE79C20-CD20-4792-8F76-8817DEB4DE21
// Assembly location: C:\Users\Admin\Desktop\re\mobile\MobileBandSync.exe

using MobileBandSync.Common;
using MobileBandSync.Data;
using MobileBandSync.MobileBandSync_XamlTypeInfo;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace MobileBandSync
{
  public sealed class App : Application, IComponentConnector, IXamlMetadataProvider
  {
    private TransitionCollection transitions;
    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    private bool _contentLoaded;
    private XamlTypeInfoProvider _provider;

    public App()
    {
      this.InitializeComponent();
      // ISSUE: method pointer
      WindowsRuntimeMarshal.AddEventHandler<SuspendingEventHandler>(new Func<SuspendingEventHandler, EventRegistrationToken>(((Application) this).add_Suspending), new Action<EventRegistrationToken>(((Application) this).remove_Suspending), new SuspendingEventHandler((object) this, __methodptr(OnSuspending)));
    }

    protected virtual async void OnLaunched(LaunchActivatedEventArgs e)
    {
      if (!(Window.Current.Content is Frame rootFrame))
      {
        rootFrame = new Frame();
        SuspensionManager.RegisterFrame(rootFrame, "AppFrame");
        rootFrame.put_CacheSize(1);
        ((FrameworkElement) rootFrame).put_Language(WorkoutDataSource.AppCultureInfo.ToString());
        ApplicationLanguages.put_PrimaryLanguageOverride(((FrameworkElement) rootFrame).Language);
        if (e.PreviousExecutionState == 3)
        {
          try
          {
            await SuspensionManager.RestoreAsync();
          }
          catch (SuspensionManagerException ex)
          {
          }
        }
        Window.Current.put_Content((UIElement) rootFrame);
        ApplicationView.GetForCurrentView().put_Title("");
      }
      if (((ContentControl) rootFrame).Content == null)
      {
        if (((ContentControl) rootFrame).ContentTransitions != null)
        {
          this.transitions = new TransitionCollection();
          foreach (Transition contentTransition in (IEnumerable<Transition>) ((ContentControl) rootFrame).ContentTransitions)
            ((ICollection<Transition>) this.transitions).Add(contentTransition);
        }
        ((ContentControl) rootFrame).put_ContentTransitions((TransitionCollection) null);
        Frame frame = rootFrame;
        // ISSUE: method pointer
        WindowsRuntimeMarshal.AddEventHandler<NavigatedEventHandler>(new Func<NavigatedEventHandler, EventRegistrationToken>(frame.add_Navigated), new Action<EventRegistrationToken>(frame.remove_Navigated), new NavigatedEventHandler((object) this, __methodptr(RootFrame_FirstNavigated)));
        if (!rootFrame.Navigate(typeof (HubPage), (object) e.Arguments))
          throw new Exception("Failed to create initial page");
      }
      Window.Current.Activate();
    }

    private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
    {
      Frame frame = sender as Frame;
      TransitionCollection transitionCollection1 = this.transitions;
      if (transitionCollection1 == null)
      {
        TransitionCollection transitionCollection2 = new TransitionCollection();
        ((ICollection<Transition>) transitionCollection2).Add((Transition) new NavigationThemeTransition());
        transitionCollection1 = transitionCollection2;
      }
      ((ContentControl) frame).put_ContentTransitions(transitionCollection1);
      // ISSUE: virtual method pointer
      // ISSUE: method pointer
      WindowsRuntimeMarshal.RemoveEventHandler<NavigatedEventHandler>(new Action<EventRegistrationToken>((object) frame, __vmethodptr(frame, remove_Navigated)), new NavigatedEventHandler((object) this, __methodptr(RootFrame_FirstNavigated)));
    }

    private async void OnSuspending(object sender, SuspendingEventArgs e)
    {
      SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();
      await SuspensionManager.SaveAsync();
      deferral.Complete();
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void Connect(int connectionId, object target) => this._contentLoaded = true;

    public IXamlType GetXamlType(Type type)
    {
      if (this._provider == null)
        this._provider = new XamlTypeInfoProvider();
      return this._provider.GetXamlTypeByType(type);
    }

    public IXamlType GetXamlType(string fullName)
    {
      if (this._provider == null)
        this._provider = new XamlTypeInfoProvider();
      return this._provider.GetXamlTypeByName(fullName);
    }

    public XmlnsDefinition[] GetXmlnsDefinitions() => new XmlnsDefinition[0];
  }
}
