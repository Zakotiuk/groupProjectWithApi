using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aga.DataAccess.Entity
{
    public class User : IdentityUser
    {   [Required(ErrorMessage = "Fullname is required")]
        public string Fullname { get; set; }
         [Required(ErrorMessage = "Adress is required")]
        public string Adress { get; set; }
         [Required(ErrorMessage = "Age is required")]
        public string Age { get; set; }

    }
}
