using city.Data;
using city.Models;

namespace city.Repository
{
    public class DepartmentRepository : Repository<Department>
    {
        public ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
