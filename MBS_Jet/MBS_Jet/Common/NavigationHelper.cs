﻿// Decompiled with JetBrains decompiler
// Type: MobileBandSync.Common.NavigationHelper
// Assembly: MobileBandSync, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AE79C20-CD20-4792-8F76-8817DEB4DE21
// Assembly location: C:\Users\Admin\Desktop\re\mobile\MobileBandSync.exe

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MobileBandSync.Common
{
  [WebHostHidden]
  public class NavigationHelper : DependencyObject
  {
    private RelayCommand _goBackCommand;
    private RelayCommand _goForwardCommand;
    private string _pageKey;

    private Page Page { get; set; }

    private Frame Frame => this.Page.Frame;

    public NavigationHelper(Page page)
    {
      this.Page = page;
      Page page1 = this.Page;
      // ISSUE: method pointer
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((FrameworkElement) page1).add_Loaded), new Action<EventRegistrationToken>(((FrameworkElement) page1).remove_Loaded), new RoutedEventHandler((object) this, __methodptr(\u003C\u002Ector\u003Eb__6_0)));
      Page page2 = this.Page;
      // ISSUE: method pointer
      WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(((FrameworkElement) page2).add_Unloaded), new Action<EventRegistrationToken>(((FrameworkElement) page2).remove_Unloaded), new RoutedEventHandler((object) this, __methodptr(\u003C\u002Ector\u003Eb__6_1)));
    }

    public RelayCommand GoBackCommand
    {
      get
      {
        if (this._goBackCommand == null)
          this._goBackCommand = new RelayCommand((Action) (() => this.GoBack()), (Func<bool>) (() => this.CanGoBack()));
        return this._goBackCommand;
      }
      set => this._goBackCommand = value;
    }

    public RelayCommand GoForwardCommand
    {
      get
      {
        if (this._goForwardCommand == null)
          this._goForwardCommand = new RelayCommand((Action) (() => this.GoForward()), (Func<bool>) (() => this.CanGoForward()));
        return this._goForwardCommand;
      }
    }

    public virtual bool CanGoBack() => this.Frame != null && this.Frame.CanGoBack;

    public virtual bool CanGoForward() => this.Frame != null && this.Frame.CanGoForward;

    public virtual void GoBack()
    {
      if (this.Frame == null || !this.Frame.CanGoBack)
        return;
      this.Frame.GoBack();
    }

    public virtual void GoForward()
    {
      if (this.Frame == null || !this.Frame.CanGoForward)
        return;
      this.Frame.GoForward();
    }

    private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
      if (!this.GoBackCommand.CanExecute((object) null))
        return;
      e.put_Handled(true);
      this.GoBackCommand.Execute((object) null);
    }

    public event LoadStateEventHandler LoadState;

    public event SaveStateEventHandler SaveState;

    public void OnNavigatedTo(NavigationEventArgs e)
    {
      Dictionary<string, object> dictionary = SuspensionManager.SessionStateForFrame(this.Frame);
      this._pageKey = "Page-" + (object) this.Frame.BackStackDepth;
      if (e.NavigationMode == null)
      {
        string key = this._pageKey;
        int backStackDepth = this.Frame.BackStackDepth;
        for (; dictionary.Remove(key); key = "Page-" + (object) backStackDepth)
          ++backStackDepth;
        if (this.LoadState == null)
          return;
        this.LoadState((object) this, new LoadStateEventArgs(e.Parameter, (Dictionary<string, object>) null));
      }
      else
      {
        if (this.LoadState == null)
          return;
        this.LoadState((object) this, new LoadStateEventArgs(e.Parameter, (Dictionary<string, object>) dictionary[this._pageKey]));
      }
    }

    public void OnNavigatedFrom(NavigationEventArgs e)
    {
      Dictionary<string, object> dictionary1 = SuspensionManager.SessionStateForFrame(this.Frame);
      Dictionary<string, object> pageState = new Dictionary<string, object>();
      if (this.SaveState != null)
        this.SaveState((object) this, new SaveStateEventArgs(pageState));
      string pageKey = this._pageKey;
      Dictionary<string, object> dictionary2 = pageState;
      dictionary1[pageKey] = (object) dictionary2;
    }
  }
}
