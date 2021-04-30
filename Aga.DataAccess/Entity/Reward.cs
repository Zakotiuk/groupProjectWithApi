using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aga.DataAccess.Entity
{
    [Table("tblReward")]

    public class Reward
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
