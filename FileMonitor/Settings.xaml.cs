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
using System.Windows.Shapes;

namespace FileMonitor
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            pathnm.Text = MainWindow.path;
            timenm.Text = MainWindow.time.ToString();
        }

        private void savebtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.path = pathnm.Text.ToString();
            MainWindow.time = Convert.ToInt32(timenm.Text.ToString());
            this.Close();
        }
    }
}
