namespace ProductsProject.Data.Entites
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string? Flag { get; set; }

        public ICollection<State> States { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
