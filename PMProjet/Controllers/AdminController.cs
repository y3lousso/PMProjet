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

        #region User
        public IActionResult ModifyUser()
        {
            User user = dal.GetUser();
            return View("ModifyUser", user);
        }

        [HttpPost, ActionName("ModifyUser")]
        public IActionResult ModifyUserPost(User user)
        {
            dal.ModifyUser(user.Pseudo, user.Password, user.FirstName, user.LastName, user.JobTitle, user.Email);
            return RedirectToAction("Index");
        }
        #endregion

        #region Project

        public IActionResult AddProject()
        {
            return View("AddProject");
        }

        [HttpPost]
        public IActionResult AddProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }
            else
            {
                dal.AddProject(project.Name, project.Date, project.Description, project.Thumbnail);
                return RedirectToAction("Index");
            }
        }

        public IActionResult ModifyProject(int projectId)
        {
            Project project = dal.GetProject(projectId);
            return View("ModifyProject", project);
        }

        [HttpPost]
        public IActionResult ModifyProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }
            else
            {
                dal.ModifyProject(project.Id, project.Name, project.Date, project.Description, project.Thumbnail);
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteProject(int projectId)
        {
            dal.DeleteProject(projectId);
            return RedirectToAction("Index");
        }

        public IActionResult AddSlide(int projectId)
        {
            SlideProjectViewModel vm = new SlideProjectViewModel();
            vm.ProjectId = projectId;
            vm.Slide = new Slide();
            return View("AddSlide", vm);
        }

        [HttpPost]
        public IActionResult AddSlide(SlideProjectViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else
            {
                dal.AddSlide(vm.ProjectId, vm.Slide.Title, vm.Slide.Description, vm.Slide.Image);
                return RedirectToAction("Index");
            }
        }

        public IActionResult ModifySlide(int projectId, int slideId)
        {
            Slide slide = dal.GetSlide(projectId, slideId);
            return View("ModifySlide", slide);
        }

        [HttpPost]
        public IActionResult ModifySlide(SlideProjectViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else
            {
                dal.ModifySlide(vm.ProjectId, vm.Slide.Id, vm.Slide.Title, vm.Slide.Description, vm.Slide.Image);
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteSlide(int projectId, int slideId)
        {
            dal.DeleteSlide(projectId, slideId);
            return RedirectToAction("Index");
        }


        #endregion

        #region Education

        public IActionResult AddEducation()
        {
            return View("AddEducation");
        }

        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View(education);
            }
            else
            {
                dal.AddEducation(education.Name, education.Date, education.Description, education.Thumbnail, education.WebsiteAdress);
                return RedirectToAction("Index");
            }
        }

        public IActionResult ModifyEducation(int educationId)
        {
            Education education = dal.GetEducation(educationId);
            return View("ModifyEducation", education);
        }

        [HttpPost]
        public IActionResult ModifyEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View(education);
            }
            else
            {
                dal.ModifyEducation(education.Id, education.Name, education.Date, education.Description, education.Thumbnail, education.WebsiteAdress);
                return RedirectToAction("Index");
            }
        }
        public IActionResult DeleteEducation(int educationId)
        {
            dal.DeleteEducation(educationId);
            return RedirectToAction("Index");
        }

        #endregion


    }
}