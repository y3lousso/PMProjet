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
            using (var context = new MyDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyDbContext>>()))
            {

                context.Database.EnsureCreated();
                // Look for any movies.
                if (context.Projects.Any() || context.Educations.Any() || context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                var projects = new Project[]
                {
        new Project{Name="InvasionVR",Date="Juin 2017",Description="Description1", Thumbnail="background.png"},
        new Project{Name="Civil Disorder",Date="Juillet 2018 - Mars 2025",Description="Description1", Thumbnail="background.png"},
                };
                foreach (Project p in projects)
                {
                    context.Projects.Add(p);
                }
                context.SaveChanges();

                var educations = new Education[]
                {
        new Education{Name="ENIB", Date="2013-2017",Description="EngineeringSchool", Thumbnail="background2.png"},
        new Education{Name="UQAC",Date="2017-2018",Description="University", Thumbnail="background.png"},
                };
                foreach (Education e in educations)
                {
                    context.Educations.Add(e);
                }
                context.SaveChanges();


                context.Users.Add(new User {Id = 1, Pseudo = "y3lousso", Password = "password", FirstName = "Yannick", LastName = "Loussouarn", JobTitle = "Student" });
                context.SaveChanges();
            }
        }
    }
}
