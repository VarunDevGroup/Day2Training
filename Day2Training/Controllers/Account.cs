using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Day2Training.Controllers
{
   
    [Authorize(Roles ="Admin,LegalHead,B,C,HRHead")]
    public class Account : Controller
    {
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
           // ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public IActionResult DeleteUser()
        {

            return View();
        }


        public IActionResult TerminateEMpl()
        {

            return View();
        }
        public IActionResult AccessDenied()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            //principal
            if (username == "admin" && password == "password")
            {
                // Create claims and sign in the user
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "Varun SHarma"),
                        new Claim(ClaimTypes.Role, "HR")
                    };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync("Cookies", claimsPrincipal);

                //return RedirectToAction("Index", "Home");

          
        }
            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }
    }
}
