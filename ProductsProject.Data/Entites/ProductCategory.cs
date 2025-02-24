namespace ProductsProject.Data.Entites
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
