﻿using System;
using System.Collections.Generic;
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
    }
}