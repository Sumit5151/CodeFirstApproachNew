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


        public IActionResult Home()
        {           
            return View();
        }


        public IActionResult Index()
        {
            HttpContext.Session.SetString("Message","This is Index view");        


            List<EmployeeViewModel> employeeViewModels = employeeRepository.GetAllEmployees();
            return View(employeeViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {

            var message = HttpContext.Session.GetString("Message");


            ViewBag.Departments = employeeRepository.GetAllDepartments();

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            return View("CreateEmployee", employeeViewModel);
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid == true)
            {
                employeeRepository.Save(employeeViewModel);

                TempData["Message"] = "New Employee Added successfully";
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
            TempData["Message"] = "Employee Updated successfully";
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            employeeRepository.Delete(id);
            TempData["Message"] = "Employee Deleted successfully";
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult IsEmailidIdInUse(string email)
        {
            var isEmailInUse = employeeRepository.IsEmailIdInUse(email);

            if (isEmailInUse == true)
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
