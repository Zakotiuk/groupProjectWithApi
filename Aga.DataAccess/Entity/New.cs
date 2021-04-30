using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aga.DataAccess.Entity
{
    [Table("tblNews")]
    public class New
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
