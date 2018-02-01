using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class OperatePicture
    {
        public int Id { get; set; }
        public int OperateScoreId { get; set; }
        public string Picture { get; set; }

        public OperateScoreRecords OperateScore { get; set; }
    }
}
