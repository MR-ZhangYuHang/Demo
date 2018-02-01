using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class OperateRecord
    {
        public int Id { get; set; }
        public DateTime? Operatetime { get; set; }
        public string Discribe { get; set; }
        public int? OperateScoreId { get; set; }

        public OperateScoreRecords OperateScore { get; set; }
    }
}
