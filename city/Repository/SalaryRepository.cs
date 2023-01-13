using city.Data;
using city.Models;

namespace city.Repository
{
    public class SalaryRepository : Repository<Salary>
    {
        public ApplicationDbContext _db;
        public SalaryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
