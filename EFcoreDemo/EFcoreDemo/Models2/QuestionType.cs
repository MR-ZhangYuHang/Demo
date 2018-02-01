using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            QuestionLibrary = new HashSet<QuestionLibrary>();
        }

        public int Id { get; set; }
        public string QuestionType1 { get; set; }

        public ICollection<QuestionLibrary> QuestionLibrary { get; set; }
    }
}
