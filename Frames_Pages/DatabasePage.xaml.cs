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

    public partial class Page2 : Page
    {

        string tableName;
        public Page2(string tablename)
        {
            InitializeComponent();
            string table = tablename;
            dataGrid.ItemsSource = DatabaseHelper.GetUserData(table);
            tableName = table;   
        }

        private void AddNewRow(string username, string password, string app)
        {
            // Add a new person to the data source
            var newData = new UserData { Username = username, Password = password, Application = app };
            DatabaseHelper.InsertData(newData, tableName);

            dataGrid.ItemsSource = DatabaseHelper.GetUserData(tableName);
            // Refresh the DataGrid to reflect the changes
            dataGrid.Items.Refresh();
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.Items.Count > 0)
            {
                var firstItem = dataGrid.Items[0] as UserData;

                if (firstItem != null)
                {
                    // Access data from the first row
                    string username = firstItem.Username;
                    string password = firstItem.Password;
                    string app = firstItem.Application;

                    // Process the data as needed
                }
            }
        }

        private void LogoutBtn(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
            
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(AddUsername.Text) && string.IsNullOrEmpty(AddPassword.Text) && string.IsNullOrEmpty(AddApp.Text))
                || (AddUsername.Text == "Add a username" && AddPassword.Text == "Add a password" && AddApp.Text == "Add a application"))
            {
                CustomMessageBox a = new CustomMessageBox("Add a username a password and a application !");  
                a.ShowDialog();
            }
            else
            {
                AddNewRow(AddUsername.Text, AddPassword.Text, AddApp.Text);
                AddUsername.Clear(); AddPassword.Clear(); AddApp.Clear();
            }
            
        }


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "Add a username")
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
                AddUsername.Text = "Add a username";
                AddUsername.Foreground = Brushes.Black; // Set back to the placeholder color when not focused
            }
        }

        private void TextBox_GotFocusPass(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "Add a password")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black; // Set to the actual text color when focused
               
            }
        }
        private void TextBox_LostFocusPass(object sender, RoutedEventArgs e)
        {
            TextBox textBox2 = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                AddPassword.Text = "Add a password";
                AddPassword.Foreground = Brushes.Black; // Set back to the placeholder color when not focused
            }
        }

        private void TextBox_GotFocusApp(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text == "Add a application")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black; // Set to the actual text color when focused

            }
        }
        private void TextBox_LostFocusApp(object sender, RoutedEventArgs e)
        {
            TextBox textBox2 = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                AddApp.Text = "Add a application";
                AddApp.Foreground = Brushes.Black; // Set back to the placeholder color when not focused
            }
        }
    }
}
