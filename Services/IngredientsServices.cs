using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Repositories;

namespace Services
{
    public class IngredientsServices
    {
        private readonly IngredientRepository _ingredientRepository;

        public IngredientsServices(IngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _ingredientRepository.GetIngredients();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            _ingredientRepository.AddIngredient(ingredient);
        }

        public Ingredient? GetIngredientById(int id)
        {
            return _ingredientRepository.GetIngredients().FirstOrDefault(ingredient => ingredient.Id == id);
        }
    }
}
