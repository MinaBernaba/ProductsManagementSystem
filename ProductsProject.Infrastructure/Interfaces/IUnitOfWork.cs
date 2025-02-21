using Microsoft.EntityFrameworkCore.Storage;

namespace ProductsProject.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IProductCategoryRepository ProductCategories { get; }
        ICountryRepository Countries { get; }
        IStateRepository States { get; }
        ICityRepository Cities { get; }

        Task<int> SaveChangesAsync();

        #region Transaction
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackAsync();
        #endregion
    }
}
