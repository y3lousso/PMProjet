﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public class Slide
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
