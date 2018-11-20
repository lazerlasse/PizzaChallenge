using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaChallenge.Model
{
    public partial class Ingredient
    {
        [Key]
        [Column("I_ID")]
        public int IId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }
    }
}
