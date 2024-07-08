using System.Linq.Expressions;

namespace TaxCalculator.DataAccess.Interfaces
{
    public interface ITaxRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);

        Task<ICollection<T>> GetAllAsync();

        T Find(Expression<Func<T, bool>> searchExpression);
    }
}
