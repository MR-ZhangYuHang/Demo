using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class OperateScoreRecords
    {
        public OperateScoreRecords()
        {
            OperateErrorRecord = new HashSet<OperateErrorRecord>();
            OperatePicture = new HashSet<OperatePicture>();
            OperateRecord = new HashSet<OperateRecord>();
        }

        public int Id { get; set; }
        public int? UseId { get; set; }
        public double? Score { get; set; }
        public DateTime? StoreTime { get; set; }
        public DateTime? OperateStartTime { get; set; }
        public DateTime? OperateEndTime { get; set; }
        public int? ProcessId { get; set; }

        public Process Process { get; set; }
        public User Use { get; set; }
        public ICollection<OperateErrorRecord> OperateErrorRecord { get; set; }
        public ICollection<OperatePicture> OperatePicture { get; set; }
        public ICollection<OperateRecord> OperateRecord { get; set; }
    }
}
