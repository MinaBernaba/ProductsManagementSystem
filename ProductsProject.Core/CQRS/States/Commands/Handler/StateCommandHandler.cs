using AutoMapper;
using MediatR;
using ProductsProject.Core.CQRS.States.Commands.Models;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Data.Entites;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.States.Commands.Handler
{
    public class StateCommandHandler(IStateService stateService, IMapper mapper) : ResponseHandler,
        IRequestHandler<AddStateCommand, Response<string>>,
        IRequestHandler<UpdateStateCommand, Response<string>>,
        IRequestHandler<DeleteStateCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddStateCommand request, CancellationToken cancellationToken)
        {
            var state = mapper.Map<State>(request);
            if (!await stateService.AddStateAsync(state))
                return BadRequest<string>();

            return Success($"State {state.StateName} added successfully with ID: {state.StateId} .");
        }

        public async Task<Response<string>> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var state = await stateService.GetStateByIdAsync(request.StateId);

            if (state == null)
                return NotFound<string>($"No state with ID: {request.StateId} exists.");

            mapper.Map(request, state);

            if (!await stateService.UpdateStateAsync(state))
                return BadRequest<string>();

            return Success($"State with ID: {state.StateId} updated successfully.");
        }

        public async Task<Response<string>> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {
            var state = await stateService.GetStateByIdAsync(request.StateId);
            if (state == null)
                return NotFound<string>($"No state with ID: {request.StateId} exists.");

            if (!await stateService.DeleteStateAsync(state))
                return BadRequest<string>();

            return Success($"State with ID: {state.StateId} deleted successfully!");
        }
    }
}
