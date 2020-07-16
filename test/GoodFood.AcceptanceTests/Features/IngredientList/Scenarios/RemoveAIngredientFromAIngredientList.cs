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
    public class RemoveAIngredientFromAIngredientList
    {
        public class AddAnIngredientToAIngredientList
        {
            private IHost _testHost;
            private Client _client;
            private Guid _ingredientListId;
            private IngredientCommandDto _lemonIngredientCommandDto;

            [Fact]
            public async Task RemoveAIngredientFromAIngredientListRecipe()
            {
                await Given_a_rest_api();
                      And_a_rest_client();
                await And_a_ingredient_list();
                await And_an_ingredient();
                await When_I_remove_an_ingredient();
                await Then_the_ingredient_list_will_be_empty();
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

            private async Task And_an_ingredient()
            {
                _lemonIngredientCommandDto = new IngredientCommandDto
                {
                    Title = "Lemon",
                    Description =
                        "An acid fruit that is botanically a many-seeded pale yellow oblong berry produced by a small thorny citrus tree (Citrus limon) and that has a rind from which an aromatic oil is extracted"
                };
                await _client.IngredientLists
                    .List(_ingredientListId)
                    .Add(_lemonIngredientCommandDto);
            }

            private async Task When_I_remove_an_ingredient()
            {
                _lemonIngredientCommandDto = new IngredientCommandDto
                {
                    Title = "Lemon",
                    Description =
                        "An acid fruit that is botanically a many-seeded pale yellow oblong berry produced by a small thorny citrus tree (Citrus limon) and that has a rind from which an aromatic oil is extracted"
                };
                await _client.IngredientLists
                    .List(_ingredientListId)
                    .Remove(_lemonIngredientCommandDto);
            }

            private async Task Then_the_ingredient_list_will_be_empty()
            {
                var ingridients = await _client.IngredientLists
                    .List(_ingredientListId).GetAll(_ingredientListId);

                Assert.Empty(ingridients);
            }
        }
    }
}