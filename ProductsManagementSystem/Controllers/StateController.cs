using Microsoft.AspNetCore.Mvc;
using ProductsProject.Core.CQRS.States.Commands.Models;
using ProductsProject.Core.CQRS.States.Queries.Models;
using ProductsProject.Data.AppMetaData;
using SchoolManagementSystem.api.Base;

namespace ProductsManagementSystem.Controllers
{
    [ApiController]
    public class StateController : AppControllerBase
    {
        [HttpGet(Router.State.GetState)]
        public async Task<IActionResult> GetState(int id)
            => NewResult(await Mediator.Send(new GetStateByIdQuery() { StateId = id }));

        [HttpGet(Router.State.GetAllStates)]
        public async Task<IActionResult> GetAllStates()
            => NewResult(await Mediator.Send(new GetAllStatesQuery()));


        [HttpPost(Router.State.AddState)]
        public async Task<IActionResult> AddState(AddStateCommand addState)
            => NewResult(await Mediator.Send(addState));

        [HttpPut(Router.State.UpdateState)]
        public async Task<IActionResult> UpdateState(UpdateStateCommand updateState)
            => NewResult(await Mediator.Send(updateState));

        [HttpDelete(Router.State.DeleteState)]
        public async Task<IActionResult> DeleteState(int id)
            => NewResult(await Mediator.Send(new DeleteStateCommand() { StateId = id }));

    }
}
