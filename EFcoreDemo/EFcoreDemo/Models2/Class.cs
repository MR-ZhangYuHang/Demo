using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int? CollegeId { get; set; }
        public bool Hidden { get; set; }

        public College College { get; set; }
    }
}
