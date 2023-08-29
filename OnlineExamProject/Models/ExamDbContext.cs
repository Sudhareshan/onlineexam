using Microsoft.EntityFrameworkCore;

namespace OnlineExamProject.Models
{
    public class ExamDbContext:DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options):base((options))
        {
            
        }



        public DbSet<Question> Questions { get; set; }
        public DbSet<HtmlModel> HtmlQuestions { get; set; }
        public DbSet<SQLModel> SQLQuestions { get; set; }

       // public DbSet<Option> Options { get; set; }
        public DbSet<UserResponse> UserResponses { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
    }
}
