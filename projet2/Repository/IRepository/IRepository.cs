using System.Linq.Expressions;

namespace projet2.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IEnumerable<T> GetAll(string? includeProp = null);
        T GetById(int id);
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProp = null);


    }
}
