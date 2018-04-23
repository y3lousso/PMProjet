using PMProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.ViewModels
{
    public class SlideProjectViewModel
    {
        public Project Project { get; set; }
        public List<Slide> Slides { get; set; }
    }
}
