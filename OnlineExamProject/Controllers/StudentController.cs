using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineExamProject.Models;
using System.Linq;

namespace OnlineExamProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly ExamDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public StudentController(ExamDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> StartExam(int currentQuestionIndex = 0)
        {
            var questions = await _context.Questions.ToListAsync();
            var viewModel = new ExamViewModel { Questions = questions, CurrentQuestionIndex = currentQuestionIndex };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SubmitAnswer(int questionId, int selectedOption)
        {
            // Get the UserLoginId (You need to implement your authentication logic)
            int userLoginId = (int)_contextAccessor.HttpContext.Session.GetInt32("UserLoginId");
            var userResponses = _context.UserResponses.ToList();

            var containsId = userResponses.FindAll(response => response.UserLoginId == userLoginId);

            if (containsId.Count > 2)
            {
                var question = await _context.Questions.FindAsync(questionId);
                selectedOption++;
                bool isCorrect = question.CorrectOption == selectedOption;
                //stored procedure 
                var parameter = new[]
                {
                    new SqlParameter("@QuestionId",questionId),
                    new SqlParameter("@SelectOption",selectedOption),
                    new SqlParameter("@LoginId",userLoginId)
                };

                _context.Database.ExecuteSqlRaw("EXEC Sp_UpdateOptions @QuestionId,@SelectOption,@LoginId", parameter);



                var nextQuestionIndex = question.QuestionId + 1;
                return RedirectToAction("StartExam", new { currentQuestionIndex = question.QuestionId });//
            }

            else
            {
                var question = await _context.Questions.FindAsync(questionId);
                selectedOption++;
                bool isCorrect = question.CorrectOption == selectedOption;



                // Save the user response to the database
                var userResponse = new UserResponse
                {
                    QuestionId = questionId,
                    SelectedOptionId = selectedOption,
                    UserLoginId = userLoginId
                };

                _context.UserResponses.Add(userResponse);
                await _context.SaveChangesAsync();

                var nextQuestionIndex = question.QuestionId + 1;
                return RedirectToAction("StartExam", new { currentQuestionIndex = question.QuestionId });//
            }

        }


        public IActionResult Results()
        {
            // Retrieve user's answers from the database and calculate results
            //Populate the result in a ViewModel
            var resultViewModel = CalculateResults();
            ViewBag.count = resultViewModel;
            int userLoginId = (int)_contextAccessor.HttpContext.Session.GetInt32("UserLoginId");
            var exam = new ExamResult
            {
                UserLoginId = userLoginId,
                Score = resultViewModel,
                ExamDate = DateTime.Now
            };
            _context.ExamResults.Add(exam);
            _context.SaveChanges();
            return View(resultViewModel);

        }
        private int CalculateResults()
        {
            /// Implement logic to calculate user's results based on stored answers
            /// Return  //a ResultViewModel with the results
            int count = 0;
            var Answer = _context.Questions.Select(s => s.CorrectOption).ToList();
            var submitedAnswers = _context.UserResponses.Select(s => s.SelectedOptionId).ToList();

            for (int i = 0; i < Answer.Count; i++)
            {
                for (int j = i; j <= i; j++)
                {
                    if (Answer[i] == submitedAnswers[j])
                    {
                        count++;
                    }
                }
            }

            return count;


        }
    }
}
