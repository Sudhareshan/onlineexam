namespace OnlineExamProject.Models
{
    public class UserResponse
    {
        public int UserResponseId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedOptionId { get; set; }
        public int UserLoginId { get; set; }
        public UserLogin UserLogin { get; set; }    
    }
}
