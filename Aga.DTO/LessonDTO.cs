using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aga.DTO
{
   public class LessonDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }
        public string idTeacher { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
