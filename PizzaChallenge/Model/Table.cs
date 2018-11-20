using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaChallenge.Model
{
    public partial class Table
    {
        [Key]
        [Column("TID")]
        public int Tid { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
