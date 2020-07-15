using Xunit;

namespace GoodFood.AcceptanceTests.IngredientsListScenarios
{
    public class AddAnIngredientToAIngredientList
    {
        [Fact]
        public void AddAnIngredientToAIngredientListRecipe()
        {
            Given_a_ingredient_list();
            When_I_add_a_ingredient();
            Then_I_can_find_the_ingredient_in_the_ingredient_list();
        }

        private void Given_a_ingredient_list()
        {
            throw new System.NotImplementedException();
        }

        private void When_I_add_a_ingredient()
        {
            throw new System.NotImplementedException();
        }

        private void Then_I_can_find_the_ingredient_in_the_ingredient_list()
        {
            throw new System.NotImplementedException();
        }
    }
}