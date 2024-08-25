using APCM.Data;
using APCM.Models.Admin;
using APCM.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCM.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserService _userService;

        public AdminController(ApplicationDbContext dbContext, IUserService userService) {
            _dbContext=dbContext;
            _userService=userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var users = await _dbContext.Users.Select(user => new AdminViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                Email = user.Email,
                IsEmailVerified = user.IsEmailVerified,
                Role = user.Role,
                CreatedAt = user.CreatedAt,
            }).ToListAsync();
            return View(users);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> PerformAction(string toDo, string id)
        {
            Guid Gid=Guid.Parse(id);
            if (toDo == "Admin" || toDo =="User")
            {
                var user=await _dbContext.Users.FirstOrDefaultAsync(u=>u.Id==Gid);
                user.Role=toDo;
                await _dbContext.SaveChangesAsync();
                if (id == User.FindFirst("Id").Value) {
                    _userService.LogoutUser();
                }
            }
            string prevUrl = Request.Headers["Referer"].ToString();
            return Redirect(prevUrl);
        }
    }
}
