using System;
using System.CodeDom.Compiler;
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

namespace MobileBandSync
{
	// Token: 0x02000002 RID: 2
	public sealed class App : Application, IComponentConnector, IXamlMetadataProvider
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002048 File Offset: 0x00000248
		public App()
		{
			this.InitializeComponent();
			WindowsRuntimeMarshal.AddEventHandler<SuspendingEventHandler>(new Func<SuspendingEventHandler, EventRegistrationToken>(this.add_Suspending), new Action<EventRegistrationToken>(this.remove_Suspending), new SuspendingEventHandler(this.OnSuspending));
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002084 File Offset: 0x00000284
		protected override async void OnLaunched(LaunchActivatedEventArgs e)
		{
			Frame rootFrame = Window.Current.Content as Frame;
			if (rootFrame == null)
			{
				rootFrame = new Frame();
				SuspensionManager.RegisterFrame(rootFrame, "AppFrame", null);
				rootFrame.put_CacheSize(1);
				rootFrame.put_Language(WorkoutDataSource.AppCultureInfo.ToString());
				ApplicationLanguages.put_PrimaryLanguageOverride(rootFrame.Language);
				if (e.PreviousExecutionState == 3)
				{
					try
					{
						await SuspensionManager.RestoreAsync(null);
					}
					catch (SuspensionManagerException)
					{
					}
				}
				Window.Current.put_Content(rootFrame);
				ApplicationView.GetForCurrentView().put_Title("");
			}
			if (rootFrame.Content == null)
			{
				if (rootFrame.ContentTransitions != null)
				{
					this.transitions = new TransitionCollection();
					foreach (Transition item in rootFrame.ContentTransitions)
					{
						this.transitions.Add(item);
					}
				}
				rootFrame.put_ContentTransitions(null);
				Frame @object = rootFrame;
				WindowsRuntimeMarshal.AddEventHandler<NavigatedEventHandler>(new Func<NavigatedEventHandler, EventRegistrationToken>(@object.add_Navigated), new Action<EventRegistrationToken>(@object.remove_Navigated), new NavigatedEventHandler(this.RootFrame_FirstNavigated));
				if (!rootFrame.Navigate(typeof(HubPage), e.Arguments))
				{
					throw new Exception("Failed to create initial page");
				}
			}
			Window.Current.Activate();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020C8 File Offset: 0x000002C8
		private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
		{
			Frame frame = sender as Frame;
			TransitionCollection transitionCollection;
			if ((transitionCollection = this.transitions) == null)
			{
				(transitionCollection = new TransitionCollection()).Add(new NavigationThemeTransition());
			}
			frame.put_ContentTransitions(transitionCollection);
			WindowsRuntimeMarshal.RemoveEventHandler<NavigatedEventHandler>(new Action<EventRegistrationToken>(frame.remove_Navigated), new NavigatedEventHandler(this.RootFrame_FirstNavigated));
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002118 File Offset: 0x00000318
		private async void OnSuspending(object sender, SuspendingEventArgs e)
		{
			SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();
			await SuspensionManager.SaveAsync();
			deferral.Complete();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002151 File Offset: 0x00000351
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002163 File Offset: 0x00000363
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		[DebuggerNonUserCode]
		public void Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000216C File Offset: 0x0000036C
		public IXamlType GetXamlType(Type type)
		{
			if (this._provider == null)
			{
				this._provider = new XamlTypeInfoProvider();
			}
			return this._provider.GetXamlTypeByType(type);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000218D File Offset: 0x0000038D
		public IXamlType GetXamlType(string fullName)
		{
			if (this._provider == null)
			{
				this._provider = new XamlTypeInfoProvider();
			}
			return this._provider.GetXamlTypeByName(fullName);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021AE File Offset: 0x000003AE
		public XmlnsDefinition[] GetXmlnsDefinitions()
		{
			return new XmlnsDefinition[0];
		}

		// Token: 0x04000001 RID: 1
		private TransitionCollection transitions;

		// Token: 0x04000002 RID: 2
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private bool _contentLoaded;

		// Token: 0x04000003 RID: 3
		private XamlTypeInfoProvider _provider;
	}
}
