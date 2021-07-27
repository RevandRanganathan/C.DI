using HON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HON.Models
{
    public class Student 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email Address")]
        //[EmailAddress]
        //[ValidEmailDomain(allowedDomain: "cognizant.com", ErrorMessage = "Valid Email ends with cognizant.com")]
        public string Email { get; set; }
        public string  Password { get; set; }

    }
}
