using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Education> Restaurants { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
