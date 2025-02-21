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
        [HttpPost(Router.Country.AddCountry)]
        public async Task<IActionResult> AddCountry([FromForm] AddCountryCommand addCountry) => NewResult(await Mediator.Send(addCountry));



        [HttpGet(Router.Country.GetCountryById)]
        public async Task<IActionResult> AddCountry(int id) => NewResult(await Mediator.Send(new GetCountryById() { CountryId = id }));

    }
}
