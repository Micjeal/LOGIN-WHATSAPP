using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class ACCOUNTFORM : Page
    {

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
        public ACCOUNTFORM()
        {
            this.InitializeComponent();
        }

        private void LoginLink_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text) ||
              string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) ||
              string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
              string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                showMessage("FILL","All fields are required");
                return;
            }

            // Validate email format
            if (EmailTextBox.Text=="")
            {
                showMessage("EMAIL", "Please enter a valid email address");
                return;
            }

            // Validate phone number (basic validation)
            if (PhoneNumberTextBox.Text=="")
            {
                showMessage("NUMBER", "Please enter a valid phone number");
                return;
            }

            // Validate password strength
            if (PasswordBox.Password.Length < 5)
            {
                showMessage("PASSWORD", "Password must be at least 5 characters long");
                return;
            }
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["FullName"] = FullNameTextBox.Text;
            localSettings.Values["Email"] = EmailTextBox.Text;
            localSettings.Values["PhoneNumber"] = PhoneNumberTextBox.Text;
            localSettings.Values["Password"] = PasswordBox.Password;

            showMessage("SIGN UP", "ACCOUNT CREATED");
            Frame.Navigate(typeof(MainPage));
        }
    }
}
