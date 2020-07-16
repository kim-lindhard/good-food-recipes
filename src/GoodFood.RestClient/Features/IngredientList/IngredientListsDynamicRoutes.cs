using System;

namespace GoodFood.RestClient.Features.IngredientList
{
    public static class IngredientListsDynamicRoutes
    {
        public static string INGREDIENT_LIST_ROUTE(Guid ingredientListId)
        {
            var route = IngredientListsStaticRoutes.INGREDIENT_LIST_ROUTE.Replace(
                IngredientListsStaticRoutes.ID_TOKEN, 
                ingredientListId.ToString()
            );


            return route;
        }
    }
}