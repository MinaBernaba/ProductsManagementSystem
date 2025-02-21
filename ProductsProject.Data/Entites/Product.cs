namespace ProductsProject.Data.Entites
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string? ProductImage { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
