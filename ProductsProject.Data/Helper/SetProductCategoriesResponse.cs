namespace ProductsProject.Data.Helper
{
    public class SetProductCategoriesResponse
    {
        public HashSet<int> AddedCategories { get; set; } = new();
        public HashSet<int> RemovedCategories { get; set; } = new();
        public HashSet<int> InvalidCategories { get; set; } = new();
        public string Message { get; set; } = string.Empty;
    }
}