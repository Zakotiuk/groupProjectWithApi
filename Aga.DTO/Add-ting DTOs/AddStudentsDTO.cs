using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aga.DTO.Add_ting_DTOs
{
    public class AddStudentsDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Is required")]
        public string IsPay { get; set; }
        public int IdGroup { get; set; }
    }
}
