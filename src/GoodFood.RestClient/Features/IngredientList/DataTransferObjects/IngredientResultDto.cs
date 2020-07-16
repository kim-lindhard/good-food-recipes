using System;
using GoodFood.Domain.Features.IngredientList.Models;

namespace GoodFood.RestClient.Features.IngredientList.DataTransferObjects
{
    public class IngredientResultDto
    {
        public IngredientResultDto(){}
        public string Title { get; set; }
        public string Description { get; set; }

        private IngredientResultDto(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public static IngredientResultDto FromIngredient(Ingredient ingredient)
        {
            return new IngredientResultDto(
                title: ingredient.Title,
                description: ingredient.Description
            );
        }
    }
}