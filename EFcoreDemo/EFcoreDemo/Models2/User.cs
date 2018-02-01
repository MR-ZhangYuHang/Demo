using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class User
    {
        public User()
        {
            OperateScoreRecords = new HashSet<OperateScoreRecords>();
            TestPaperRecords = new HashSet<TestPaperRecords>();
        }

        public int Id { get; set; }
        public string UserNo { get; set; }
        public string PassWord { get; set; }
        public string RealName { get; set; }
        public int RoleId { get; set; }
        public int? ClassId { get; set; }
        public int? PiCi { get; set; }
        public bool Hidden { get; set; }
        public int? TheoryNum { get; set; }
        public bool? IsPass { get; set; }

        public ICollection<OperateScoreRecords> OperateScoreRecords { get; set; }
        public ICollection<TestPaperRecords> TestPaperRecords { get; set; }
    }
}
