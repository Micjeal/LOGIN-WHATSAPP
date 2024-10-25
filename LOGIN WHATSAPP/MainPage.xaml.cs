using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LOGIN_WHATSAPP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
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

        private List<Contact> allContacts = new List<Contact>();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ForgotPasswordLink_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FORGOTPAGE));
        }

        private void LoginButton_ClickS(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

            string storedEmail = localSettings.Values["Email"] as string;
            string storedPassword = localSettings.Values["Password"] as string;

            if (EmailTextBox.Text == "" && PasswordBox.Password == "")
            {

                string name = EmailTextBox.Name;
                showMessage("LOGIN TEXT", "FILL ALL THE BLANK AREAS");
                return;
            }
            else if (EmailTextBox.Text == "")
            {
                showMessage("LOGIN TEXT", "FILL ALL THE BLANK AREAS");
                return;
            }
            else if (PasswordBox.Password == "")
            {
                showMessage("LOGIN PASSWORD", " No password");
                return;
            }
            else if (EmailTextBox.Text == storedEmail && PasswordBox.Password == storedPassword)

            {
                Frame.Navigate(typeof(HOME));
                showMessage("WELCOME", "WELCOME");
                return;
            }
            else
            {
                showMessage("WELCOME", "LOGIN UNSUCCESSFULL INVALID PASSWORD");
            }
        }

        private void SIGN_UP(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ACCOUNTFORM));
        }
    }
}
