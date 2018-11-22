using System;
using System.Collections.Generic;

namespace PizzaChallenge.Model
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int TypeFk { get; set; }
		public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
