using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class TestPaperRecords
    {
        public TestPaperRecords()
        {
            TestPaperRecordsQustion = new HashSet<TestPaperRecordsQustion>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public double? Score { get; set; }
        public bool? IsPrass { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }

        public User User { get; set; }
        public ICollection<TestPaperRecordsQustion> TestPaperRecordsQustion { get; set; }
    }
}
