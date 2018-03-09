using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PMProjet.Models;

namespace PMProjet.Controllers
{
    public class EducationController : Controller
    {
        private IDal dal;

        public EducationController(MyDbContext context)
        {
            dal = new Dal(context);
        }

        public IActionResult Index()
        {
            List<Education> eduList = dal.GetAllEducations();
            return View(eduList);
        }

    }
}