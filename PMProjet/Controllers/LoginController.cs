using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PMProjet.Models;
using System.Web;

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
            UserViewModel viewModel = new UserViewModel() { Authentification = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.User = dal.GetUser(HttpContext.User.Identity.Name);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(UserViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = dal.CheckUser(viewModel.User.Pseudo, viewModel.User.Password);
                if (User != null)
                {
                   //FormsAuthentification.SetAuthCookie(user.Id.ToString(), false);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/");
                }

                ModelState.AddModelError("Utilisateur.Prenom", "Prénom et/ou mot de passe incorrect(s)");
            }

            return View(viewModel);
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
            return Redirect("/");
        }

        public IActionResult ForgotPassWord()
        {
            return Redirect("/");
        }

        public IActionResult Deconnexion()
        {
            return Redirect("/");
        }
    }
}