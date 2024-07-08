using Microsoft.EntityFrameworkCore;
using TaxCalculator.DataAccess.Interfaces;

namespace TaxCalculator.DataAccess.Repositories
{
    public class BaseRepository : IRepository
    {
        protected readonly DbContext DbContext;

        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual bool SaveChanges()
        {
            return DbContext.SaveChanges() > 0;
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync() > 0;
        }
    }
}
