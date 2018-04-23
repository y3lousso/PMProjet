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
    public class PortfolioController : Controller
    {
        private IDal dal;

        public PortfolioController(MyDbContext context)
        {
            dal = new Dal(context);
        }

        public IActionResult Index()
        {
            List<Project> projects = dal.GetAllProjects();
            return View(projects);
        }

        public IActionResult Slideshow(int projectId)
        {
            SlideProjectViewModel vm = new SlideProjectViewModel();
            vm.Project = dal.GetProject(projectId);
            vm.Slides = dal.GetSlidesFor(projectId);
            return View("Slideshow", vm);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}