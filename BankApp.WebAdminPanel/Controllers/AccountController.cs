using BankApp.Core.Domain.Entities;
using BankApp.WebAdminPanel.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebAdminPanel.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult sil(int id)
        {
            return Content("id = "+ id);
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var user = userManager.FindByNameAsync(model.Email).Result;

            if (user == null)
                return Content("Username or password is incorrect");

             var signInResult = signInManager.PasswordSignInAsync(user, model.Password, true, false).Result;

            if (signInResult.Succeeded)
                return RedirectToAction("Index", "Exchange");

            return Content("Username or password is incorrect");

            return View();
        }

        public IActionResult AccessDenied()
        {
            return Content("you have no any access for this page");
        }


        public IActionResult Logout()
        {
            signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
