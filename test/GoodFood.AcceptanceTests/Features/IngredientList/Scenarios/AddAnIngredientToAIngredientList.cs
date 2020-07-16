using System;
using System.Threading.Tasks;
using GoodFood.AcceptanceTests.Features.IngredientList.TestDoubles.Repositories;
using GoodFood.Domain.Features.IngredientList.Repositories;
using GoodFood.RestClient;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace GoodFood.AcceptanceTests.Features.IngredientList.Scenarios
{
    public class AddAnIngredientToAIngredientList
    {
        private IHost _testHost;
        private Client _client;
        private Guid _ingredientListId;
        
        [Fact]
        public async Task AddAnIngredientToAIngredientListRecipe()
        {
            await Given_a_rest_api();
                  And_a_rest_client();
            await And_a_ingredient_list();
                  When_I_add_a_ingredient();
                  Then_I_can_find_the_ingredient_in_the_ingredient_list();
        }
        private async Task Given_a_rest_api()
        {
            var builder = new RestApiHostBuilder()
                .WithService<IIngredientListRepository>(new InMemoryIngredientListRepository());
            
            _testHost = await builder.CreateAsync();
        }
        
        private void And_a_rest_client()
        {
            var testHttpClient = HostBuilderTestServerExtensions.GetTestClient(_testHost);
            _client = new Client(testHttpClient);
        }
        
        private async Task And_a_ingredient_list()
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