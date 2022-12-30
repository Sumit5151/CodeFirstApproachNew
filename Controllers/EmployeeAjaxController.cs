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



        [HttpGet]
        public PartialViewResult LoadAllEmployess(int num)
        {
            List<EmployeeViewModel> employeeViewModels = employeeRepository.GetAllEmployees();

            return PartialView("_LoadAllEmployees", employeeViewModels);

        }



        [HttpGet]
        public PartialViewResult Create()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            @ViewBag.Departments = employeeRepository.GetAllDepartments();


            return PartialView("_Create", employeeViewModel);

        }


        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            employeeRepository.Save(employeeViewModel);

            return RedirectToAction("LoadAllEmployess");

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            employeeRepository.Delete(id);

            return RedirectToAction("LoadAllEmployess");

        }


    }
}
