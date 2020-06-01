using Q.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.DataAccess
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        T Filter(string column, object value);
        Task<IEnumerable<T>> FilterAll(string column, object value);
        Task DeleteByIdAsync(int id);
        Task<T> InsertAsync(T t);
        Task UpdateAsync(T t);
    }
}