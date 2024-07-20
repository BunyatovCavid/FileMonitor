using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor.Models
{
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
