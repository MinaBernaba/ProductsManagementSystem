namespace ProductsProject.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api/";
        public const string version = "V1/";
        public const string rule = root + version;
        public static class Country
        {
            public const string Prefix = rule + "Country/";
            public const string GetCountry = Prefix + "GetCountryById/{id}";
            public const string GetAllCountries = Prefix + "GetAllCountries";
            public const string AddCountry = Prefix + "AddCountry";
            public const string UpdateCountry = Prefix + "UpdateCountry";
            public const string DeleteCountry = Prefix + "DeleteCountryById/{id}";
        }
        public static class State
        {
            public const string Prefix = rule + "State/";
            public const string GetState = Prefix + "GetStateById/{id}";
            public const string GetAllStates = Prefix + "GetAllStates";
            public const string AddState = Prefix + "AddState";
            public const string UpdateState = Prefix + "UpdateState";
            public const string DeleteState = Prefix + "DeleteStateById/{id}";
        }
        public static class Category
        {
            public const string Prefix = rule + "Category/";
            public const string GetCategory = Prefix + "GetCategoryById/{id}";
            public const string GetAllCategories = Prefix + "GetAllCategories";
            public const string AddCategory = Prefix + "AddCategory";
            public const string UpdateCategory = Prefix + "UpdateCategory";
            public const string DeleteCategory = Prefix + "DeleteCategoryById/{id}";
        }

        public static class Product
        {
            public const string Prefix = rule + "Product/";
            public const string GetProduct = Prefix + "GetProductById/{id}";
            public const string GetAllProducts = Prefix + "GetAllProducts";
            public const string AddProduct = Prefix + "AddProduct";
            public const string UpdateProduct = Prefix + "UpdateProduct";
            public const string DeleteProduct = Prefix + "DeleteProductById/{id}";
            public const string AddCategoriesToProduct = Prefix + "AddCategoriesToProduct";
            public const string SetProductCategories = Prefix + "SetProductCategories";

        }

        public static class City
        {
            public const string Prefix = rule + "City/";
            public const string GetCity = Prefix + "GetCityById/{id}";
            public const string GetAllCities = Prefix + "GetAllCities";
            public const string AddCity = Prefix + "AddCity";
            public const string UpdateCity = Prefix + "UpdateCity";
            public const string DeleteCity = Prefix + "DeleteCityById/{id}";
        }
    }
}
