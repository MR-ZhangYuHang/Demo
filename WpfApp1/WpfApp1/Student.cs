using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{


    interface ISchoolMember
    {
        int ID { get; set; }
        string Name { get; set; }
        int Age { get; set; }
    }
    class Student : ISchoolMember
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Teacher : ISchoolMember
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
