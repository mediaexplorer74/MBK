using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using MobileBandSync.Common;
using MobileBandSync.Data;
using MobileBandSync.MobileBandSync_XamlTypeInfo;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace MobileBandSync;

public sealed class App : Application, IComponentConnector, IXamlMetadataProvider
{
	private TransitionCollection transitions;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private bool _contentLoaded;

	private XamlTypeInfoProvider _provider;

	public App()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		InitializeComponent();
		WindowsRuntimeMarshal.AddEventHandler((Func<SuspendingEventHandler, EventRegistrationToken>)((Application)this).add_Suspending, (Action<EventRegistrationToken>)((Application)this).remove_Suspending, new SuspendingEventHandler(OnSuspending));
	}

	protected override async void OnLaunched(LaunchActivatedEventArgs e)
	{
		UIElement content = Window.Current.Content;
		Frame rootFrame = (Frame)(object)((content is Frame) ? content : null);
		if (rootFrame == null)
		{
			rootFrame = new Frame();
			SuspensionManager.RegisterFrame(rootFrame, "AppFrame");
			rootFrame.put_CacheSize(1);
			((FrameworkElement)rootFrame).put_Language(WorkoutDataSource.AppCultureInfo.ToString());
			ApplicationLanguages.put_PrimaryLanguageOverride(((FrameworkElement)rootFrame).Language);
			if ((int)e.PreviousExecutionState == 3)
			{
				try
				{
					await SuspensionManager.RestoreAsync();
				}
				catch (SuspensionManagerException)
				{
				}
			}
			Window.Current.put_Content((UIElement)(object)rootFrame);
			ApplicationView.GetForCurrentView().put_Title("");
		}
		if (((ContentControl)rootFrame).Content == null)
		{
			if (((ContentControl)rootFrame).ContentTransitions != null)
			{
				transitions = new TransitionCollection();
				foreach (Transition item in (IEnumerable<Transition>)((ContentControl)rootFrame).ContentTransitions)
				{
					((ICollection<Transition>)transitions).Add(item);
				}
			}
			((ContentControl)rootFrame).put_ContentTransitions((TransitionCollection)null);
			Frame val = rootFrame;
			WindowsRuntimeMarshal.AddEventHandler((Func<NavigatedEventHandler, EventRegistrationToken>)val.add_Navigated, (Action<EventRegistrationToken>)val.remove_Navigated, new NavigatedEventHandler(RootFrame_FirstNavigated));
			if (!rootFrame.Navigate(typeof(HubPage), (object)e.Arguments))
			{
				throw new Exception("Failed to create initial page");
			}
		}
		Window.Current.Activate();
	}

	private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0021: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		object obj = ((sender is Frame) ? sender : null);
		object obj2 = transitions;
		if (obj2 == null)
		{
			TransitionCollection val = new TransitionCollection();
			obj2 = (object)val;
			((ICollection<Transition>)val).Add((Transition)new NavigationThemeTransition());
		}
		((ContentControl)obj).put_ContentTransitions((TransitionCollection)obj2);
		WindowsRuntimeMarshal.RemoveEventHandler<NavigatedEventHandler>((Action<EventRegistrationToken>)((Frame)obj).remove_Navigated, new NavigatedEventHandler(RootFrame_FirstNavigated));
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
		if (!_contentLoaded)
		{
			_contentLoaded = true;
		}
	}

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	[DebuggerNonUserCode]
	public void Connect(int connectionId, object target)
	{
		_contentLoaded = true;
	}

	public IXamlType GetXamlType(Type type)
	{
		if (_provider == null)
		{
			_provider = new XamlTypeInfoProvider();
		}
		return _provider.GetXamlTypeByType(type);
	}

	public IXamlType GetXamlType(string fullName)
	{
		if (_provider == null)
		{
			_provider = new XamlTypeInfoProvider();
		}
		return _provider.GetXamlTypeByName(fullName);
	}

	public XmlnsDefinition[] GetXmlnsDefinitions()
	{
		return (XmlnsDefinition[])(object)new XmlnsDefinition[0];
	}
}
