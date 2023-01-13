using System.Linq.Expressions;

namespace city.Repository.IRepository
{
    public interface IRepository <T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetFristOrDefault(Expression<Func<T, bool>> Filter, string ? IncludeProperties =null);
        IEnumerable<T> FindAll(string? IncludeProperties = null);
        void DeleteRange(IEnumerable<T> t);
    }
}
