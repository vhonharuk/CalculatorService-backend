using Microsoft.EntityFrameworkCore;
using TaxCalculator.DataAccess.Models;

namespace TaxCalculator.DataAccess.Context
{
    public class TaxDbContext : BaseDbContext
    {
        public DbSet<TaxBand> TaxBands { get; set; }

        public TaxDbContext()
        {
        }

        public TaxDbContext(DbContextOptions<TaxDbContext> opt)
            : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureTaxBand();

            base.OnModelCreating(modelBuilder);
        }
    }
}
