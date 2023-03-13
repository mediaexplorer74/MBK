namespace MobileBandSync.Common
{
    using System;
    using System.Runtime.CompilerServices;
    using Windows.Foundation.Metadata;
    using Windows.Phone.UI.Input;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    [WebHostHidden]
    public class NavigationHelper : DependencyObject
    {
        private RelayCommand _goBackCommand;
        private RelayCommand _goForwardCommand;
        private string _pageKey;

        public event LoadStateEventHandler LoadState;

        public event SaveStateEventHandler SaveState;

        public NavigationHelper(Windows.UI.Xaml.Controls.Page page);
        public virtual bool CanGoBack();
        public virtual bool CanGoForward();
        public virtual void GoBack();
        public virtual void GoForward();
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e);
        public void OnNavigatedFrom(NavigationEventArgs e);
        public void OnNavigatedTo(NavigationEventArgs e);

        private Windows.UI.Xaml.Controls.Page Page { get; set; }

        private Windows.UI.Xaml.Controls.Frame Frame { get; }

        public RelayCommand GoBackCommand { get; set; }

        public RelayCommand GoForwardCommand { get; }
    }
}

