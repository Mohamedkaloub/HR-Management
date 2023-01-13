using city.Data;
using city.Models;

namespace city.Repository
{
    public class AdvanceRepository : Repository<Advance>
    {
        public ApplicationDbContext _db;
        public AdvanceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
