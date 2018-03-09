﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }

        //public List<Slide> Slides { get; set; }

    }
}
