using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoodFood.Domain.Features.IngredientList.Models;
using GoodFood.Domain.Features.IngredientList.Repositories;

namespace GoodFood.AcceptanceTests.Features.IngredientList.TestDoubles.Repositories
{
    public class InMemoryIngredientListRepository : IIngredientListRepository
    {
        private readonly Dictionary<Guid, List<Ingredient>> _ingredientLists;

        public InMemoryIngredientListRepository()
        {
            _ingredientLists = new Dictionary<Guid, List<Ingredient>>();
        }

        public Task<Guid> Create()
        {
            var id = Guid.NewGuid();
            
            _ingredientLists.Add(id, new List<Ingredient>());
          
            return Task.FromResult(id);
        }

        public Task Add(Guid ingredientListId, Ingredient ingredient)
        {
            var list = _ingredientLists[ingredientListId];
            
            list.Add(ingredient);
            
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Ingredient>> GetList(Guid ingredientListId)
        {
            IEnumerable<Ingredient> list = _ingredientLists[ingredientListId];
            return Task.FromResult(list);
        }
    }
}