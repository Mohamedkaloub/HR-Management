using city.Data;
using city.Models;

namespace city.Repository
{
    public class EmployeeRepository : Repository<Employee>
    {
        public ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
