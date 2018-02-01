using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class TestPaperRecordsQustion
    {
        public int Id { get; set; }
        public int QuestionLibraryId { get; set; }
        public int? Score { get; set; }
        public string Answer { get; set; }
        public string MyAnswer { get; set; }
        public int TestPaperRecordsId { get; set; }

        public QuestionLibrary QuestionLibrary { get; set; }
        public TestPaperRecords TestPaperRecords { get; set; }
    }
}
