﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPut]
        public async Task<IActionResult> AddIngredient(Guid id, [FromBody] IngredientCommandDto ingredientCommandDto)
        {
            IActionResult actionResult;
            try
            {
                var ingredient = IngredientCommandDto.ToIngredient(ingredientCommandDto);
                var ingredientList = await _ingredientListRepository.Get(id);
                ingredientList.AddIngredientToList(ingredient);

                actionResult = Ok();
            }
            catch (Exception exception) when (ExceptionToStatusCode.CanConvert(exception, out actionResult))
            {
            }

            return actionResult;
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveIngredient(Guid id, [FromBody] IngredientCommandDto ingredientCommandDto)
        {
            IActionResult actionResult;
            try
            {
                var ingredient = IngredientCommandDto.ToIngredient(ingredientCommandDto);
                var ingredientList = await _ingredientListRepository.Get(id);
                ingredientList.RemoveIngredientFromList(ingredient);
                
                await _ingredientListRepository.Store(ingredientList);
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
            var ingredientList = await _ingredientListRepository.Get(id);
            var ingredients = ingredientList.Ingredients;

            return ingredients.Select(i => IngredientResultDto.FromIngredient(i));
        }
    }
}