using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GoodFood.RestClient.Features.IngredientList.DataTransferObjects;
using Newtonsoft.Json;

namespace GoodFood.RestClient.Features.IngredientList
{
    public class IngredientList
    {
        private readonly HttpClient _httpClient;
        private readonly Guid _ingredientListId;

        public IngredientList(HttpClient httpClient, Guid ingredientListId)
        {
            _httpClient = httpClient;
            _ingredientListId = ingredientListId;
        }


        public async Task Add(IngredientCreateDto ingredientCreateDto)
        {
            var payload = JsonConvert.SerializeObject(ingredientCreateDto);
            
            var content = new StringContent(
                payload,
                Encoding.UTF8,
                "application/json"
            );
            var relativeUri = new Uri(IngredientListsDynamicRoutes.INGREDIENT_LIST_ROUTE(_ingredientListId),
                UriKind.Relative);
            var httpResponseMessage = await _httpClient.PostAsync(
                relativeUri,
                content
            );

            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}