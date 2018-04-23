using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PMProjet.Models
{
    public class Dal : IDal
    {
        private MyDbContext db;

        // Security
        private string EncryptionKey = "MAKV2SPBNI99212";
        private byte[] Salt = {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76};

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
            user.Password = Encrypt(password);
            user.FirstName = firstName;
            user.LastName = lastName;
            user.JobTitle = jobTitle;
            user.Email = email;
            db.SaveChanges();
        }

        public bool CheckUser(string username, string password)
        {
            if (db.Users.SingleOrDefault(u => u.Pseudo == username && u.Password == Encrypt(password)) != null)
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
            Project project = new Project
            {
                Name = name,
                Date = date,
                Description = description,
                Thumbnail = thumbnail,
            };
            db.Projects.Add(project);
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

        public void DeleteProject(int id)
        {
            Project project = GetProject(id);
            db.Slides.RemoveRange(GetSlidesFor(id));
            db.Projects.Remove(project);
            db.SaveChanges();
        }

        #endregion

        #region Slide

        public void AddSlide(int projectId, string title, string description, string image)
        {
            db.Slides.Add(new Slide {ProjectId = projectId, Title = title, Description = description, Image = image });
            db.SaveChanges();
        }

        public Slide GetSlide(int slideId)
        {
            return db.Slides.FirstOrDefault(p => p.Id == slideId);
        }

        public List<Slide> GetSlidesFor(int projectId)
        {
            List<Slide> slides = new List<Slide>();
            foreach (Slide s in db.Slides)
            {
                if(s.ProjectId == projectId)
                {
                    slides.Add(s);
                }
            }
            return slides;
        }

        public void ModifySlide(int slideId, string title, string description, string image)
        {
            Slide slide = GetSlide(slideId);
            if (slide != null)
            {
                slide.Title = title;
                slide.Description = description;
                slide.Image = image;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("No slide founded, Id : " + slideId.ToString());
            }
        }

        public void DeleteSlide(int slideId)
        {
            db.Slides.Remove(GetSlide(slideId));
            db.SaveChanges();
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

        public void AddEducation(string name, string date, string description, string thumbnail, string websiteAdress)
        {
            db.Educations.Add(new Education { Name = name, Date = date, Description = description, Thumbnail = thumbnail, WebsiteAdress = websiteAdress });
            db.SaveChanges();
        }

        public void ModifyEducation(int id, string name, string date, string description, string thumbnail, string websiteAdress)
        {
            Education education = db.Educations.FirstOrDefault(e => e.Id == id);
            if (education != null)
            {
                education.Name = name;
                education.Date = date;
                education.Description = description;
                education.Thumbnail = thumbnail;
                education.WebsiteAdress = websiteAdress;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("No education founded, Id : " + id.ToString());
            }
        }

        public void DeleteEducation(int id)
        {
            db.Educations.Remove(GetEducation(id));
            db.SaveChanges();
        }

        #endregion

        public void Dispose()
        {
            db.Dispose();
        }

        // encrypt a password
        private string Encrypt(string clearText)
        {

            // Security
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] Salt = {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76};


            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, Salt);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }

            return clearText;
        }

    }
}
