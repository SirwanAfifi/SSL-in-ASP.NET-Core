using Microsoft.AspNetCore.Mvc;

namespace testingSSL.Controllers
{
    //[RequireHttps]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return Content("Login Page");
        }
    }
}