using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoodFood.RestClient
{
    public class IngredientLists
    {
        private readonly HttpClient _httpClient;

        public IngredientLists(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Guid> Create()
        {
            

            var httpResponseMessage = await _httpClient.PostAsync(
                new Uri(StaticRoutes.INGREDIENT_LISTS_ROUTE, UriKind.Relative),
                null
            );
         
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            
            var ingredientListId = JsonConvert.DeserializeObject<Guid>(content);


            return ingredientListId;
        }
    }
}