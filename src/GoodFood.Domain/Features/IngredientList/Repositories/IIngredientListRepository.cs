using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoodFood.Domain.Features.IngredientList.Models;

namespace GoodFood.Domain.Features.IngredientList.Repositories
{
    public interface IIngredientListRepository
    {
        Task<Guid> Create();

        Task<Models.IngredientList> Get(Guid ingredientListId);
        Task Store(Models.IngredientList ingredientList);
    }
}