using AutoMapper;
using MediatR;
using ProductsProject.Core.CQRS.States.Queries.Models;
using ProductsProject.Core.CQRS.States.Queries.Responses;
using ProductsProject.Core.ResponseBase;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Core.CQRS.States.Queries.Handler
{
    public class StateQueryHandler(IStateService stateService, IMapper mapper) : ResponseHandler,
        IRequestHandler<GetStateByIdQuery, Response<GetStateWithCountryResponse>>,
        IRequestHandler<GetAllStatesQuery, Response<List<GetStateWithCountryResponse>>>
    {
        public async Task<Response<GetStateWithCountryResponse>> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
            var state = await stateService.GetStateWithCountryByIdAsync(request.StateId);
            if (state == null)
                return NotFound<GetStateWithCountryResponse>($"No state with ID: {request.StateId} exists!");

            var stateMapper = mapper.Map<GetStateWithCountryResponse>(state);
            return Success(stateMapper);
        }

        public async Task<Response<List<GetStateWithCountryResponse>>> Handle(GetAllStatesQuery request, CancellationToken cancellationToken)
        {
            var states = await stateService.GetAllStatesAsync();
            var statesMapper = mapper.Map<List<GetStateWithCountryResponse>>(states);
            return Success(statesMapper);
        }
    }
}
