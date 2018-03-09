using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public class User
    {
        public string Id { get; set; }
        [Required, MaxLength(80)]
        public string Pseudo { get; set; }
        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; } = "FirstName";
        public string LastName { get; set; } = "LastName";
        public string JobTitle { get; set; } = "JobTitle";

    }
}
