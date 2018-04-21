using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMProjet.Models
{
    public class User
    {               
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false), MaxLength(80)]
        public string Pseudo { get; set; } = "admin";
        [Required(ErrorMessage = "Please Provide Password", AllowEmptyStrings = false)]
        public string Password { get; set; } = "admin";

        public string FirstName { get; set; } = "FirstName";
        public string LastName { get; set; } = "LastName";
        public string JobTitle { get; set; } = "JobTitle";
        public string Email { get; set; } = "Email";

    }
}
