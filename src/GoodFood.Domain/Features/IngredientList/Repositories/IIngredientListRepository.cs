using System;
using System.Threading.Tasks;
using GoodFood.Domain.Features.IngredientList.Models;

namespace GoodFood.Domain.Features.IngredientList.Repositories
{
    public interface IIngredientListRepository
    {
        Task<Guid> Create();
        
        Task Add(Guid ingredientListId, Ingredient ingredient);
    }
}