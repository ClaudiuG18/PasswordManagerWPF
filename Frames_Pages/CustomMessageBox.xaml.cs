﻿using System;
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
using System.Windows.Shapes;

namespace Frames_Pages
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
      
        public CustomMessageBox(string var)
        {
            InitializeComponent();
          
            this.CustomText.Text = var;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
