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
            if (ModelState.IsValid == true)
            {
                employeeRepository.Save(employeeViewModel);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Departments = employeeRepository.GetAllDepartments();
                return View("CreateEmployee", employeeViewModel);
            }
        }



        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Departments = employeeRepository.GetAllDepartments();

            EmployeeViewModel employeeViewModel = employeeRepository.GetEmployeeById(id);

           

            return View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult Update(EmployeeViewModel employeeViewModel)
        {
            employeeRepository.Update(employeeViewModel);

            return RedirectToAction("Index");
        }


       
        public IActionResult Delete(int id)
        {
            employeeRepository.Delete(id);

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult IsEmailidIdInUse(string email)
        {
           var isEmailInUse=  employeeRepository.IsEmailidIdInUse(email);

            if(isEmailInUse == true)
            {
                return Json("This email id is already taken, Please use another Email id");
                
            }
            else
            {
                return Json(true);
            }
        }



        }
}
