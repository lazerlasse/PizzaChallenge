using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaChallenge.Model
{
    public partial class Product
    {
        [Key]
        [Column("PID")]
        public int Pid { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Price { get; set; }
        [Column("TypeFK")]
        public int TypeFk { get; set; }
    }
}
