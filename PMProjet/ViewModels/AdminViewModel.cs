using PMProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.ViewModels
{
    public class AdminViewModel
    {
        public User User { get; set; }
        public List<Project> Projects { get; set; }
        public List<Education> Educations { get; set; }
    }
}
