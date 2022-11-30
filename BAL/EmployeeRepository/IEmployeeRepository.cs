using CodeFirstApproach.DAL;

namespace CodeFirstApproach.BAL.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        List<Department> GetAllDepartments();
    }
}
