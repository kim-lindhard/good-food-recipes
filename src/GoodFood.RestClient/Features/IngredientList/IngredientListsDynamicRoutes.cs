using System;

namespace GoodFood.RestClient.Features.IngredientList
{
    public static class IngredientListsDynamicRoutes
    {
        public static string INGREDIENT_ROUTE(Guid ingredientListId, Guid ingredientId)
        {
            var route = IngredientListsStaticRoutes.INGREDIENT_ROUTE
                .Replace(
                    IngredientListsStaticRoutes.INGRIDIENT_LIST_ID_TOKEN, 
                    ingredientListId.ToString()
                ).Replace(
                    IngredientListsStaticRoutes.INGRIDIENT_ID_TOKEN, 
                    ingredientId.ToString()
                );;


            return route;
        }
        
        public static string INGREDIENT_LIST_ROUTE(Guid ingredientListId)
        {
            var route = IngredientListsStaticRoutes.INGREDIENT_LIST_ROUTE.Replace(
                IngredientListsStaticRoutes.INGRIDIENT_LIST_ID_TOKEN, 
                ingredientListId.ToString()
            );


            return route;
        }
    }
}