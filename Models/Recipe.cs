using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
