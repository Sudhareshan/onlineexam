namespace OnlineExamProject.Models
{
    public class ExamResult
    {
        public int ExamResultId { get; set; }
        public int UserLoginId { get; set; } // Customize this based on your authentication setup
        public int Score { get; set; }
        public DateTime ExamDate { get; set; }
        public UserLogin UserLogin { get; set; }
    }
}
  