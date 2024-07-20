using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor.Models
{
    public class Data
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        public Data()
        {

        }
        public Data(string name, string type, DateTime date)
        {
            Name = name;
            Type = type;
            Date = date;
        }
    }
}
