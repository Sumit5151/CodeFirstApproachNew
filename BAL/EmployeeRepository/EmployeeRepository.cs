using CodeFirstApproach.DAL;
using CodeFirstApproach.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.BAL.EmployeeRepository
{
    public class EmployeeRepository: IEmployeeRepository
    {

        private readonly ApplicationContext db;
        public EmployeeRepository(ApplicationContext _db)
        {
            this.db = _db;
        }


       public List<Department> GetAllDepartments()
        {
           var departments= db.Departments.ToList();
            return departments;
        }

        public void Save(EmployeeViewModel employeeViewModel)
        {
            Employee employee = new Employee();

          
            employee.Name = employeeViewModel.Name;
            employee.Email = employeeViewModel.Email;
            employee.DepartmentId = employeeViewModel.DepartmentId;


            db.Employees.Add(employee);
            db.SaveChanges();
        }





      public List<EmployeeViewModel> GetAllEmployees()
        {
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            List<Employee> employees= db.Employees.Include(emp=>emp.Department).ToList();

            foreach (var employee in employees)
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();

                employeeViewModel.Id = employee.Id;
                employeeViewModel.Name = employee.Name;
                employeeViewModel.Email = employee.Email;
                employeeViewModel.DepartmentId = employee.DepartmentId;
                employeeViewModel.DepartmentName = employee.Department.Name;
                

                employeeViewModels.Add(employeeViewModel);
            }
            return employeeViewModels;
        }

    }
}
