using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using MobileBandSync.Common;
using MobileBandSync.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Navigation;

namespace MobileBandSync
{
	// Token: 0x02000004 RID: 4
	public sealed class ItemPage : Page, IComponentConnector
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00002928 File Offset: 0x00000B28
		public ItemPage()
		{
			this.InitializeComponent();
			this.navigationHelper = new NavigationHelper(this);
			this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
			this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002986 File Offset: 0x00000B86
		public NavigationHelper NavigationHelper
		{
			get
			{
				return this.navigationHelper;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002C RID: 44 RVA: 0x0000298E File Offset: 0x00000B8E
		public ObservableDictionary DefaultViewModel
		{
			get
			{
				return this.defaultViewModel;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002998 File Offset: 0x00000B98
		private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
		{
			TrackItem value = await WorkoutDataSource.GetItemAsync((string)e.NavigationParameter);
			this.DefaultViewModel["Item"] = value;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000234D File Offset: 0x0000054D
		private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000029D9 File Offset: 0x00000BD9
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			this.navigationHelper.OnNavigatedTo(e);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000029E7 File Offset: 0x00000BE7
		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			this.navigationHelper.OnNavigatedFrom(e);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000029F8 File Offset: 0x00000BF8
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Application.LoadComponent(this, new Uri("ms-appx:///ItemPage.xaml"), 0);
			this.pageRoot = (Page)base.FindName("pageRoot");
			this.LayoutRoot = (Grid)base.FindName("LayoutRoot");
			this.ContentRoot = (Grid)base.FindName("ContentRoot");
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002A68 File Offset: 0x00000C68
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		[DebuggerNonUserCode]
		public void Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000019 RID: 25
		private readonly NavigationHelper navigationHelper;

		// Token: 0x0400001A RID: 26
		private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

		// Token: 0x0400001B RID: 27
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Page pageRoot;

		// Token: 0x0400001C RID: 28
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Grid LayoutRoot;

		// Token: 0x0400001D RID: 29
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Grid ContentRoot;

		// Token: 0x0400001E RID: 30
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private bool _contentLoaded;
	}
}
