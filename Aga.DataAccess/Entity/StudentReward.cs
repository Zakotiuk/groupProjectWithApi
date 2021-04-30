using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aga.DataAccess.Entity
{
    [Table("tblStundetReward")]

   public class StudentReward
    {
        [Key]
        public int Id { get; set; }
        public Student IdStudent { get; set; }
        public Reward IdReward { get; set; }
    }
}
