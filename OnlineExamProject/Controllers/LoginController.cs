using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineExamProject.Models;

namespace OnlineExamProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly ExamDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public LoginController(ExamDbContext context,IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public IActionResult Login()
        {
            //ViewBag.role = new List<SelectListItem>
            //{
            //    new SelectListItem{Text="--Select--",Value="--Select--"},
            //    new SelectListItem{Text="Admin",Value="Admin"},
            //    new SelectListItem{Text="Student",Value="Student"}
            //    // Add more Roles as needed
            //};


            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLogin login)
        {
            var loginDeatils=_context.UserLogin.FirstOrDefault(u=>u.UserName== login.UserName && u.Password==login.Password);
         
            if (loginDeatils != null)
            {
               
                _contextAccessor.HttpContext.Session.SetInt32("UserLoginId", loginDeatils.UserLoginId);
                if (loginDeatils.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if(loginDeatils.Role== "Student")
                {
                    return RedirectToAction("StartExam", "Student");
                }
            }
            else
            {
                ViewBag.error = "Invalied user";
                return View();
            }

            return View();
        }
    }
}
