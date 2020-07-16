using System;
using System.Collections.Generic;
using System.Net;
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


        public async Task Add(IngredientCommandDto ingredientCommandDto)
        {
            var payload = JsonConvert.SerializeObject(ingredientCommandDto);
            
            var content = new StringContent(
                payload,
                Encoding.UTF8,
                "application/json"
            );
            var relativeUri = new Uri(IngredientListsDynamicRoutes.INGREDIENT_LIST_ROUTE(_ingredientListId),
                UriKind.Relative);
            var httpResponseMessage = await _httpClient.PutAsync(
                relativeUri,
                content
            );
            
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                var exception = HttpResponseContentToException.Convert(responseContent);
                
                throw exception;
            }
           
        }

        public async Task<IEnumerable<IngredientResultDto>> GetAll(Guid ingredientListId)
        {
          
            var relativeUri = new Uri(IngredientListsDynamicRoutes.INGREDIENT_LIST_ROUTE(_ingredientListId),
                UriKind.Relative);
            var httpResponseMessage = await _httpClient.GetAsync(
                relativeUri
            );

            httpResponseMessage.EnsureSuccessStatusCode();
            
            var content = await httpResponseMessage.Content.ReadAsStringAsync();

           

            var topics = JsonConvert.DeserializeObject<IEnumerable<IngredientResultDto>>(content);

            return topics;
        }

        public async Task Remove(IngredientCommandDto lemonIngredientCommandDto)
        {
              
            var relativeUri = new Uri(IngredientListsDynamicRoutes.INGREDIENT_LIST_ROUTE(_ingredientListId),
                UriKind.Relative);
            
            var request = new HttpRequestMessage(HttpMethod.Delete, relativeUri);
            request.Content = new StringContent(JsonConvert.SerializeObject(lemonIngredientCommandDto), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }
    }
}