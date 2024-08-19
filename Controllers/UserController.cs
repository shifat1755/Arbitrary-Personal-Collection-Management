using APCM.Models.User;
using APCM.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;

namespace APCM.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserViewModel data)
        {
            if (string.IsNullOrWhiteSpace(data.FirstName) || data.DOB == DateOnly.MinValue || string.IsNullOrWhiteSpace(data.Password) || string.IsNullOrWhiteSpace(data.RePassword))
            {
                return View();
            }
            else if (data.Password != data.RePassword)
            {
                ModelState.AddModelError("RePassword", "Password didn't match");
                return View();
            }

            else
            {
                var res = await _userService.UserExists(data.Email);
                if (res.isSuccessful)
                {
                    ModelState.AddModelError("Email", "An account with this email already exists");
                    return View();
                }
                var response = await _userService.DoSignUp(data);
                if (response.isSuccessful == true)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    Console.WriteLine(response.Message);
                    ModelState.AddModelError("Err", "500 Internal Server Error");
                    return View();
                }

            }
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel data)
        {
            if (string.IsNullOrWhiteSpace(data.Password))
            {
                ModelState.AddModelError("Password", "Password cannot be empty!");
                return View();
            }

            else
            {
                var response = await _userService.LoginUser(data.Email, data.Password);
                if (response.isSuccessful == false) {
                    ModelState.AddModelError("err", "Wrong credentials");
                    return View();
                }


                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Logout()
        {
            var response=await _userService.LogoutUser();

            return RedirectToAction("Index", "Home");
        }
    }
}
