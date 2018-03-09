using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public class Dal : IDal
    {
        private MyDbContext db;

        public Dal(MyDbContext context)
        {
            db = context;
        }

        public User GetUser()
        {
            return new User();
        }

        //Project
        public List<Project> GetAllProjects()
        {            
            return db.Projects.ToList();
        }

        public void AddProject(string name, string date, string description)
        {
            db.Projects.Add(new Project { Name = name, Date = date, Description = description });
            db.SaveChanges();
        }

        //Education
        public List<Education> GetAllEducations()
        {
            return db.Educations.ToList();
        }

        public void AddEducation()
        {

        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
