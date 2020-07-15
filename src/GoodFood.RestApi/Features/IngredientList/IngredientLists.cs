using System;
using GoodFood.RestClient;
using Microsoft.AspNetCore.Mvc;

namespace GoodFood.RestApi.Features.IngredientList
{
    [ApiController]
    [Route(StaticRoutes.INGREDIENT_LISTS_ROUTE)]
    public class IngredientLists : ControllerBase
    {
        [HttpPost]
        public Guid CreateIngredientList()
        {
            return new Guid();
        }
    }
}