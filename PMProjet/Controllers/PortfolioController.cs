using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMProjet.Models;

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
            Project project = dal.GetProject(projectId);
            return View("Slideshow", project);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}