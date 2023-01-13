using city.Data;
using city.Models;

namespace city.Repository.IRepository
{
    public class AttendanceRepository:Repository<Attendance>
    {
        public ApplicationDbContext _db;
        public AttendanceRepository(ApplicationDbContext db):base(db)
        {
            _db= db;
        }
    }
}
