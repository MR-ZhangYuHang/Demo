using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class TestPaperRule
    {
        public int Id { get; set; }
        public int TotalQuestionNumber { get; set; }
        public int TestTime { get; set; }
        public double UniqueChoicePercent { get; set; }
        public double UniqueChoicePerScore { get; set; }
        public double MultiChoicePercent { get; set; }
        public double MultiChoicePerScore { get; set; }
        public double JudgePercent { get; set; }
        public double JudgePerScore { get; set; }
        public double? IsPassScore { get; set; }
        public double? TheoryPercent { get; set; }
        public DateTime SetTime { get; set; }
    }
}
