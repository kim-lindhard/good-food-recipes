using System;
using GoodFood.Domain.Features.IngredientList.Models;

namespace GoodFood.RestClient.Features.IngredientList.DataTransferObjects
{
    public class IngredientResultDto
    {
        public IngredientResultDto(){}
        
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        private IngredientResultDto(Guid identifier, string title, string description)
        {
            Identifier = identifier;
            Title = title;
            Description = description;
        }

        public static IngredientResultDto FromIngredient(Ingredient ingredient)
        {
            var ingredientResultDto =  new IngredientResultDto(
                identifier: ingredient.Identifier,
                title: ingredient.Title,
                description: ingredient.Description
            );

            return ingredientResultDto;
        }
    }
}