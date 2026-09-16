using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories
{
    public class IngredientRepository
    {
        List<Ingredient> ingredients = new List<Ingredient>
        {
            new Ingredient
            {
                Id = 1,
                Name = "Egg"
            },
            new Ingredient
            {
                Id = 2,
                Name = "Milk"
            },
            new Ingredient
            {
                Id = 3,
                Name = "Sugar"
            },

        };

        public List<Ingredient> GetIngredients()
        { 
            return ingredients;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }
    }
}
