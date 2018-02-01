using System;
using System.Collections.Generic;

namespace EFcoreDemo.Models2
{
    public partial class QuestionLibraryAnswer
    {
        public int QuestionId { get; set; }
        public string ItemIndex { get; set; }
        public string ItemContent { get; set; }
        public bool ItemsIsAnwer { get; set; }

        public QuestionLibrary Question { get; set; }
    }
}
