using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMProjet.Models;

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
            return View();
        }


        public void Connexion(string username, string password)
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

        public IActionResult Deconnexion()
        {
            throw new NotImplementedException();
        }
    }
}