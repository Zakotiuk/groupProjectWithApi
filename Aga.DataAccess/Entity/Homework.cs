using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aga.DataAccess.Entity
{
    [Table("tblHomework")]
    public class Homework
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Id of teacher is required")]
        public string idTeacher { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
