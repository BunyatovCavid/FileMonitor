
using FileMonitor.Models;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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

    public partial class MainWindow : Window
    {
        List<Data> checkuplist;
        public static string path;
        public static int time;
        string checkpath;

        SpecialWriter specialwriter;

        public MainWindow()
        {
            InitializeComponent();
            checkpath = "";
            checkuplist = new();
            specialwriter = new();
            path = @"C:\Users\Cavid\Desktop\ForTest";
            time = 5000;
            AsyncCheck();

        }

        public async void CheckSyncrone()
        {
            try
            {
                string createdpath = @"C:\Users\Cavid\Desktop\FileMonitorFiles";

                List<string> baseinputfiles = Directory.GetFiles(path).ToList();
                List<string> basecreatedfiles = Directory.GetFiles(createdpath).ToList();

                StringBuilder ip = new StringBuilder();
                StringBuilder cf = new StringBuilder();

                List<string> inputfiles = new();
                List<string> createdfiles = new();

                for (int i = 0; i < baseinputfiles.Count; i++)
                {
                    if (i < basecreatedfiles.Count)
                    {
                        cf.Append(basecreatedfiles[i]);
                        cf.Remove(0, createdpath.Length + 1);
                        createdfiles.Add(cf.ToString());
                    }
                    ip.Append(baseinputfiles[i]);
                    ip.Remove(0, MainWindow.path.Length + 1);
                    inputfiles.Add(ip.ToString());

                    cf.Clear();
                    ip.Clear();
                }

                foreach (var file in inputfiles)
                {


                    if (!createdfiles.Contains(file) && (file.EndsWith(".txt") || file.EndsWith(".csv") || file.EndsWith(".xml")))
                    {
                        var reader = new StreamReader(MainWindow.path + @"\" + file);
                        var line = reader.ReadLine();

                        StringBuilder data = new StringBuilder();


                        while (line != null)
                        {
                            data.Append(line + "\n");
                            line = reader.ReadLine();
                        }

                        if (file.EndsWith(".txt"))
                        {
                            await specialwriter.TxtWriter(data.ToString(), file.Remove(file.Length - 4, 4));
                        }
                        if (file.EndsWith(".csv"))
                        {
                           await specialwriter.SpecialCsvWriter(data.ToString(), file.Remove(file.Length - 4, 4));
                        }
                        if (file.EndsWith(".xml"))
                        {
                            specialwriter.XmlWriter(data.ToString(), file.Remove(file.Length - 4, 4));
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                CheckSyncrone();
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

            StringBuilder response = new StringBuilder();
            var data = (Data)DataLists.SelectedItem;
            var reader = new StreamReader(MainWindow.path + @"\" + data.Name + "." + data.Type);

            var line = reader.ReadLine();

            while (line != null)
            {
                response.Append(line + "\n");
                line = reader.ReadLine();
            }

            ResponseWindow responseWindow = new ResponseWindow(response.ToString());
            responseWindow.ShowDialog();

        }
    }
}