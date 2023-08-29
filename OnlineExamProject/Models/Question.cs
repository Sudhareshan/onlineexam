using System.Diagnostics;

namespace OnlineExamProject.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string OptionText1 { get; set; }
        public string OptionText2 { get; set; }
        public string OptionText3 { get; set; }
        public string OptionText4 { get; set; }
        public int CorrectOption { get; set; } // Store the correct option index (1-4)
    }
}
