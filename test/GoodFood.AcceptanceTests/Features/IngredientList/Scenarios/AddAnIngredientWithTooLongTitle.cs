using System;
using System.Threading.Tasks;
using GoodFood.AcceptanceTests.Features.IngredientList.TestDoubles.Repositories;
using GoodFood.Domain.Features.IngredientList.Exceptions;
using GoodFood.Domain.Features.IngredientList.Repositories;
using GoodFood.RestClient;
using GoodFood.RestClient.Features.IngredientList.DataTransferObjects;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace GoodFood.AcceptanceTests.Features.IngredientList.Scenarios
{
    public class AddAnIngredientWithTooLongTitle
    {
        private IHost _testHost;
        private Client _client;
        private Guid _ingredientListId;
        private IngredientCreateDto _ingredientWithTooLongTitleCreateDto;
        private TitleLengthTooLongException _titleLengthTooLongException;

        [Fact]
        public async Task AddAnIngredientWithTooLongTitleRecipe()
        {
            await Given_a_rest_api();
                  And_a_rest_client();
            await And_a_ingredient_list();
            await When_I_add_a_ingredient_with_a_title_of_91_length();
                  Then_I_get_a_exception();
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

        private async Task When_I_add_a_ingredient_with_a_title_of_91_length()
        {
            _ingredientWithTooLongTitleCreateDto = new IngredientCreateDto
            {
                Title = "this title is 91 chars long !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",
                Description = "this ingredients title is expected to be too long"
            };
           
            
            
            _titleLengthTooLongException = await Assert.ThrowsAsync<TitleLengthTooLongException>(() => 
                 _client.IngredientLists
                    .List(_ingredientListId)
                    .AddAsync(_ingredientWithTooLongTitleCreateDto)
            );
        }

        private void Then_I_get_a_exception()
        {
            Assert.NotNull(_titleLengthTooLongException);
        }
    }
}