using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frames_Pages
{
    /// <summary>
    /// Interaction logic for RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {

        public RegPage()
        {
            InitializeComponent();
            DatabaseHelper.CreateUserRegTables();
        }

        //Placeholder for the Username Textbox
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "Username")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black; // Set to the actual text color when focused

            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {

                textBox.Text = "Username";
                textBox.Foreground = Brushes.Gray; // Set to the actual text color when focused

            }
        }

        //Placeholder for the Password Textbox
        private void PassBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "Password")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black; // Set to the actual text color when focused

            }
        }
        private void PassBox_LostFocus(object sender, RoutedEventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {

                textBox.Text = "Password";
                textBox.Foreground = Brushes.Gray; // Set to the actual text color when focused

            }
        }

      //Register Button
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            List<RegUser> regUserList = DatabaseHelper.GetRegUsers();

            if (regUserList.Count == 0 && string.IsNullOrWhiteSpace(usernameTxtBox.Text) || usernameTxtBox.Text == "Username")
            {
                var messageBox = new CustomMessageBox("No user, please register a user!");
                messageBox.ShowDialog();
            }
            else if (!(string.IsNullOrWhiteSpace(usernameTxtBox.Text)) && !(string.IsNullOrWhiteSpace(passwordTxtBox.Text)))
            {
                bool userExists = false;
                foreach (RegUser regUser in regUserList)
                {
                    if (regUser.Username == usernameTxtBox.Text)
                    {
                        var messageBox1 = new CustomMessageBox("User already exits!");
                        messageBox1.ShowDialog();
                        userExists = true;
                        break;
                    }
                }
                if (!userExists)
                {
                    DatabaseHelper.InsertUser(new RegUser { Username = usernameTxtBox.Text, Password = passwordTxtBox.Text });
                    var messageBox = new CustomMessageBox("User registered");
                    messageBox.ShowDialog();
                }
               
            }
            else if (string.IsNullOrWhiteSpace(usernameTxtBox.Text) || string.IsNullOrWhiteSpace(passwordTxtBox.Text))
            {
                var messageBox = new CustomMessageBox("Please insert a username and a password!");
                messageBox.ShowDialog();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }
    }
}
