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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double screenWidth = SystemParameters.PrimaryScreenWidth ;
        double screenHeight = SystemParameters.PrimaryScreenHeight - 100;

        public MainWindow()
        {
            InitializeComponent();
            MainPage mainPage = new MainPage();
            RegPage regPage = new RegPage();

            // Set up data binding for Width
            SetBinding(WidthProperty, new System.Windows.Data.Binding
            {
                Source = screenWidth,
                Mode = System.Windows.Data.BindingMode.OneWay
            });

            // Set up data binding for Height
            SetBinding(HeightProperty, new System.Windows.Data.Binding
            {
                Source = screenHeight,
                Mode = System.Windows.Data.BindingMode.OneWay
            });
            frame.NavigationService.Navigate(new Uri("mainPage.xaml", UriKind.Relative));
        }

       
    }
}
