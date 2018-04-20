using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMProjet.Models;
using PMProjet.ViewModels;

namespace PMProjet.Controllers
{
    public class AdminController : Controller
    {
        private IDal dal;

        public AdminController(MyDbContext context)
        {
            dal = new Dal(context);
        }

        public IActionResult Index()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            adminViewModel.User = dal.GetUser();
            adminViewModel.Projects = dal.GetAllProjects();
            adminViewModel.Educations = dal.GetAllEducations();
            return View(adminViewModel);
        }

        public IActionResult ModifyUser()
        {
            User user = dal.GetUser();
            return View("ModifyUser", user);
        }

        public IActionResult ModifyProject(int id)
        {
            Project project = dal.GetProject(id);
            return View("ModifyProject", project);
        }

        public IActionResult ModifyEducation(int id)
        {
            Education education = dal.GetEducation(id);
            return View("ModifyEducation", education);
        }


    }
}