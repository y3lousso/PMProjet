using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMProjet.Models;
using PMProjet.ViewModels;

namespace PMProjet.Controllers
{
    public class LoginController : Controller
    {
        private IDal dal;

        public LoginController(MyDbContext context)
        {
            dal = new Dal(context);
        }
        
        public static User CurrentUser = null;

        public IActionResult Index()
        {
            LoginFormViewModel model = new LoginFormViewModel();
            model.Message = null;
            model.MessageColor = null;
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ForgotPassWord()
        {
            return View();
        }

        public IActionResult Deconnexion()
        {
            // Reset session
            HttpContext.Session.SetString("USER_ID", "");
            LoginController.CurrentUser = null;

            return Redirect("Index");
        }

        public IActionResult Connexion(string username, string password)
        {
            if (dal.CheckUser(username, password))
            {

                // Create session
                LoginController.CurrentUser = dal.GetUser();
                HttpContext.Session.SetString("USER_ID", username);
                Console.WriteLine("Session : " + HttpContext.Session.GetString(username));

                // Redirect to Admin index
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                // Set message to wrong password
                LoginFormViewModel model = new LoginFormViewModel();
                model.Message = "Username or password is incorrect !";
                model.MessageColor = "red";

                // Return to login index
                return View("Index", model);
            }
        }

        public IActionResult ResetPassword()
        {
            // Set message to mail sended
            LoginFormViewModel model = new LoginFormViewModel();
            model.Message = "A email was send to your mail box ! (TODO)";
            model.MessageColor = "green";

            // Return to login index
            return View("Index", model);
        }
    }
}