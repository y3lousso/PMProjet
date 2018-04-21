using System;
using System.Collections.Generic;
using System.Linq;

namespace PMProjet.Models
{
    public class Dal : IDal
    {
        private MyDbContext db;

        public Dal(MyDbContext context)
        {
            db = context;
        }

        #region User
        public User GetUser()
        {
            User user = db.Users.First();
            return user;
        }

        public void ModifyUser(string pseudo, string password, string firstName, string lastName, string jobTitle, string email)
        {
            User user = db.Users.First();
            user.Pseudo = pseudo;
            user.Password = password;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.JobTitle = jobTitle;
            user.Email = email;
            db.SaveChanges();
        }

        public bool CheckUser(string username, string password)
        {
            if (db.Users.SingleOrDefault(u => u.Pseudo == username && u.Password == password) != null)
            {
                Console.WriteLine("Login success ! " + db.Users.FirstOrDefault(u => u.Pseudo == username && u.Password == password));
                return true;
            }
            else
            {
                Console.WriteLine("Login failed ! " + db.Users.FirstOrDefault(u => u.Pseudo == username && u.Password == password));
                return false;
            }  
        }
        #endregion

        #region Project
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

        public void ModifyProject(int id, string name, string date, string description, string thumbnail)
        {
            Project project = db.Projects.FirstOrDefault(p => p.Id == id);
            if(project != null)
            {
                project.Name = name;
                project.Date = date;
                project.Description = description;
                project.Thumbnail = thumbnail;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("No project founded, Id : " + id.ToString());
            }
        }

        #endregion

        #region Education
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

        public void ModifyEducation(int id, string name, string date, string description, string thumbnail)
        {
            Education education = db.Educations.FirstOrDefault(e => e.Id == id);
            if (education != null)
            {
                education.Name = name;
                education.Date = date;
                education.Description = description;
                education.Thumbnail = thumbnail;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("No education founded, Id : " + id.ToString());
            }
        }

        #endregion

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
