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

using FileMonitor.Models;


namespace FileMonitor
{
    public class SpecialWriter
    {

        static string directorypath;
        static SpecialWriter()
        {
            directorypath = @"C:\Users\Cavid\Desktop\FileMonitorFiles";
            Directory.CreateDirectory(directorypath);
        }


        public void XmlWriter(string datas, string name)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(string));
                var file = File.Create(directorypath + @"\" + $"{name}.xml");

                serializer.Serialize(file, datas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public async Task SpecialCsvWriter(string datas, string name)
        {
            try
            {
                using (var writer = new StreamWriter(directorypath + @"\" + $"{name}.csv"))
                {

                }
                //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                //{
                //    await csv.WriteRecordsAsync(datas);
                //}
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

                using (var writer = new StreamWriter(directorypath + @"\" + $"{name}.txt"))
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

}
