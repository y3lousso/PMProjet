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
        [Required(ErrorMessage = "Please provide a pseudo.", AllowEmptyStrings = false), MaxLength(80)]
        public string Pseudo { get; set; } = "admin";
        [Required(ErrorMessage = "Please provide a password.", AllowEmptyStrings = false)]
        public string Password { get; set; } = "admin";
        [Required(ErrorMessage = "Please provide a first name.", AllowEmptyStrings = false)]
        public string FirstName { get; set; } = "FirstName";
        [Required(ErrorMessage = "Please provide a last name.", AllowEmptyStrings = false)]
        public string LastName { get; set; } = "LastName";
        [Required(ErrorMessage = "Please provide a job title.", AllowEmptyStrings = false)]
        public string JobTitle { get; set; } = "JobTitle";
        [Required(ErrorMessage = "Please provide an email.", AllowEmptyStrings = false)]
        public string Email { get; set; } = "Email";

    }
}
