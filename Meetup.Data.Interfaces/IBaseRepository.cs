using Meetup.Models;

namespace Meetup.Data.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task SaveAsync();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
