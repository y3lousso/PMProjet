using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public class MyDbContext : DbContext
    {

        public DbSet<Project> Projects { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<User> Users { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Education>().ToTable("Education");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
