using System;
using System.Threading.Tasks;
using GoodFood.AcceptanceTests.Features.IngredientList.TestDoubles.Repositories;
using GoodFood.Domain.Features.IngredientList.Repositories;
using GoodFood.RestClient;
using GoodFood.RestClient.Features.IngredientList.DataTransferObjects;
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
        private IngredientCreateDto _lemonIngredientCreateDto;

        [Fact]
        public async Task AddAnIngredientToAIngredientListRecipe()
        {
            await Given_a_rest_api();
                  And_a_rest_client();
            await And_a_ingredient_list();
            await When_I_add_a_ingredient();
            await Then_I_can_find_the_ingredient_in_the_ingredient_list();
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
        _ingredientListId = await _client.IngredientLists.CreateAsync();
        }

        private async Task When_I_add_a_ingredient()
        {
            _lemonIngredientCreateDto = new IngredientCreateDto
            {
                Title = "Lemon",
                Description = "An acid fruit that is botanically a many-seeded pale yellow oblong berry produced by a small thorny citrus tree (Citrus limon) and that has a rind from which an aromatic oil is extracted"
            };
            await _client.IngredientLists
                .List(_ingredientListId)
                .AddAsync(_lemonIngredientCreateDto);
        }

        private async Task Then_I_can_find_the_ingredient_in_the_ingredient_list()
        {
            var ingridients = await _client.IngredientLists
                .List(_ingredientListId).GetAllAsync(_ingredientListId);
            
            Assert.Single(ingridients, i => i.Title == _lemonIngredientCreateDto.Title);
            Assert.Single(ingridients, i => i.Description == _lemonIngredientCreateDto.Description);
        }
    }
}