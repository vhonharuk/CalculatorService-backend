namespace TaxCalculator.DataAccess.Interfaces
{
    public interface IRepository
    {
        bool SaveChanges();

        Task<bool> SaveChangesAsync();
    }
}
