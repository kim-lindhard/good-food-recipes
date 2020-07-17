using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoodFood.Domain.Features.IngredientList.Models;

namespace GoodFood.Domain.Features.IngredientList.Repositories
{
    public interface IIngredientListRepository
    {
        Task<Guid> CreateAsync();

        Task<Models.IngredientList> GetAsync(Guid ingredientListId);
        Task StoreAsync(Models.IngredientList ingredientList);
    }
}