using APCM.Data;
using APCM.Models;
using APCM.Models.Entities;
using APCM.Models.User;
using APCM.Services.CommonService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;

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

        public async Task<Response> UserExists(string email)
        {
            var response = new Response();
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
        public async Task<Response> DoSignUp(SignUpUserViewModel data)
        {

            var response = new Response();
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

        public async Task<Response> LoginUser(string email, string password)
        {
            var response = new Response();
            try
            {
                var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
                if (user.Password == _commonService.DoHashing(password))
                {
                    response.isSuccessful = true;
                    var claims=new List<Claim> {new Claim(ClaimTypes.) }
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

    }
}
