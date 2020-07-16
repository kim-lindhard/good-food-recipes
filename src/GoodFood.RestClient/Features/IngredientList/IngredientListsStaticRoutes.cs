namespace GoodFood.RestClient.Features.IngredientList
{
    public static class IngredientListsStaticRoutes
    {
        internal const string ID_TOKEN = "{id}";
        public const string INGREDIENT_LISTS_ROUTE = StaticRoutes.BASE_ROUTE + "ingredient-lists/";
        public const string INGREDIENT_LIST_ROUTE = INGREDIENT_LISTS_ROUTE + ID_TOKEN;
    }
}