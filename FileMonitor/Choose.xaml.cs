﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace FileMonitor
{
    /// <summary>
    /// Interaction logic for Choose.xaml
    /// </summary>
    public partial class Choose : Window
    {
       
        public Choose()
        {
            InitializeComponent();
        }

        private void Selectbtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", MainWindow.path);
        }
    }
}
