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

        public int AddUser(string username, string password)
        {
            int id = !db.Users.Any() ? 1 : db.Users.Max(u => u.Id) + 1;
            User user = new User {Id = id, Pseudo = username, Password = password};
            db.Users.Add(user);
            return id;
        }

        public int AddUser(string username, string password, string firstname, string lastname, string jobTitle)
        {
            int id = !db.Users.Any() ? 1 : db.Users.Max(u => u.Id) + 1;
            User user = new User { Id = id, Pseudo = username, Password = password, FirstName = firstname, LastName = lastname, JobTitle = jobTitle};
            db.Users.Add(user);
            return id;
        }

        public User GetUser(int id)
        {
            User user = db.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User GetUser(string idString)
        {
            return int.TryParse(idString, out var id) ? GetUser(id) : null;
        }

        public bool CheckUser(string username, string password)
        {
            Console.WriteLine(db.Users.FirstOrDefault(u => u.Pseudo == username && u.Password == password));
            return true;
            /*if (db.Users.FirstOrDefault(u => u.Pseudo == username && u.Password == password) != null)                
            {
                return true;
            }
            else
            {
                return false;
            }  */       
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
