using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace FileMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Data> checkuplist;
        public static string path;
        public static int time;
        string checkpath;
        public MainWindow()
        {
            InitializeComponent();
            checkuplist = new List<Data>();
            checkpath = "";
            path = @"C:\Users\Cavid\Desktop\ForTest";
            time = 5000;
            AsyncCheck();
           
        }

        public void GetFiles()
        {
            try
            {

                if (checkpath != path)
                {
                    checkpath = path;
                    checkuplist.Clear();
                    DataLists.Items.Clear();
                }
                string[] files = Directory.GetFiles(path);


                string name = "";
                StringBuilder sb = new StringBuilder();
                foreach (string file in files)
                {

                    sb.Append(file);
                    sb.Remove(0, path.Length + 1);
                    var strings = sb.ToString().Split(".");

                    foreach (string s in strings)
                    {
                        if (s != strings[strings.Length - 1])
                            name += s;
                    }

                    if (checkuplist.FirstOrDefault(o => o.Name == name && o.Type == strings[strings.Length - 1]) == null)
                    {
                        checkuplist.Add(new Data(name, strings[strings.Length - 1], File.GetCreationTime(path + @"\" + sb.ToString())));
                        DataLists.Items.Add(new Data(name, strings[strings.Length - 1], File.GetCreationTime(path + @"\" + sb.ToString())));
                    }

                    name = "";
                    sb.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public async void AsyncCheck()
        {
            for (; ; )
            {
                GetFiles();
                await Task.Delay(time);
            }
        }

        private void Uploadbtn_Click(object sender, RoutedEventArgs e)
        {
            Choose choose = new Choose();
            choose.ShowDialog();
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Settings setting = new();
            setting.ShowDialog();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          
        }
    }

    public class Data
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        
        public Data()
        {

        }
        public Data( string name, string type, DateTime date)
        {
            Name = name;
            Type = type;
            Date = date;
        }
    }


}