using System;
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

        public IActionResult Index()
        {
            /*if (dal.CheckUser(username, password))
            {
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return RedirectToAction("InvalidPassword");
            }*/
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
            throw new NotImplementedException();
        }

        public IActionResult InvalidPassword()
        {
            LoginFormViewModel model = new LoginFormViewModel();
            model.Message = "Username or password is incorrect !";
            model.MessageColor = "red";
            return View("Index", model);
        }

        public IActionResult Connexion(string username, string password)
        {
            if (dal.CheckUser(username, password))
            {
                // Create AdminViewModel
                AdminViewModel model = new AdminViewModel();
                model.User = dal.GetUser();
                model.Projects = dal.GetAllProjects();
                model.Educations = dal.GetAllEducations();

                return View("../Admin/Index", model);
            }
            else
            {
                // Return to login index
                LoginFormViewModel model = new LoginFormViewModel();
                model.Message = "Username or password is incorrect !";
                model.MessageColor = "red";
                return View("Index", model);
            }
        }

        public IActionResult ResetPassword()
        {
            LoginFormViewModel model = new LoginFormViewModel();
            model.Message = "A email was send to your mail box ! (TODO)";
            model.MessageColor = "green";
            return View("Index", model);
        }
    }
}