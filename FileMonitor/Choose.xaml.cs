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
    /// Interaction logic for Choose.xaml
    /// </summary>
    public partial class Choose : Window
    {
       
        public Choose()
        {
            InitializeComponent();
        }
        private void openwindow()
        {
            InputDataWindow input = new InputDataWindow();
            input.ShowDialog();
        }

        private void xmlTypenm_Click(object sender, RoutedEventArgs e)
        {
            InputDataWindow.type = "xml";
            this.Close();
            openwindow();
        }

        private void csvTypenm_Click(object sender, RoutedEventArgs e)
        {
            InputDataWindow.type = "csv";
            this.Close();
            openwindow();
        }

        private void txtTypenm_Click(object sender, RoutedEventArgs e)
        {
            InputDataWindow.type = "txt";
            this.Close();
            openwindow();
        }
    }
}
