using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public class Dal : IDal
    {
        private MyDbContext db;

        public Dal()
        {
            db = new MyDbContext();
        }


        public User GetUser()
        {
            return new User();
        }

        //Project
        public List<Project> GetAllProjects()
        {
            return new List<Project>();
        }

        public void AddProject(string name, string date, string description)
        {
            db.Projects.Add(new Project { Name = name, Date = date, Description = description });
            db.SaveChanges();
        }

        //Education
        public List<Education> GetAllEducation()
        {
            return new List<Education>();
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
