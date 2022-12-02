using CodeFirstApproach.DAL;
using CodeFirstApproach.ViewModels;

namespace CodeFirstApproach.BAL.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        List<Department> GetAllDepartments();
        void Save(EmployeeViewModel employeeViewModel);
        List<EmployeeViewModel> GetAllEmployees();

        EmployeeViewModel GetEmployeeById(int id);
        void Update(EmployeeViewModel employeeViewModel);
        void Delete(int id);


    }
}
