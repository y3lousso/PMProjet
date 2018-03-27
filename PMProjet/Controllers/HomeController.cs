using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PMProjet.Models;

namespace PMProjet.Controllers
{
    public class HomeController : Controller
    {
        private IDal dal;

        public HomeController(MyDbContext context)
        {
            dal = new Dal(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

        public void Login(string username, string password)
        {
            if (dal.CheckUser(username, password) != null)
            {
                Trace.WriteLine("Login correct !");
            }
            else
            {
                Trace.WriteLine("Login uncorrect !!!");
            }
        }

        public IActionResult Register()
        {
            throw new NotImplementedException();
        }

        public IActionResult ForgotPassWord()
        {
            throw new NotImplementedException();
        }
    }
}
