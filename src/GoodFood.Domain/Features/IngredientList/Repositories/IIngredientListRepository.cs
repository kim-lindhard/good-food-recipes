using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoodFood.Domain.Features.IngredientList.Models;

namespace GoodFood.Domain.Features.IngredientList.Repositories
{
    public interface IIngredientListRepository
    {
        Task<Guid> Create();
        
        Task Add(Guid ingredientListId, Ingredient ingredient);

        Task<IEnumerable<Ingredient>> GetList(Guid ingredientListId);
    }
}