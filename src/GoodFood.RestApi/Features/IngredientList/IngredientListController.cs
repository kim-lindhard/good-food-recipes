using System;
using System.Collections;
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
    [Route(IngredientListsStaticRoutes.INGREDIENT_LIST_ROUTE)]
    public class IngredientListController : ControllerBase
    {
        private readonly IIngredientListRepository _ingredientListRepository;

        public IngredientListController(IIngredientListRepository ingredientListRepository)
        {
            _ingredientListRepository = ingredientListRepository;
        }

        [HttpPost]
        public IActionResult AddIngredient(Guid id, [FromBody] IngredientCreateDto ingredientCreateDto)
        {
            IActionResult actionResult;
            try
            {
                var ingredient = IngredientCreateDto.ToIngredient(ingredientCreateDto);
                _ingredientListRepository.Add(id, ingredient);

                actionResult = Ok();
            }
            catch (Exception exception) when (ExceptionToStatusCode.CanConvert(exception, out actionResult))
            {
            }

            return actionResult;
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientResultDto>> GetAllIngredients(Guid id)
        {
            var ingredients = await _ingredientListRepository.GetList(id);

            return ingredients.Select(i => IngredientResultDto.FromIngredient(i));
        }
    }
}