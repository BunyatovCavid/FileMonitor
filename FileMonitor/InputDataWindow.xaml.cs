using System;
using System.Collections.Generic;
using System.IO;
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
using static FileMonitor.SpecialWriter;

namespace FileMonitor
{
    /// <summary>
    /// Interaction logic for InputDataWindow.xaml
    /// </summary>
    public partial class InputDataWindow : Window
    {
        SpecialWriter writer;
        public static string type;
        public InputDataWindow()
        {
            InitializeComponent();
            writer = new SpecialWriter();

        }

        private async void inputsave_Click(object sender, RoutedEventArgs e)
        {
            List<MainData> datas;
            var data = inputnm.Text;
            var name = filenameinput.Text;
            switch (type)
            {
                case "xml":
                    datas = ReadInput("xml");
                    writer.XmlWriter(datas, name);
                    break;

                case "csv":
                    datas = ReadInput("csv");
                    await writer.SpecialCsvWriter(datas, name);
                    break;

                case "txt":
                    await writer.TxtWriter(data, name);
                    break;

                default:
                    break;
            }
            this.Close();

        }

  
        private void TestRead()
        {
            var filesystemwatcher = new FileSystemWatcher()
            {
                Filter = "*.txt",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.Attributes , 
                EnableRaisingEvents = true
            };

        }


        private List<MainData> ReadInput(string type)
        {
            try
            {
                List<MainData> datas = new();

                switch (type)
                {
                    case "xml":
                        char symbol = '"';
                        for (int i = 0; i < inputnm.LineCount; i++)
                        {
                            var data = inputnm.GetLineText(i);
                            var maindata = data.Split(symbol);
                            datas.Add(new(maindata[1].ToString(), maindata[3].ToString(), maindata[5].ToString(), maindata[7].ToString(), maindata[9].ToString()
                                , maindata[11].ToString()));
                        }
                        break;
                    case "csv":

                        for (int i = 0; i < inputnm.LineCount; i++)
                        {
                            var data = inputnm.GetLineText(i).Split(",");
                            datas.Add(new(data[0], data[1], data[2], data[3], data[4], data[5]));
                        }
                        break;
                }

                return datas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
