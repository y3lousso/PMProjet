using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Connexion(string username, string password)
        {
            if (dal.CheckUser(username, password))
            {
                return RedirectToAction("Index","AdminController");
            }
            else
            {
                return RedirectToAction("InvalidPassword");
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

        public IActionResult Deconnexion()
        {
            throw new NotImplementedException();
        }

        public IActionResult InvalidPassword()
        {
            return View("InvalidPassword");
        }
    }
}