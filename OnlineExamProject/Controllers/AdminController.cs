using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Models;

namespace OnlineExamProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly ExamDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public AdminController(ExamDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminPage(Question qm)
        {
            _context.Questions.Add(qm);
            _context.SaveChanges();
            ViewBag.error = "Question Added Successfully";
            return View();
        }
        public IActionResult DisplayCSharp()
        {
            var allQuestions = _context.Questions.ToList();
            return View(allQuestions);
        }
        public IActionResult DisplaySQL()
        {
            var allQuestions = _context.SQLQuestions.ToList();
            return View(allQuestions);
        }

        public IActionResult UpdateSQL(int id)
        {

            var questionInfo = _context.SQLQuestions.FirstOrDefault(Q => Q.SQLModelId == id);
            return View(questionInfo);
        }
        [HttpPost]
        public IActionResult UpdateSQL(SQLModel sm)
        {

            var questionInfo = _context.SQLQuestions.FirstOrDefault(Q => Q.SQLModelId == sm.SQLModelId);
            if (questionInfo != null)
            {
                questionInfo.QuestionText = sm.QuestionText;
                questionInfo.OptionText1 = sm.OptionText1;
                questionInfo.OptionText2 = sm.OptionText2;
                questionInfo.OptionText3 = sm.OptionText3;
                questionInfo.OptionText4 = sm.OptionText4;

            }
           
            var res = _context.SaveChanges();
            return RedirectToAction("DisplaySQL");
        }






        public IActionResult UpdateCSharp(int id)
        {

            var questionInfo = _context.Questions.FirstOrDefault(Q => Q.QuestionId == id);
            return View(questionInfo);
        }
        [HttpPost]
        public IActionResult UpdateCSharp(Question qm)
        {

            var questionInfo = _context.Questions.FirstOrDefault(Q => Q.QuestionId == qm.QuestionId);
            if (questionInfo != null)
            {
                questionInfo.QuestionText = qm.QuestionText;
                questionInfo.OptionText1 = qm.OptionText1;
                questionInfo.OptionText2 = qm.OptionText2;
                questionInfo.OptionText3 = qm.OptionText3;
                questionInfo.OptionText4 = qm.OptionText4;

            }
            //_context.Questions.Update(questionInfo);
            var res = _context.SaveChanges();
            return View("DisplayCSharp");
        }


        public IActionResult SQLQuestion()
        {

            return View();
        }
        [HttpPost]
        public IActionResult SQLQuestion(SQLModel sm)
        {
            _context.SQLQuestions.Add(sm);
            _context.SaveChanges();
            ViewBag.error = "Question Added Successfully";
            return View();
        }
        public IActionResult htmlQuestions()
        {
            return View();
        }
        [HttpPost]
        public IActionResult htmlQuestions(HtmlModel hm)
        {
            _context.HtmlQuestions.Add(hm);
            _context.SaveChanges();
            ViewBag.error = "Question Added Successfully";
            return View();
        }

    }
}
