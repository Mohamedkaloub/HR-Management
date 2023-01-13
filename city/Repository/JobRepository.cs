using city.Data;
using city.Models;

namespace city.Repository
{
    public class JobRepository : Repository<Job>
    {
        public ApplicationDbContext _db;
        public JobRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
