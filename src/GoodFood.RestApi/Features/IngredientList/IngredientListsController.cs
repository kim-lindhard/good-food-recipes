using System;
using System.Threading.Tasks;
using GoodFood.Domain.Features.IngredientList.Repositories;
using GoodFood.RestClient.Features.IngredientList;
using Microsoft.AspNetCore.Mvc;

namespace GoodFood.RestApi.Features.IngredientList
{
    [ApiController]
    [Route(IngredientListsStaticRoutes.INGREDIENT_LISTS_ROUTE)]
    public class IngredientListsController : ControllerBase
    {
        private readonly IIngredientListRepository _ingredientListRepository;

        public IngredientListsController(IIngredientListRepository  ingredientListRepository)
        {
            _ingredientListRepository = ingredientListRepository;
        }
        
        [HttpPost]
        public async Task<Guid> CreateIngredientList()
        {
            return await _ingredientListRepository.Create();
        }
    }
}