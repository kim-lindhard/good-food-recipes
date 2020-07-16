using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodFood.Domain.Features.IngredientList.Models;
using GoodFood.Domain.Features.IngredientList.Repositories;

namespace GoodFood.AcceptanceTests.Features.IngredientList.TestDoubles.Repositories
{
    public class InMemoryIngredientListRepository : IIngredientListRepository
    {
        private Dictionary<Guid, Domain.Features.IngredientList.Models.IngredientList> _ingredientLists;
        public InMemoryIngredientListRepository()
        {
            _ingredientLists = new Dictionary<Guid, Domain.Features.IngredientList.Models.IngredientList>();
        }

        public Task<Guid> Create()
        {
            var id = Guid.NewGuid();
            
            _ingredientLists.Add(id, new Domain.Features.IngredientList.Models.IngredientList(id));
          
            return Task.FromResult(id);
        }

        public Task<Domain.Features.IngredientList.Models.IngredientList> Get(Guid ingredientListId)
        {
            var ingredientList = _ingredientLists[ingredientListId];
            return Task.FromResult(ingredientList);
        }

        public Task Store(Domain.Features.IngredientList.Models.IngredientList ingredientList)
        {
            _ingredientLists[ingredientList.Id] = ingredientList;
            
            return Task.CompletedTask;
        }
    }
}