using Microsoft.EntityFrameworkCore.Storage;
using ProductsProject.Infrastructure.Context;
using ProductsProject.Infrastructure.Interfaces;

namespace ProductsProject.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly ApplicationDbContext _context;

        private Lazy<IProductRepository> _products;
        private Lazy<ICategoryRepository> _categories;
        private Lazy<IProductCategoryRepository> _productCategories;
        private Lazy<ICountryRepository> _countries;
        private Lazy<IStateRepository> _states;
        private Lazy<ICityRepository> _cities;


        public IProductRepository Products => _products.Value;
        public ICategoryRepository Categories => _categories.Value;
        public IProductCategoryRepository ProductCategories => _productCategories.Value;
        public ICountryRepository Countries => _countries.Value;
        public IStateRepository States => _states.Value;
        public ICityRepository Cities => _cities.Value;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _products = new Lazy<IProductRepository>(() => new ProductRepository(_context));
            _categories = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
            _productCategories = new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(_context));
            _countries = new Lazy<ICountryRepository>(() => new CountryRepository(_context));
            _states = new Lazy<IStateRepository>(() => new StateRepository(_context));
            _cities = new Lazy<ICityRepository>(() => new CityRepository(_context));
        }
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        #region Transaction
        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();
        public async Task CommitTransactionAsync()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CommitTransactionAsync();
                await SaveChangesAsync();
            }
        }
        public async Task RollBackAsync()
        {
            if (_context.Database.CurrentTransaction != null)
                await _context.Database.RollbackTransactionAsync();
        }
        #endregion

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
        }
    }
}
