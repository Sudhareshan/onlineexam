namespace OnlineExamProject.Models
{
    public class ExamViewModel
    {
        public List<Question> Questions { get; set; }
        public int CurrentQuestionIndex { get; set; } // Add this property
        public int Answer { get; set; } // Add this property
    }
}
