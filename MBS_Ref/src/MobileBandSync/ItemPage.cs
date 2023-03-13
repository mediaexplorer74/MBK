namespace MobileBandSync
{
    using MobileBandSync.Common;
    using MobileBandSync.Data;
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Markup;
    using Windows.UI.Xaml.Navigation;

    public sealed class ItemPage : Page, IComponentConnector
    {
        private readonly MobileBandSync.Common.NavigationHelper navigationHelper;
        private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private Page pageRoot;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private Grid LayoutRoot;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private Grid ContentRoot;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private bool _contentLoaded;

        public ItemPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new MobileBandSync.Common.NavigationHelper(this);
            this.navigationHelper.LoadState += new LoadStateEventHandler(this.NavigationHelper_LoadState);
            this.navigationHelper.SaveState += new SaveStateEventHandler(this.NavigationHelper_SaveState);
        }

        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0"), DebuggerNonUserCode]
        public void Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0"), DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Application.LoadComponent(this, new Uri("ms-appx:///ItemPage.xaml"), 0);
                this.pageRoot = (Page) base.FindName("pageRoot");
                this.LayoutRoot = (Grid) base.FindName("LayoutRoot");
                this.ContentRoot = (Grid) base.FindName("ContentRoot");
            }
        }

        [AsyncStateMachine(typeof(<NavigationHelper_LoadState>d__7))]
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            <NavigationHelper_LoadState>d__7 d__;
            d__.<>4__this = this;
            d__.e = e;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<NavigationHelper_LoadState>d__7>(ref d__);
        }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        public MobileBandSync.Common.NavigationHelper NavigationHelper =>
            this.navigationHelper;

        public ObservableDictionary DefaultViewModel =>
            this.defaultViewModel;

        [CompilerGenerated]
        private struct <NavigationHelper_LoadState>d__7 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public LoadStateEventArgs e;
            public ItemPage <>4__this;
            private TaskAwaiter<TrackItem> <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<TrackItem> awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<TrackItem>();
                        this.<>1__state = num = -1;
                        goto TR_0004;
                    }
                    else
                    {
                        awaiter = WorkoutDataSource.GetItemAsync((string) this.e.NavigationParameter).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<TrackItem>, ItemPage.<NavigationHelper_LoadState>d__7>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0004:
                    awaiter = new TaskAwaiter<TrackItem>();
                    TrackItem result = awaiter.GetResult();
                    this.<>4__this.DefaultViewModel["Item"] = result;
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

