using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Registeration()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Registeration()
        //{
        //    return View();
        //}
    }
}
