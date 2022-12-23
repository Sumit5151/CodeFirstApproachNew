using CodeFirstApproach.BAL.EmployeeRepository;
using CodeFirstApproach.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class EmployeeAjaxController : Controller
    {

        private readonly IEmployeeRepository employeeRepository;
        public EmployeeAjaxController(IEmployeeRepository _employeeRepository)
        {
            this.employeeRepository = _employeeRepository;

        }


        public IActionResult Index()
        {
            return View();
        }




        public IActionResult LoadAllEmployess()
        {
            List<EmployeeViewModel> employeeViewModels = employeeRepository.GetAllEmployees();

            return PartialView("_LoadAllEmployees", employeeViewModels);
            
        }


    }
}
