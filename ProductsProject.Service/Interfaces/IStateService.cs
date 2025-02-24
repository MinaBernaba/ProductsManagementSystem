using ProductsProject.Data.Entites;

namespace ProductsProject.Service.Interfaces
{
    public interface IStateService
    {
        Task<List<State>> GetAllStatesAsync();
        Task<State?> GetStateWithCountryByIdAsync(int stateId);
        Task<bool> IsStateExistByIdAsync(int stateId);
        Task<State?> GetStateByIdAsync(int stateId);
        Task<bool> AddStateAsync(State state);
        Task<bool> UpdateStateAsync(State state);
        Task<bool> DeleteStateAsync(State state);
    }
}
