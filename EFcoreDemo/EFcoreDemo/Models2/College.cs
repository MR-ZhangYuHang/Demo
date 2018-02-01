using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class College
    {
        public College()
        {
            Class = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string CollegeName { get; set; }
        public bool Hidden { get; set; }

        public ICollection<Class> Class { get; set; }
    }
}
