using Microsoft.AspNetCore.Mvc;
using ProductsProject.Core.CQRS.Cities.Commands.Models;
using ProductsProject.Core.CQRS.Cities.Queries.Models;
using ProductsProject.Data.AppMetaData;
using SchoolManagementSystem.api.Base;

namespace ProductsManagementSystem.Controllers
{
    [ApiController]
    public class CityController : AppControllerBase
    {

        [HttpGet(Router.City.GetCity)]
        public async Task<IActionResult> AddCity(int id)
           => NewResult(await Mediator.Send(new GetCityInfoByIdQuery() { CityId = id }));

        [HttpGet(Router.City.GetAllCities)]
        public async Task<IActionResult> GetAllCities()
           => NewResult(await Mediator.Send(new GetAllCitiesMainInfoQuery()));


        [HttpPost(Router.City.AddCity)]
        public async Task<IActionResult> AddCity(AddCityCommand addCity)
            => NewResult(await Mediator.Send(addCity));

        [HttpPut(Router.City.UpdateCity)]
        public async Task<IActionResult> UpdateCity(UpdateCityCommand updateCity)
           => NewResult(await Mediator.Send(updateCity));

        [HttpDelete(Router.City.DeleteCity)]
        public async Task<IActionResult> DeleteCity(int id)
           => NewResult(await Mediator.Send(new DeleteCityCommand() { CityId = id }));

    }
}
