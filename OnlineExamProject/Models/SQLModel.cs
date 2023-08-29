namespace OnlineExamProject.Models
{
    public class SQLModel
    {
        public int SQLModelId { get; set; }
        public string QuestionText { get; set; }
        public string OptionText1 { get; set; }
        public string OptionText2 { get; set; }
        public string OptionText3 { get; set; }
        public string OptionText4 { get; set; }
        public int CorrectOption { get; set; }
    }
}
