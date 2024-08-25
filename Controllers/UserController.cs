using APCM.Data;
using APCM.Models.Admin;
using APCM.Models.User;
using APCM.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCM.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
            _userService = userService;
        }

        public async Task<IActionResult> Index(string id)
        {
            Guid Id= Guid.Parse(id);
            var user = (await _userService.GetUser(Id)).Data;
            user.Password = null;

            return View(user);
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

        public async Task<IActionResult> Edit(string id)
        {
            Guid userId=Guid.Parse(id);
            var userData = (await _userService.GetUser(userId)).Data;
            var model = new EditUserViewModel()
            {
                Id = userData.Id,
                ProfileImage = userData.ProfileImage,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Email = userData.Email,
                Role = userData.Role,
                DOB = userData.DOB,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (model.Id.ToString() != User.FindFirst("Id").Value)
            {
                return View(model);
            }
            var response = await _userService.EditUser(model);
            return RedirectToAction("Index", "User",new { id = model.Id });
        }
        public async Task<IActionResult> Delete(string id)
        {
            string currUser =User.FindFirst("Id").Value;
            var response = await _userService.DeleteUser(id);
            if (currUser == id)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string prevUrl = Request.Headers["Referer"].ToString();
                return Redirect(prevUrl);
            }
        }
    }
}
