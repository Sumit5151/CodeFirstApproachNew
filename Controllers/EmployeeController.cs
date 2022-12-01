using CodeFirstApproach.BAL.EmployeeRepository;
using CodeFirstApproach.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            this.employeeRepository = _employeeRepository;
        }





        public IActionResult Index()
        {
            List<EmployeeViewModel> employeeViewModels = employeeRepository.GetAllEmployees();



            return View(employeeViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = employeeRepository.GetAllDepartments();



            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            return View("CreateEmployee",employeeViewModel);
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            employeeRepository.Save(employeeViewModel);

            return RedirectToAction("Index");
        }






    }
}
