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
        

        public Page2(string tablename)
        {
            InitializeComponent();
            string table = tablename;
            dataGrid.ItemsSource = DatabaseHelper.GetUserData(table);
        }

      
        private void LogoutBtn(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
           
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
    }
}
