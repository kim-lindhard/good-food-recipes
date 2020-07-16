using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodFood.Domain.Features.IngredientList.Models
{
    public class IngredientList
    {
        public IngredientList(Guid id)
        {
            Id = id;
            _ingredient = new List<Ingredient>();
        }

        public void AddIngredientToList(Ingredient ingredient)
        {
            if (_ingredient.Any(existingIngredient =>
                existingIngredient==  ingredient)
            )
            {
                return;
            }
            
            _ingredient.Add(ingredient);
        }
        
        public void RemoveIngredientFromList(Ingredient ingredient)
        {
            var ingredientToRemove = _ingredient.Single(
                existingIngredient => existingIngredient == ingredient);
            _ingredient.Remove(ingredientToRemove);
        }
        public Guid Id { get; }

        public IEnumerable<Ingredient> Ingredients => _ingredient;

        private readonly List<Ingredient> _ingredient;
    }
}