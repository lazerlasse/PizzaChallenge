using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaChallenge.Model
{
    public partial class IngPro
    {
        [Column("ProFK")]
        public int ProFk { get; set; }
        [Column("IngFK")]
        public int IngFk { get; set; }
    }
}
