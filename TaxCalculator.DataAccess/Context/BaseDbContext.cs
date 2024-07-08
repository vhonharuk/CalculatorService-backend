using Microsoft.EntityFrameworkCore;
using TaxCalculator.DataAccess.Models;

namespace TaxCalculator.DataAccess.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected BaseDbContext()
        {
        }

        public override int SaveChanges()
        {
            SetModificationDateOnAddOrUpdateEntity();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetModificationDateOnAddOrUpdateEntity();

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetModificationDateOnAddOrUpdateEntity()
        {
            // get entries that are being Added or Updated
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.State is EntityState.Added or EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is not BaseDbModelWithUpdateData entity)
                {
                    continue;
                }

                if (entry.State == EntityState.Added)
                {
                    entity.FirstInserted = DateTime.UtcNow;
                }
                else
                {
                    entity.LastUpdated = DateTime.UtcNow;
                }
            }
        }
    }
}
