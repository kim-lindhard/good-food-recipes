using System;
using GoodFood.Domain.Features.IngredientList.Repositories;
using GoodFood.RestClient.Features.IngredientList;
using GoodFood.RestClient.Features.IngredientList.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace GoodFood.RestApi.Features.IngredientList
{
    [ApiController]
    [Route(IngredientListsStaticRoutes.INGREDIENT_LIST_ROUTE)]
    public class IngredientListController  : ControllerBase
    {
        private readonly IIngredientListRepository _ingredientListRepository;

        public IngredientListController(IIngredientListRepository ingredientListRepository)
        {
            _ingredientListRepository = ingredientListRepository;
        }

        [HttpPost]
        public IActionResult AddIngredient(Guid id, [FromBody] IngredientCreateDto ingredientCreateDto)
        {
            var ingredient = IngredientCreateDto.ToIngredient(ingredientCreateDto);
            _ingredientListRepository.Add(id, ingredient);
            
            return Ok();
        }
    }
}