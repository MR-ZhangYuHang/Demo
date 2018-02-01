using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class Process
    {
        public Process()
        {
            OperateScoreRecords = new HashSet<OperateScoreRecords>();
        }

        public int Id { get; set; }
        public string ProcessName { get; set; }

        public ICollection<OperateScoreRecords> OperateScoreRecords { get; set; }
    }
}
