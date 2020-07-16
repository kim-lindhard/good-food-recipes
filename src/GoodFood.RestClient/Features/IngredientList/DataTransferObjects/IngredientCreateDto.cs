using System;
using GoodFood.Domain.Features.IngredientList.Models;

namespace GoodFood.RestClient.Features.IngredientList.DataTransferObjects
{
    public class IngredientCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public static Ingredient ToIngredient(
            IngredientCreateDto ingredientCreateDto)
        {
            var ingredient = new Ingredient(
                ingredientCreateDto.Title,
                ingredientCreateDto.Description
            );

            return ingredient;
        }
    }
}