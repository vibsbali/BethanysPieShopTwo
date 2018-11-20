using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await _userManager.FindByNameAsync(viewModel.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "User name/password not found");
            return View(viewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = viewModel.UserName
                };

                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
