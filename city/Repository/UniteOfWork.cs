using city.Data;

namespace city.Repository.IRepository
{
    public class UniteOfWork : IUniteOfWork
    {
        public EmployeeRepository EmployeeRepository { get; private set; }
        public JobRepository JobRepository { get; private set; }
        public DepartmentRepository DepartmentRepository { get; private set; }  
        public ManagementRepository ManagementRepository { get; private set; }
        public RetReasonRepository RetReasonRepository { get; private set; }
        public SalaryRepository SalaryRepository { get; private set;}
        public AttendanceRepository AttendanceRepository { get; private set; }  
        public AdvanceRepository AdvanceRepository { get; private set; }
        public SectionRepository SectionRepository { get; private set; }
        private readonly ApplicationDbContext _db;
        public UniteOfWork(ApplicationDbContext db)
        {
            _db = db;
            EmployeeRepository = new EmployeeRepository(_db);
            JobRepository = new JobRepository(_db);
            DepartmentRepository = new DepartmentRepository(_db);
            ManagementRepository = new ManagementRepository(_db);
            RetReasonRepository = new RetReasonRepository(_db);
            SalaryRepository = new SalaryRepository(_db);   
            AttendanceRepository = new AttendanceRepository(_db);
            AdvanceRepository =new AdvanceRepository(_db);
            SectionRepository = new SectionRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
       
    }
}
