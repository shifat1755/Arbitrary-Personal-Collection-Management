using APCM.Data;
using APCM.Models;
using APCM.Models.Entities;
using APCM.Models.User;
using APCM.Services.CommonService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace APCM.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICommonService _commonService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(ApplicationDbContext dbContext, ICommonService commonService, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _commonService = commonService;
            _httpContextAccessor=httpContextAccessor;
        }

        public async Task<Response<object>> UserExists(string email)
        {
            var response = new Response<object>();
            var isExists = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (isExists == null)
            {
                response.isSuccessful = false;
            }
            else
            {
                response.isSuccessful = true;
            }
            return response;
        }
        public async Task<Response<object>> DoSignUp(SignUpUserViewModel data)
        {

            var response = new Response<object>();
            try
            {
                var user = new User
                {
                    FirstName = data.FirstName,
                    Email = data.Email,
                    DOB = data.DOB,
                    Password = _commonService.DoHashing(data.Password),

                };
                bool hasLastName = !string.IsNullOrWhiteSpace(data.LastName);
                if (hasLastName)
                {
                    user.LastName = data.LastName;
                }
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                response.isSuccessful = true;
                response.Message = "SignUp successful";
            }
            catch (Exception ex)
            {
                response.isSuccessful = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<object>> LoginUser(string email, string password)
        {
            var response = new Response<object>();
            try
            {
                var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
                if (user?.Password == _commonService.DoHashing(password))
                {
                    response.isSuccessful = true;
                    var claims = new List<Claim> { new Claim("Id", user.Id.ToString()), new Claim(ClaimTypes.Role, user.Role)};
                    var claimsIdentity= new ClaimsIdentity(claims,"pwd");
                    var cp=new ClaimsPrincipal(claimsIdentity);
                    await _httpContextAccessor.HttpContext.SignInAsync(cp);
                }
                else { 
                    response.isSuccessful = false;
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
            return response;
        }
        public async Task<Response<object>> LogoutUser()
        {
            var response = new Response<object>();
            try
            {
                await _httpContextAccessor.HttpContext.SignOutAsync();
                response.isSuccessful = true;

            }
            catch (Exception ex)
            {
                response.isSuccessful= false;
                Console.WriteLine($"{ex.Message}");
            }
            return response;
        }

    }
}
