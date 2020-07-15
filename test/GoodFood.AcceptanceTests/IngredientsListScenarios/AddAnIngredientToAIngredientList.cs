using System;
using System.Threading.Tasks;
using GoodFood.RestClient;
using Xunit;

namespace GoodFood.AcceptanceTests.IngredientsListScenarios
{
    public class AddAnIngredientToAIngredientList
    {
        private readonly Client _client;
        private Guid _ingredientListId;

        public AddAnIngredientToAIngredientList()
        {
            _client = new Client(null);
        }
        [Fact]
        public async Task AddAnIngredientToAIngredientListRecipe()
        {
            await Given_a_ingredient_list();
                  When_I_add_a_ingredient();
                  Then_I_can_find_the_ingredient_in_the_ingredient_list();
        }

        private async Task Given_a_ingredient_list()
        {
        _ingredientListId = await _client.IngredientLists.Create();
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