﻿using System;
using System.Collections.Generic;

namespace PizzaChallenge.Model
{
    public partial class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
