using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodFood.Domain.Features.IngredientList.Models;
using GoodFood.Domain.Features.IngredientList.Repositories;
using GoodFood.RestClient.Features.IngredientList;
using GoodFood.RestClient.Features.IngredientList.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace GoodFood.RestApi.Features.IngredientList
{
    [ApiController]
    public class IngredientListController : ControllerBase
    {
        private readonly IIngredientListRepository _ingredientListRepository;

        public IngredientListController(IIngredientListRepository ingredientListRepository)
        {
            _ingredientListRepository = ingredientListRepository;
        }

        [HttpPut]
        [Route(IngredientListsStaticRoutes.INGREDIENT_LIST_ROUTE)]
        public async Task<IActionResult> AddIngredientAsync(Guid ingredientListId,
            [FromBody] IngredientCreateDto ingredientCreateDto)
        {
            IActionResult actionResult;
            try
            {
                var ingredient = IngredientCreateDto.ToIngredient(ingredientCreateDto);
                var ingredientList = await _ingredientListRepository.GetAsync(ingredientListId);
                ingredientList.AddIngredientToList(ingredient);

                actionResult = Ok();
            }
            catch (Exception exception) when (ExceptionToStatusCode.CanConvert(exception, out actionResult))
            {
            }

            return actionResult;
        }

        [HttpDelete]
        [Route(IngredientListsStaticRoutes.INGREDIENT_ROUTE)]
        public async Task<IActionResult> RemoveIngredientAsync(Guid ingredientListId, Guid ingredientId)
        {
            IActionResult actionResult;
            try
            {
                var ingredientList = await _ingredientListRepository.GetAsync(ingredientListId);
                ingredientList.RemoveIngredientFromList(ingredientId);

                await _ingredientListRepository.StoreAsync(ingredientList);
                actionResult = Ok();
            }
            catch (Exception exception) when (ExceptionToStatusCode.CanConvert(exception, out actionResult))
            {
            }

            return actionResult;
        }


        [HttpGet]
        [Route(IngredientListsStaticRoutes.INGREDIENT_LIST_ROUTE)]
        public async Task<IEnumerable<IngredientResultDto>> GetAllIngredientsAsync(Guid ingredientListId)
        {
            var ingredientList = await _ingredientListRepository.GetAsync(ingredientListId);
            var ingredients = ingredientList.Ingredients;
            var ingredientResultDtos = ingredients.Select(i => IngredientResultDto.FromIngredient(i));
          
            
            return ingredientResultDtos;
        }
    }
}