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
            public const string AddCountry = Prefix + "AddCountry";
            public const string GetCountryById = Prefix + "GetCountryById/{id}";
        }
    }
}
