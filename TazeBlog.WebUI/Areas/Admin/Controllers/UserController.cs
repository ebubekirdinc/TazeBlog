using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TazeBlog.Business.Abstract;
using TazeBlog.Core.Utilities.Abstract;
using TazeBlog.Entities.ComplexTypes;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private ICryptoService _cryptoService;
        public UserController(IUserService userService, ICryptoService cryptoService)
        {
            _userService = userService;
            _cryptoService = cryptoService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
          
            if (_userService.Count() == 0)
            {
                var saltCode = _cryptoService.CreateSalt(10);
                var hashedPassword = _cryptoService.Encrypt("12345", saltCode);

                _userService.Add(new Entities.Concrete.User
                {
                    Username = "admin",
                    Email ="admin@tazebt.com",
                    Password = hashedPassword,
                    SaltCode = saltCode
                });
            }

            User user = _userService.Get("Username='" + loginModel.Username + "'");
            if (user != null)
            {
                if (_userService.PasswordCheck(user, loginModel.Password))
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,user.Username),
                        new Claim(ClaimTypes.Email,user.Email)
                    };

                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "User");
        }
    }
}