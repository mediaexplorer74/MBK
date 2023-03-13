using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using MobileBandSync.Common;
using MobileBandSync.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Navigation;

namespace MobileBandSync;

public sealed class ItemPage : Page, IComponentConnector
{
	private readonly NavigationHelper navigationHelper;

	private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Page pageRoot;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Grid LayoutRoot;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Grid ContentRoot;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private bool _contentLoaded;

	public NavigationHelper NavigationHelper => navigationHelper;

	public ObservableDictionary DefaultViewModel => defaultViewModel;

	public ItemPage()
	{
		InitializeComponent();
		navigationHelper = new NavigationHelper((Page)(object)this);
		navigationHelper.LoadState += NavigationHelper_LoadState;
		navigationHelper.SaveState += NavigationHelper_SaveState;
	}

	private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
	{
		TrackItem value = await WorkoutDataSource.GetItemAsync((string)e.NavigationParameter);
		DefaultViewModel["Item"] = value;
	}

	private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
	{
	}

	protected override void OnNavigatedTo(NavigationEventArgs e)
	{
		navigationHelper.OnNavigatedTo(e);
	}

	protected override void OnNavigatedFrom(NavigationEventArgs e)
	{
		navigationHelper.OnNavigatedFrom(e);
	}

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Application.LoadComponent((object)this, new Uri("ms-appx:///ItemPage.xaml"), (ComponentResourceLocation)0);
			pageRoot = (Page)((FrameworkElement)this).FindName("pageRoot");
			LayoutRoot = (Grid)((FrameworkElement)this).FindName("LayoutRoot");
			ContentRoot = (Grid)((FrameworkElement)this).FindName("ContentRoot");
		}
	}

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	[DebuggerNonUserCode]
	public void Connect(int connectionId, object target)
	{
		_contentLoaded = true;
	}
}
