namespace GoodFood.RestClient.Features.IngredientList
{
    public static class IngredientListsStaticRoutes
    {
        internal const string INGRIDIENT_LIST_ID_TOKEN = "{ingredientListId}";
        internal const string INGRIDIENT_ID_TOKEN = "{ingredientId}";
        
        public const string INGREDIENT_LISTS_ROUTE = StaticRoutes.BASE_ROUTE + "ingredient-lists/";
        public const string INGREDIENT_LIST_ROUTE = INGREDIENT_LISTS_ROUTE + INGRIDIENT_LIST_ID_TOKEN;
        
        public const string INGREDIENT_ROUTE = INGREDIENT_LIST_ROUTE + "/ingredients/" + INGRIDIENT_ID_TOKEN;
    }
}