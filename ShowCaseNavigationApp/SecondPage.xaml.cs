using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ShowCaseNavigationApp
{
    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Frame.CanGoForward)
            {
                foreach (var forwardstack in Frame.ForwardStack)
                {
                    Frame.ForwardStack.Remove(forwardstack);
                }
            }
            MyWebView.Navigate(new Uri("ms-appx-web:///WebViewElements/index.html"));

            MyWebView.ScriptNotify += Handle_ScriptNotify;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        async private void Handle_ScriptNotify(object sender, NotifyEventArgs e)
        {
            var arr = e.Value.Split('/');
            if (e.Value.Contains("Vibrate"))
            {
                var messageDialog = new MessageDialog("*Vibrate* for " + arr[1] + " ms");
                messageDialog.Commands.Add(new UICommand("Close", null));
                await messageDialog.ShowAsync();
            }
            else if (e.Value.Contains("ScanBarcode"))
            {
                Frame.Navigate(typeof(ThirdPage));
            }
            else if (e.Value.Contains("GoBack"))
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                }
            }
        }
    }
}
