using System;
using System.Threading.Tasks;

namespace GoodFood.Domain.Features.IngredientList.Repositories
{
    public interface IIngredientListRepository
    {
        Task<Guid> Create();
    }
}