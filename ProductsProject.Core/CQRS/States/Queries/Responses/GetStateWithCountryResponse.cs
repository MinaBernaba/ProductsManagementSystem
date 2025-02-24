namespace ProductsProject.Core.CQRS.States.Queries.Responses
{
    public class GetStateWithCountryResponse
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
    }
}
