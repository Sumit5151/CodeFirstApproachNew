using CodeFirstApproach.DAL;
using CodeFirstApproach.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.BAL.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationContext db;
        private readonly IHttpContextAccessor httpContextAccessor;
        public EmployeeRepository(ApplicationContext _db, IHttpContextAccessor _httpContextAccessor)
        {
            this.db = _db;
            this.httpContextAccessor = _httpContextAccessor;
        }


        public List<Department> GetAllDepartments()
        {
            var departments = db.Departments.ToList();
            return departments;
        }

        public void Save(EmployeeViewModel employeeViewModel)
        {

            var message = httpContextAccessor.HttpContext.Session.GetString("Message");
            


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

            List<Employee> employees = db.Employees
                                         .Include(e => e.Department)
                                         .ToList();

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


        public EmployeeViewModel GetEmployeeById(int id)
        {
            Employee employee = db.Employees.FirstOrDefault(Employees => Employees.Id == id);

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            employeeViewModel.Id = employee.Id;
            employeeViewModel.Name = employee.Name;
            employeeViewModel.Email = employee.Email;
            employeeViewModel.DepartmentId = employee.DepartmentId;

            return employeeViewModel;

        }

        public void Update(EmployeeViewModel employeeViewModel)
        {

            Employee employee = db.Employees.FirstOrDefault(x => x.Id == employeeViewModel.Id);
            employee.Name = employeeViewModel.Name;
            employee.Email = employeeViewModel.Email;
            employee.DepartmentId = employeeViewModel.DepartmentId;
            db.SaveChanges();
        }


        public void Delete(int id)
        {

            Employee employee = db.Employees.FirstOrDefault(x => x.Id == id);

            db.Employees.Remove(employee);
            db.SaveChanges();
        }



        public bool IsEmailIdInUse(string email)
        {
            var isEmailInUse = db.Employees.Any(x => x.Email == email);
            return isEmailInUse;
        }
    }
}
