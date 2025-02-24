using Microsoft.AspNetCore.Mvc;
using ProductsProject.Core.CQRS.Countries.Commands.Models;
using ProductsProject.Core.CQRS.Countries.Queries.Models;
using ProductsProject.Data.AppMetaData;
using SchoolManagementSystem.api.Base;

namespace ProductsManagementSystem.Controllers
{
    [ApiController]
    public class CountryController : AppControllerBase
    {
        [HttpGet(Router.Country.GetCountry)]
        public async Task<IActionResult> AddCountry(int id)
            => NewResult(await Mediator.Send(new GetCountryByIdQuery() { CountryId = id }));


        [HttpGet(Router.Country.GetAllCountries)]
        public async Task<IActionResult> GetAllCountries() => NewResult(await Mediator.Send(new GetAllCountriesQuery()));


        [HttpPost(Router.Country.AddCountry)]
        public async Task<IActionResult> AddCountry([FromForm] AddCountryCommand addCountry)
            => NewResult(await Mediator.Send(addCountry));



        [HttpPut(Router.Country.UpdateCountry)]
        public async Task<IActionResult> UpdateCountry([FromForm] UpdateCountryCommand updateCountry)
            => NewResult(await Mediator.Send(updateCountry));



        [HttpDelete(Router.Country.DeleteCountry)]
        public async Task<IActionResult> DeleteCountry(int id)
            => NewResult(await Mediator.Send(new DeleteCountryByIdCommand() { CountryId = id }));

    }
}
