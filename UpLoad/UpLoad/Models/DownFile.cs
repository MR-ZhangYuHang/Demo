using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpLoad.Models
{
    public class DownFile
    {
        public int id { get; set; }
        public string path { get; set; }
        public string name { get; set; }
        public string room { get; set; }
        public DateTime updatetime { get; set; }
        public string source { get; set; }
        public string htmlpath { get; set; }

    }
}