using System.Net.Http;
using GoodFood.RestClient.Features.IngredientList;

namespace GoodFood.RestClient
{
    public class Client
    {
        public Client(HttpClient httpClient)
        {
            IngredientLists = new IngredientLists(httpClient);
        }
        public IngredientLists IngredientLists { get; }
    }
}
