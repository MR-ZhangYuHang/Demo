using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class CheckFileInfo
    {
        public string BaseFileName { get; set; }
        public string OwerId { get; set; }
        public long Size { get; set; }
        public string SHA256 { get; set; }
        public string Version { get; set; }

    }
}