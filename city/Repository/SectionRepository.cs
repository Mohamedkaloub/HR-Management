using city.Data;
using city.Models;

namespace city.Repository
{
    public class SectionRepository : Repository<Section>
    {
        public ApplicationDbContext _db;
        public SectionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
