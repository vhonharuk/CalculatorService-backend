using System.Linq.Expressions;
using TaxCalculator.DataAccess.Context;
using TaxCalculator.DataAccess.Models;
using TaxCalculator.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TaxCalculator.DataAccess.Repositories
{
    public class TaxRepository<T> : BaseRepository, ITaxRepository<T> where T : BaseDbModel
    {
        public TaxRepository(TaxDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public T Find(Expression<Func<T, bool>> searchExpression)
        {
            return DbContext.Set<T>().FirstOrDefault(searchExpression);
        }
    }
}
