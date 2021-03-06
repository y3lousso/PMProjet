﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMProjet.Models;
using PMProjet.ViewModels;

namespace PMProjet.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IDal dal;

        public AdminController(MyDbContext context)
        {
            dal = new Dal(context);

        }

        public IActionResult Index(MessageViewModel messageViewModel)
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            adminViewModel.User = dal.GetUser();
            adminViewModel.Projects = dal.GetAllProjects();
            adminViewModel.Educations = dal.GetAllEducations();
            adminViewModel.MessageViewModel = messageViewModel;
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
            dal.ModifyUserInfo(user.Pseudo, user.FirstName, user.LastName, user.JobTitle, user.Email);
            MessageViewModel model = new MessageViewModel();
            model.Message = "User information edited with success !";
            model.MessageColor = "green";
            return RedirectToAction("Index", model);
        }

        public IActionResult ModifyPassword()
        {
            return View("ModifyPassword");
        }

        [HttpPost, ActionName("ModifyPassword")]
        public IActionResult ModifyPasswordPost(string currentPassword, string newPassword, string confirmNewPassword)
        {
            User user = dal.GetUser();
            MessageViewModel model = new MessageViewModel();
            if (newPassword == confirmNewPassword && dal.CheckUser(user.Pseudo, currentPassword))
            {
                dal.ModifyUserPassword(newPassword);
                model.Message = "Your password has been changed !";
                model.MessageColor = "green";
            }
            else
            {
                model.Message = "Can't change your password ! Please check the information typed !";
                model.MessageColor = "red";
            }

            return RedirectToAction("Index", model);
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
                MessageViewModel model = new MessageViewModel();
                model.Message = "Project added with success !";
                model.MessageColor = "green";
                return RedirectToAction("Index", model);
            }
        }

        public IActionResult ModifyProject(int projectId)
        {
            SlideProjectViewModel vm = new SlideProjectViewModel();
            vm.Project= dal.GetProject(projectId);
            vm.Slides = dal.GetSlidesFor(projectId);
            return View("ModifyProject", vm);
        }

        [HttpPost]
        public IActionResult ModifyProject(SlideProjectViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else
            {
                dal.ModifyProject(vm.Project.Id, vm.Project.Name, vm.Project.Date, vm.Project.Description, vm.Project.Thumbnail);
                MessageViewModel model = new MessageViewModel();
                model.Message = "Project edited with success !";
                model.MessageColor = "green";
                return RedirectToAction("Index", model);
            }
        }

        public IActionResult DeleteProject(int projectId)
        {
            dal.DeleteProject(projectId);
            MessageViewModel model = new MessageViewModel();
            model.Message = "Project deleted with success !";
            model.MessageColor = "green";
            return RedirectToAction("Index", model);
        }

        public IActionResult AddSlide(int projectId)
        {
            Slide slide = new Slide();
            slide.ProjectId = projectId;
            return View("AddSlide", slide);
        }

        [HttpPost]
        public IActionResult AddSlide(Slide slide)
        {
            if (!ModelState.IsValid)
            {
                return View(slide);
            }
            else
            {
                dal.AddSlide(slide.ProjectId, slide.Title, slide.Description, slide.Image);
                return RedirectToAction("ModifyProject", new { projectId = slide.ProjectId });
            }
        }

        public IActionResult ModifySlide(int slideId)
        {
            Slide slide = dal.GetSlide(slideId);
            return View("ModifySlide", slide);
        }

        [HttpPost]
        public IActionResult ModifySlide(Slide slide)
        {
            if (!ModelState.IsValid)
            {
                return View(slide);
            }
            else
            {
                dal.ModifySlide(slide.Id, slide.Title, slide.Description, slide.Image);
                return RedirectToAction("ModifyProject", new { projectId = slide.ProjectId });
            }
        }

        public IActionResult DeleteSlide(int slideId)
        {
            dal.DeleteSlide(slideId);
            MessageViewModel model = new MessageViewModel();
            model.Message = "Slide deleted with success !";
            model.MessageColor = "green";
            return RedirectToAction("Index", model);
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
                MessageViewModel model = new MessageViewModel();
                model.Message = "Education added with success !";
                model.MessageColor = "green";
                return RedirectToAction("Index", model);
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
                MessageViewModel model = new MessageViewModel();
                model.Message = "Education edited with success !";
                model.MessageColor = "green";
                return RedirectToAction("Index", model);
            }
        }
        public IActionResult DeleteEducation(int educationId)
        {
            dal.DeleteEducation(educationId);
            MessageViewModel model = new MessageViewModel();
            model.Message = "Education deleted with success !";
            model.MessageColor = "green";
            return RedirectToAction("Index", model);
        }

        #endregion


    }
}