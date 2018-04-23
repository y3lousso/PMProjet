using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMProjet.Models;
using PMProjet.ViewModels;

namespace PMProjet.Controllers
{
    public class LoginController : Controller
    {
        private IDal dal;
        private Random random = new Random(); // A random for random password generation

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

            //
            HttpContext.SignOutAsync();

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

                // Add Admin authorization
                ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(LoginController.CurrentUser), CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

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

        public IActionResult ResetPassword(string email)
        {
            LoginFormViewModel model = new LoginFormViewModel();
            User user = dal.GetUser();
            if (user.Email == email)
            {
                // Create new random password
                String randomPassword = RandomString(20);

                // Create mail
                MailMessage mail = new MailMessage("portfolio.template.azure@gmail.com", email);
                mail.Subject = "Password Recovery";
                string baseUri = Request.GetUri().GetLeftPart(UriPartial.Authority);
                mail.Body = string.Format(
                    "Hi {0},<br /><br />" + 
                    "Your new password has been reset and is <b>{1}</b>. <br />" +
                    "You are encouraged to change your new password as soon as possible !<br />" +
                    "You can login <a href={2}/Login>here</a> with your new password.<br /><br />" +
                    "Thank You !", user.Pseudo, randomPassword, baseUri);
                mail.IsBodyHtml = true;

                // Create client
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("portfolio.template.azure@gmail.com", "PortfolioTemplate1");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Port = 587;

                // Send mail
                smtp.Send(mail);

                // Reset password
                dal.ModifyUser(user.Pseudo, randomPassword, user.FirstName, user.LastName, user.JobTitle, user.Email);

                // Set meassage to email sended
                model.Message = "A email was send to your mail box !";
                model.MessageColor = "green";
            }
            else
            {
                // Set message to email incorrect
                model.Message = "This email is incorrect !";
                model.MessageColor = "red";
            };

            // Return to login index
            return View("Index", model);
        }

        public IActionResult AccessDenied()
        {
            // Set message to access denied
            LoginFormViewModel model = new LoginFormViewModel();
            model.Message = "Access denied ! Please login first !";
            model.MessageColor = "red";

            // Return to login index
            return View("Index", model);
        }

        // Claim authorization for the current user
        private IEnumerable<Claim> GetUserClaims(User user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Pseudo));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            return claims;
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}