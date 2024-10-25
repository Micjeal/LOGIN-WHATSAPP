using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LOGIN_WHATSAPP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FORGOTPAGE : Page
    {
        private DispatcherTimer timer;
        private int cooldown = 30;

        public async void showMessage(string title, string message)
        {
            var dialog = new ContentDialog()
            {
                Title = title,//this helps us to set a diffenert title on every popup dialog message.
                Content = message,
                CloseButtonText = "OKAY",

            };
            await dialog.ShowAsync();
        }
        public FORGOTPAGE()
        {
            this.InitializeComponent();
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
            cooldown--;
            if (cooldown == 0)
            {
                SendCodeButton.IsEnabled = true;
                SendCodeButton.Content = "Send Recovery Code";
                timer.Stop();
            }
            else
            {
                SendCodeButton.Content = $"Wait {cooldown} seconds...";
            }
        }

        private void SENDCODE(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                showMessage("Error", "Please enter your email.");
                return;
            }

            var random = new Random();
            var recoveryCode = random.Next(100000, 999999).ToString();
            showMessage("Recovery Code", $"Your recovery code is: {recoveryCode}");

            SendCodeButton.IsEnabled = false;
            cooldown = 30;
            timer.Start();

        }

        private void back_to_login(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
