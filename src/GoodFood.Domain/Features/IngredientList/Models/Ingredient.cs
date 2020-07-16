using GoodFood.Domain.Features.IngredientList.Exceptions;

namespace GoodFood.Domain.Features.IngredientList.Models
{
    public class Ingredient
    {
        private const int MAX_TITLE_LENGTH = 90;
        public Ingredient(string title, string description)
        {
            if (MAX_TITLE_LENGTH < title.Length)
            {
                throw new TitleLengthTooLongException(title, MAX_TITLE_LENGTH);
            }
            
            Title = title;
            Description = description;
        }
        public string Title { get; }
        public string Description { get; }
    }
}