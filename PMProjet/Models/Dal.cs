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
            User user = db.Users.First();
            return user;
        }

        public bool CheckUser(string username, string password)
        {
            if (db.Users.FirstOrDefault(u => u.Pseudo == username && u.Password == password) != null)                
            {
                return true;
            }
            else
            {
                return false;
            }        
        }

        //Project
        public List<Project> GetAllProjects()
        {            
            return db.Projects.ToList();
        }

        public Project GetProject(int id)
        {
            Project project = db.Projects.FirstOrDefault(p => p.Id == id);
            return project;
        }

        public void AddProject(string name, string date, string description, string thumbnail)
        {
            db.Projects.Add(new Project { Name = name, Date = date, Description = description, Thumbnail = thumbnail });
            db.SaveChanges();
        }

        //Education
        public List<Education> GetAllEducations()
        {
            return db.Educations.ToList();
        }

        public Education GetEducation(int id)
        {
            Education education = db.Educations.FirstOrDefault(e => e.Id == id);
            return education;
        }

        public void AddEducation(string name, string date, string description, string thumbnail)
        {
            db.Educations.Add(new Education { Name = name, Date = date, Description = description, Thumbnail = thumbnail });
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
