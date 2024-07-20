using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Serialization;
using CsvHelper;

namespace FileMonitor
{
    public class SpecialWriter
    {

        public void XmlWriter(List<MainData> listdatas, string name)
        {
            try
            {
                List<MainData> datas = listdatas;
                XmlSerializer serializer = new XmlSerializer(typeof(List<MainData>));
                var file = File.Create(MainWindow.path + @"\" + $"{name}.xml");
                serializer.Serialize(file, datas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task SpecialCsvWriter(List<MainData> datas, string name)
        {
            try
            {
                using (var writer = new StreamWriter(MainWindow.path + @"\" + $"{name}.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    await csv.WriteRecordsAsync(datas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public async Task TxtWriter(string data, string name)
        {

            try
            {
                using (var writer = new StreamWriter(MainWindow.path + @"\" + $"{name}.csv"))
                {
                    await writer.WriteAsync(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }



    public class MainData
    {
     
        public string value_date { get; set; }

        public string open { get; set; }

        public string high { get; set; }

        public string low { get; set; }

        public string close { get; set; }

        public string volume { get; set; }

        public MainData()
        {

        }
        public MainData(string value, string op, string h, string l, string c, string v)
        {
            value_date = value;
            open = op;
            high = h;
            low = l;
            close = c;
            volume = v;
        }


    }


}
