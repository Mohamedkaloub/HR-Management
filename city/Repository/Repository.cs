using city.Data;
using city.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace city.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public DbSet<T> dbset;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbset = _db.Set<T>();

        }
        public void Add(T entity)
        {
            _db.Add(entity);
        }

        public void Delete(T entity)
        {
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> t)
        {
            _db.RemoveRange(t);
        }

        public IEnumerable<T> FindAll(string? IncludeProperties = null)
        {
          IQueryable<T> L=  dbset;
            if (IncludeProperties != null)
            {
                foreach (var property in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    L = L.Include(property);
                }
            }
                return (L);
        }

        public T GetFristOrDefault(Expression<Func<T, bool>> Filter , string? IncludeProperties = null)
        {
            
            IQueryable<T>  query = dbset;
            query = query.Where(Filter);
            if (IncludeProperties != null)
            {
                foreach (var property in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }

        public void Update(T entity)
        {
            _db.Update(entity); 
        }
    }
}
