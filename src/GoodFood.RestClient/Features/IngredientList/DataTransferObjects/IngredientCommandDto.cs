using GoodFood.Domain.Features.IngredientList.Models;

namespace GoodFood.RestClient.Features.IngredientList.DataTransferObjects
{
    public class IngredientCommandDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public static Ingredient ToIngredient(IngredientCommandDto ingredientCommandDto)
        {
            var ingredient = new Ingredient(
                ingredientCommandDto.Title,
                ingredientCommandDto.Description
            );

            return ingredient;
        }
    }
}