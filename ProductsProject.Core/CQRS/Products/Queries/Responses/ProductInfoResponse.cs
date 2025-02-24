namespace ProductsProject.Core.CQRS.Products.Queries.Responses
{
    public class ProductInfoResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string? ProductImage { get; set; }
        public string CountryName { get; set; }
    }
}
