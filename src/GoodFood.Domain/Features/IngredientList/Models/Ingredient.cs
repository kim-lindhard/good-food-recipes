namespace GoodFood.Domain.Features.IngredientList.Models
{
    public class Ingredient
    {
        public Ingredient(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public string Title { get; }
        public string Description { get; }
    }
}