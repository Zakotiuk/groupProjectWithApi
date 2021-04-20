using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aga.DTO
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Fullname is required")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Adress is required")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(15, 100)]
        public string Age { get; set; }
    }
}
