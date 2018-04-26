using PMProjet.Models;
using System.Collections.Generic;

namespace PMProjet.ViewModels
{
    public class AdminViewModel
    {
        public User User { get; set; }
        public List<Project> Projects { get; set; }
        public List<Education> Educations { get; set; }

        public MessageViewModel MessageViewModel { get; set; }
    }
}
