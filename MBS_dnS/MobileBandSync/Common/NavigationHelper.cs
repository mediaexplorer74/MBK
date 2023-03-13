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
	// Token: 0x02000080 RID: 128
	[WebHostHidden]
	public class NavigationHelper : DependencyObject
	{
		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x0000DB66 File Offset: 0x0000BD66
		// (set) Token: 0x060004D3 RID: 1235 RVA: 0x0000DB6E File Offset: 0x0000BD6E
		private Page Page { get; set; }

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x0000DB77 File Offset: 0x0000BD77
		private Frame Frame
		{
			get
			{
				return this.Page.Frame;
			}
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0000DB84 File Offset: 0x0000BD84
		public NavigationHelper(Page page)
		{
			this.Page = page;
			Page page2 = this.Page;
			WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(page2.add_Loaded), new Action<EventRegistrationToken>(page2.remove_Loaded), delegate(object sender, RoutedEventArgs e)
			{
				WindowsRuntimeMarshal.AddEventHandler<EventHandler<BackPressedEventArgs>>(new Func<EventHandler<BackPressedEventArgs>, EventRegistrationToken>(HardwareButtons.add_BackPressed), new Action<EventRegistrationToken>(HardwareButtons.remove_BackPressed), new EventHandler<BackPressedEventArgs>(this.HardwareButtons_BackPressed));
			});
			page2 = this.Page;
			WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(page2.add_Unloaded), new Action<EventRegistrationToken>(page2.remove_Unloaded), delegate(object sender, RoutedEventArgs e)
			{
				WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<BackPressedEventArgs>>(new Action<EventRegistrationToken>(HardwareButtons.remove_BackPressed), new EventHandler<BackPressedEventArgs>(this.HardwareButtons_BackPressed));
			});
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x0000DC02 File Offset: 0x0000BE02
		// (set) Token: 0x060004D7 RID: 1239 RVA: 0x0000DC35 File Offset: 0x0000BE35
		public RelayCommand GoBackCommand
		{
			get
			{
				if (this._goBackCommand == null)
				{
					this._goBackCommand = new RelayCommand(delegate()
					{
						this.GoBack();
					}, () => this.CanGoBack());
				}
				return this._goBackCommand;
			}
			set
			{
				this._goBackCommand = value;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0000DC3E File Offset: 0x0000BE3E
		public RelayCommand GoForwardCommand
		{
			get
			{
				if (this._goForwardCommand == null)
				{
					this._goForwardCommand = new RelayCommand(delegate()
					{
						this.GoForward();
					}, () => this.CanGoForward());
				}
				return this._goForwardCommand;
			}
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0000DC71 File Offset: 0x0000BE71
		public virtual bool CanGoBack()
		{
			return this.Frame != null && this.Frame.CanGoBack;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0000DC88 File Offset: 0x0000BE88
		public virtual bool CanGoForward()
		{
			return this.Frame != null && this.Frame.CanGoForward;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0000DC9F File Offset: 0x0000BE9F
		public virtual void GoBack()
		{
			if (this.Frame != null && this.Frame.CanGoBack)
			{
				this.Frame.GoBack();
			}
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0000DCC1 File Offset: 0x0000BEC1
		public virtual void GoForward()
		{
			if (this.Frame != null && this.Frame.CanGoForward)
			{
				this.Frame.GoForward();
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0000DCE3 File Offset: 0x0000BEE3
		private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
		{
			if (this.GoBackCommand.CanExecute(null))
			{
				e.put_Handled(true);
				this.GoBackCommand.Execute(null);
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060004DE RID: 1246 RVA: 0x0000DD08 File Offset: 0x0000BF08
		// (remove) Token: 0x060004DF RID: 1247 RVA: 0x0000DD40 File Offset: 0x0000BF40
		public event LoadStateEventHandler LoadState;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060004E0 RID: 1248 RVA: 0x0000DD78 File Offset: 0x0000BF78
		// (remove) Token: 0x060004E1 RID: 1249 RVA: 0x0000DDB0 File Offset: 0x0000BFB0
		public event SaveStateEventHandler SaveState;

		// Token: 0x060004E2 RID: 1250 RVA: 0x0000DDE8 File Offset: 0x0000BFE8
		public void OnNavigatedTo(NavigationEventArgs e)
		{
			Dictionary<string, object> dictionary = SuspensionManager.SessionStateForFrame(this.Frame);
			this._pageKey = "Page-" + this.Frame.BackStackDepth;
			if (e.NavigationMode == null)
			{
				string key = this._pageKey;
				int num = this.Frame.BackStackDepth;
				while (dictionary.Remove(key))
				{
					num++;
					key = "Page-" + num;
				}
				if (this.LoadState != null)
				{
					this.LoadState(this, new LoadStateEventArgs(e.Parameter, null));
					return;
				}
			}
			else if (this.LoadState != null)
			{
				this.LoadState(this, new LoadStateEventArgs(e.Parameter, (Dictionary<string, object>)dictionary[this._pageKey]));
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0000DEB0 File Offset: 0x0000C0B0
		public void OnNavigatedFrom(NavigationEventArgs e)
		{
			Dictionary<string, object> dictionary = SuspensionManager.SessionStateForFrame(this.Frame);
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			if (this.SaveState != null)
			{
				this.SaveState(this, new SaveStateEventArgs(dictionary2));
			}
			dictionary[this._pageKey] = dictionary2;
		}

		// Token: 0x0400033C RID: 828
		private RelayCommand _goBackCommand;

		// Token: 0x0400033D RID: 829
		private RelayCommand _goForwardCommand;

		// Token: 0x0400033E RID: 830
		private string _pageKey;
	}
}
