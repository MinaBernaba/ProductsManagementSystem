namespace ProductsProject.Data.Helper
{
    public class AddCategoriesToProductResponse
    {
        public HashSet<int> InvalidCategoriesIds { get; set; } = new HashSet<int>();
        public HashSet<int> ValidCategoriesIds { get; set; } = new HashSet<int>();
        public string Message { get; set; }
    }
}
