using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class OperateErrorRecord
    {
        public int Id { get; set; }
        public string Error { get; set; }
        public double? Score { get; set; }
        public int? OperateScoreId { get; set; }

        public OperateScoreRecords OperateScore { get; set; }
    }
}
