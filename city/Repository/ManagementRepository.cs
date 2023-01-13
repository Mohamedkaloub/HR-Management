using city.Data;
using city.Models;

namespace city.Repository
{
    public class ManagementRepository : Repository<Management>
    {
        public ApplicationDbContext _db;
        public ManagementRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
