using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyDbContext(serviceProvider.GetRequiredService<DbContextOptions<MyDbContext>>()))
            {
                context.Database.EnsureCreated();

                // NEED AT LEAST ONE USER
                if (!context.Users.Any())
                {
                    context.Users.Add(new User { Id = 1, Pseudo = "admin", Password = "admin", FirstName = "FirstName", LastName = "LastName", JobTitle = "JobTitle", Email = "Email" });
                    context.SaveChanges();
                }

                // NEED AT LEAST ONE PROJECT
                if (!context.Projects.Any())
                {
                    context.Projects.Add(new Project { Id = 1, Name = "Project1", Date = "January 2000", Description = "Description1", Thumbnail = "template.png" });
                    context.SaveChanges();
                }

                // NEED AT LEAST ONE EDUCATION
                if (!context.Educations.Any())
                {
                    context.Educations.Add(new Education { Id = 1, Name = "Education1", Date = "January 2000", Description = "Description1", Thumbnail = "template.png" });
                    context.SaveChanges();
                }
            }
        }
    }
}
