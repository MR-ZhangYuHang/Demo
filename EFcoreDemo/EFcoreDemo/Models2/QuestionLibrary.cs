using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class QuestionLibrary
    {
        public QuestionLibrary()
        {
            QuestionLibraryAnswer = new HashSet<QuestionLibraryAnswer>();
            TestPaperRecordsQustion = new HashSet<TestPaperRecordsQustion>();
        }

        public int Id { get; set; }
        public int QuestionTypeId { get; set; }
        public string QuestionContent { get; set; }

        public QuestionType QuestionType { get; set; }
        public ICollection<QuestionLibraryAnswer> QuestionLibraryAnswer { get; set; }
        public ICollection<TestPaperRecordsQustion> TestPaperRecordsQustion { get; set; }
    }
}
