using Microsoft.EntityFrameworkCore;
using ProductsProject.Data.Entites;
using ProductsProject.Infrastructure.Interfaces;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Service.Services
{
    public class StateService(IUnitOfWork unitOfWork) : IStateService
    {
        public async Task<State?> GetStateWithCountryByIdAsync(int stateId) => await unitOfWork.States.GetAllNoTracking().Where(x => x.StateId.Equals(stateId)).Include(x => x.Country).FirstOrDefaultAsync();
        public async Task<State?> GetStateByIdAsync(int stateId) => await unitOfWork.States.GetByIdAsync(stateId);
        public async Task<bool> IsStateExistByIdAsync(int stateId)
            => await unitOfWork.States.IsExist(X => X.StateId.Equals(stateId));
        public async Task<bool> AddStateAsync(State state)
        {
            await unitOfWork.States.AddAsync(state);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateStateAsync(State state)
        {
            unitOfWork.States.Update(state);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteStateAsync(State state)
        {
            unitOfWork.States.Delete(state);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<List<State>> GetAllStatesAsync()
            => await unitOfWork.States.GetAllNoTracking().Include(x => x.Country).ToListAsync();
    }
}
