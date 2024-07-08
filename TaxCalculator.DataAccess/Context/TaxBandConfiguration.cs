using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxCalculator.DataAccess.Models;

namespace TaxCalculator.DataAccess.Context
{
    public static class TaxBandConfiguration
    {
        public static ModelBuilder ConfigureTaxBand(this ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<TaxBand>(entity =>
            {
                entity.SeedTaxBands();
            });
        }

        private static void SeedTaxBands(this EntityTypeBuilder<TaxBand> entity)
        {
            entity.HasData(
                new TaxBand
                {
                    Id = Guid.Parse("41c548b8-b89c-47c7-81cc-4d3373f429d0"),
                    LowerLimit = 0,
                    UpperLimit = 5000,
                    Rate = 0,
                },
                new TaxBand
                {
                    Id = Guid.Parse("c9608fe8-0580-4afc-803d-f1f7ebbf8192"),
                    LowerLimit = 5000,
                    UpperLimit = 20000,
                    Rate = 20,
                },
                new TaxBand
                {
                    Id = Guid.Parse("5b5e983b-7981-49c4-a19c-18f162d6fd61"),
                    LowerLimit = 20000,
                    Rate = 40,
                });
        }
    }
}
