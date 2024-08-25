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
                    var claims = new List<Claim> { new Claim("Id", user.Id.ToString()), new Claim(ClaimTypes.Role, user.Role), new Claim("firstName",user.FirstName)};
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

        public async Task<Response<User>> GetUser(Guid id)
        {
            var response = new Response<User>();
            try
            {
                var data = await _dbContext.Users
                    .Include(i => i.Collections)
                    .ThenInclude(i => i.Items)
                    .FirstOrDefaultAsync(i => i.Id == id);
                response.isSuccessful = true;
                response.Data = data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                response.isSuccessful = false;
            }
            return response;
        }

        public async Task<Response<object>> EditUser(EditUserViewModel model)
        {
            var response = new Response<object>();
            try
            {
                var user= await _dbContext.Users.FindAsync(model.Id);
                user.FirstName=model.FirstName;
                user.LastName=model.LastName;
                user.Role = model.Role;
                user.DOB=model.DOB;
                await _dbContext.SaveChangesAsync();
                response.isSuccessful = true;
            }
            catch ( Exception ex)
            {
                    Console.WriteLine(ex.Message.ToString());
                    response.isSuccessful = false;

            }
                return response;
        }

        public async Task<Response<object>> DeleteUser(string id){
            var response = new Response<object>();
            try
            {
                Guid Gid=Guid.Parse(id);
                var user=await _dbContext.Users.FindAsync(Gid);
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                response.isSuccessful = true;
            }
            catch (Exception ex) { 
            Console.WriteLine(ex.Message.ToString());
                response.isSuccessful = false;
            }
            return response;
        }

        public async Task<Response<List<User>>> GetAllUser()
        {
            var response = new Response<List<User>>();
            try
            {
                var data = await _dbContext.Users.ToListAsync();
                response.Data=data;
                response.isSuccessful = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                response.isSuccessful = false;
            }
            return response;
        }


    }
}
