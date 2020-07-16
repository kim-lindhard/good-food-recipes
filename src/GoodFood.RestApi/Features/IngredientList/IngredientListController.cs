using GoodFood.RestClient.Features.IngredientList;
using GoodFood.RestClient.Features.IngredientList.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace GoodFood.RestApi.Features.IngredientList
{
    [ApiController]
    [Route(IngredientListsStaticRoutes.INGREDIENT_LIST_ROUTE)]
    public class IngredientListController  : ControllerBase
    {
        [HttpPost]
        public IActionResult AddIngredient(IngredientCreateDto ingredientCreateDto)
        {
            return Ok();
        }
    }
}