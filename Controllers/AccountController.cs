using CodeFirstApproach.DAL;
using CodeFirstApproach.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class AccountController : Controller
    {

        private readonly ApplicationContext db;

        public AccountController(ApplicationContext _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            RegistrationViewModel registrationViewModel = new RegistrationViewModel();
            return View(registrationViewModel);
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid == true)
            {

                User user = new User();
                user.Email = registrationViewModel.Email;
                user.Password = registrationViewModel.Password;

                db.Users.Add(user);
                db.SaveChanges();

             return RedirectToAction("Index", "Employee");

            }

            return View(registrationViewModel);
        }




        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid == true)
            {

                var user = db.Users.FirstOrDefault(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);

                if (user != null)
                {
                    HttpContext.Session.SetString("email",user.Email);

                   return  RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is not valid");
                }
            }
            return View(loginViewModel);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction ("Home", "Employee");
        }
    }
}
