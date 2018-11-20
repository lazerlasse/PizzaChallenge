using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaChallenge.Model
{
    public partial class Type
    {
        [Key]
        [Column("TID")]
        public int Tid { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
