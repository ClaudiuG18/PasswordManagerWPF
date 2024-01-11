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
using System.Xml.Linq;


namespace Frames_Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    /// 

    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            
        }



        //Placeholder for Username Textbox
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            
            if (textBox.Text == "Username" )
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black; // Set to the actual text color when focused
                passwordBox.Visibility = Visibility.Collapsed;
                placeholderTextBox.Visibility = Visibility.Visible;
            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Username";
                textBox.Foreground = Brushes.Black; // Set back to the placeholder color when not focused
            }
        }

        //Placeholder for Password Textbox
        private void PlaceholderTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholderTextBox.Visibility = Visibility.Collapsed;
            passwordBox.Visibility = Visibility.Visible;
            passwordBox.Focus();
        }
        private void  PlaceholderPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
        
            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                
                placeholderTextBox.Visibility = Visibility.Visible;
                passwordBox.Visibility = Visibility.Collapsed;

            }
              
            
        }

        //Navigate to Register page
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("RegPage.xaml", UriKind.Relative));
        }

        //Login button logic
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            List<RegUser> regUserList = DatabaseHelper.GetRegUsers(); // Get the data from the database
            string tableName = "";
            bool flag = false;
          
            if (regUserList.Count == 0)
            {
                var messageBox = new CustomMessageBox("No registered user!");
                messageBox.ShowDialog();
            }
            else
            {
                foreach (RegUser regUser in regUserList)
                { 
                    if (usernameBox.Text == regUser.Username && passwordBox.Password == regUser.Password)
                    {

                        flag = true;
                        DatabaseHelper.CreateDataTables(regUser.Username);
                        tableName = regUser.Username;
                    }
                 
                    
                }

            }
            if (flag)
            {
                NavigationService?.Navigate(new Page2 (tableName));
            }
            else if (!flag)
            {
                var messageBox = new CustomMessageBox("Wrong Username/Password!");
                messageBox.ShowDialog();
            }

        }
    }
}
