using CodeFirstApproach.DAL;

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

            var departments = db.Departments.ToList();
            return departments;

        }



    }
}
