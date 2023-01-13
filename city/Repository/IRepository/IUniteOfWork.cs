namespace city.Repository.IRepository
{
    public interface IUniteOfWork
    {
        public EmployeeRepository EmployeeRepository { get; }
        public DepartmentRepository DepartmentRepository { get; }
        public ManagementRepository ManagementRepository { get; }
        public JobRepository JobRepository { get; }
        public RetReasonRepository RetReasonRepository { get; }
        public SalaryRepository SalaryRepository { get; }
        public SectionRepository SectionRepository { get; }
        public AttendanceRepository AttendanceRepository { get; }
        public AdvanceRepository AdvanceRepository { get; }
        public void Save();
      
    }
}
