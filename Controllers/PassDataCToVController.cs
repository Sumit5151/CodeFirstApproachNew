using CodeFirstApproach.BAL.EmployeeRepository;
using CodeFirstApproach.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class PassDataCToVController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public PassDataCToVController(IEmployeeRepository _employeeRepository)
        {
            this.employeeRepository = _employeeRepository;
        }

        public IActionResult Index()
        {

            ViewData["FirstName"] = "Sanjay";
            ViewData["LastName"] = "Gandhi";

            ViewBag.Age = 20;
            ViewBag.Salary = 20000;




            EmployeeViewModel employeeVM = employeeRepository.GetEmployeeById(1008);
            ViewData["Employee"] = employeeVM;
            ViewBag.Employee = employeeVM;


            return View();
        }
    }
}
