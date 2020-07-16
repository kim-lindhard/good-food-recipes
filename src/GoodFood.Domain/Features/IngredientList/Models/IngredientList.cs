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
                existingIngredient.Title == ingredient.Title &&
                existingIngredient.Description == ingredient.Description))
            {
                return;
            }
            
            _ingredient.Add(ingredient);
        }
        
        public void RemoveIngredientFromList(Ingredient ingredient)
        {
            _ingredient.Remove(ingredient);
        }
        public Guid Id { get; }

        public IEnumerable<Ingredient> Ingredients => _ingredient;

        private readonly List<Ingredient> _ingredient;
    }
}