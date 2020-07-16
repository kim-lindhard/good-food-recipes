using System;
using System.Threading.Tasks;
using GoodFood.Domain.Features.IngredientList.Repositories;

namespace GoodFood.AcceptanceTests.Features.IngredientList.TestDoubles.Repositories
{
    public class InMemoryIngredientListRepository : IIngredientListRepository
    {
        public Task<Guid> Create()
        {
            return Task.FromResult(Guid.NewGuid());
        }
    }
}