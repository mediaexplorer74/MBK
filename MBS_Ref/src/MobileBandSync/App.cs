namespace MobileBandSync
{
    using MobileBandSync.Common;
    using MobileBandSync.Data;
    using MobileBandSync.MobileBandSync_XamlTypeInfo;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
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

    public sealed class App : Application, IComponentConnector, IXamlMetadataProvider
    {
        private TransitionCollection transitions;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private bool _contentLoaded;
        private XamlTypeInfoProvider _provider;

        public App()
        {
            this.InitializeComponent();
            WindowsRuntimeMarshal.AddEventHandler<SuspendingEventHandler>(new Func<SuspendingEventHandler, EventRegistrationToken>(this, this.add_Suspending), new Action<EventRegistrationToken>(this, this.remove_Suspending), new SuspendingEventHandler(this, this.OnSuspending));
        }

        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0"), DebuggerNonUserCode]
        public void Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        public IXamlType GetXamlType(string fullName)
        {
            this._provider ??= new XamlTypeInfoProvider();
            return this._provider.GetXamlTypeByName(fullName);
        }

        public IXamlType GetXamlType(Type type)
        {
            this._provider ??= new XamlTypeInfoProvider();
            return this._provider.GetXamlTypeByType(type);
        }

        public XmlnsDefinition[] GetXmlnsDefinitions() => 
            new XmlnsDefinition[0];

        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0"), DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
            }
        }

        [AsyncStateMachine(typeof(<OnLaunched>d__2))]
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            <OnLaunched>d__2 d__;
            d__.<>4__this = this;
            d__.e = e;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<OnLaunched>d__2>(ref d__);
        }

        [AsyncStateMachine(typeof(<OnSuspending>d__4))]
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            <OnSuspending>d__4 d__;
            d__.e = e;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<OnSuspending>d__4>(ref d__);
        }

        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            Frame frame1 = sender as Frame;
            TransitionCollection transitions = this.transitions;
            if (this.transitions == null)
            {
                TransitionCollection local1 = this.transitions;
                TransitionCollection collection1 = new TransitionCollection();
                collection1.Add(new NavigationThemeTransition());
                transitions = collection1;
            }
            frame1.put_ContentTransitions(transitions);
            Frame local2 = frame1;
            WindowsRuntimeMarshal.RemoveEventHandler<NavigatedEventHandler>(new Action<EventRegistrationToken>(local2, local2.remove_Navigated), new NavigatedEventHandler(this, this.RootFrame_FirstNavigated));
        }

        [CompilerGenerated]
        private struct <OnLaunched>d__2 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public LaunchActivatedEventArgs e;
            private Frame <rootFrame>5__1;
            public App <>4__this;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    if (num != 0)
                    {
                        this.<rootFrame>5__1 = Window.get_Current().get_Content() as Frame;
                        if (this.<rootFrame>5__1 != null)
                        {
                            goto TR_0010;
                        }
                        else
                        {
                            this.<rootFrame>5__1 = new Frame();
                            SuspensionManager.RegisterFrame(this.<rootFrame>5__1, "AppFrame", null);
                            this.<rootFrame>5__1.put_CacheSize(1);
                            this.<rootFrame>5__1.put_Language(WorkoutDataSource.AppCultureInfo.ToString());
                            ApplicationLanguages.put_PrimaryLanguageOverride(this.<rootFrame>5__1.get_Language());
                            if (this.e.get_PreviousExecutionState() != 3)
                            {
                                goto TR_0011;
                            }
                        }
                    }
                    try
                    {
                        TaskAwaiter awaiter;
                        if (num == 0)
                        {
                            awaiter = this.<>u__1;
                            this.<>u__1 = new TaskAwaiter();
                            this.<>1__state = num = -1;
                            goto TR_0013;
                        }
                        else
                        {
                            awaiter = SuspensionManager.RestoreAsync(null).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto TR_0013;
                            }
                            else
                            {
                                this.<>1__state = num = 0;
                                this.<>u__1 = awaiter;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, App.<OnLaunched>d__2>(ref awaiter, ref this);
                            }
                        }
                        return;
                    TR_0013:
                        awaiter.GetResult();
                        awaiter = new TaskAwaiter();
                    }
                    catch (SuspensionManagerException)
                    {
                    }
                    goto TR_0011;
                TR_0010:
                    if (this.<rootFrame>5__1.get_Content() == null)
                    {
                        if (this.<rootFrame>5__1.get_ContentTransitions() != null)
                        {
                            this.<>4__this.transitions = new TransitionCollection();
                            IEnumerator<Transition> enumerator = this.<rootFrame>5__1.get_ContentTransitions().GetEnumerator();
                            try
                            {
                                while (enumerator.MoveNext())
                                {
                                    Transition transition = enumerator.get_Current();
                                    this.<>4__this.transitions.Add(transition);
                                }
                            }
                            finally
                            {
                                if ((num < 0) && (enumerator != null))
                                {
                                    enumerator.Dispose();
                                }
                            }
                        }
                        this.<rootFrame>5__1.put_ContentTransitions(null);
                        Frame frame = this.<rootFrame>5__1;
                        WindowsRuntimeMarshal.AddEventHandler<NavigatedEventHandler>(new Func<NavigatedEventHandler, EventRegistrationToken>(frame, frame.add_Navigated), new Action<EventRegistrationToken>(frame, frame.remove_Navigated), new NavigatedEventHandler(this.<>4__this, this.RootFrame_FirstNavigated));
                        if (!this.<rootFrame>5__1.Navigate(typeof(HubPage), this.e.get_Arguments()))
                        {
                            throw new Exception("Failed to create initial page");
                        }
                    }
                    Window.get_Current().Activate();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                    return;
                TR_0011:
                    Window.get_Current().put_Content(this.<rootFrame>5__1);
                    ApplicationView.GetForCurrentView().put_Title("");
                    goto TR_0010;
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <OnSuspending>d__4 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public SuspendingEventArgs e;
            private SuspendingDeferral <deferral>5__1;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                        goto TR_0004;
                    }
                    else
                    {
                        this.<deferral>5__1 = this.e.get_SuspendingOperation().GetDeferral();
                        awaiter = SuspensionManager.SaveAsync().GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, App.<OnSuspending>d__4>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0004:
                    awaiter.GetResult();
                    awaiter = new TaskAwaiter();
                    this.<deferral>5__1.Complete();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }
    }
}

