using city.Data;
using city.Models;

namespace city.Repository
{
    public class RetReasonRepository : Repository<RetReason>
    {
        public ApplicationDbContext _db;
        public RetReasonRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
