using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PMProjet.Models;

namespace PMProjet.Controllers
{
    public class PortfolioController : Controller
    {

        private IDal dal;

        public PortfolioController() : this(new Dal())
        {

        }

        public PortfolioController(IDal dalIoc)
        {
            dal = dalIoc;
        }

        public ActionResult Index()
        {
            List<Project> listeDesRestaurants = dal.GetAllProjects();
            return View(listeDesRestaurants);
        }

    }
}