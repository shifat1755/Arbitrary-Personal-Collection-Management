using APCM.Models;
using APCM.Models.Entities;
using APCM.Models.User;

namespace APCM.Services.UserService
{
    public interface IUserService
    {
        public Task<Response<object>> DoSignUp(SignUpUserViewModel data);
        public Task<Response<object>> UserExists(string email);
        public Task<Response<object>> LoginUser(string email, string password);
        public Task<Response<object>> LogoutUser();
        public Task<Response<User>> GetUser(Guid id);
        public Task<Response<List<User>>> GetAllUser();

        public Task<Response<object>> EditUser(EditUserViewModel model);
        public Task<Response<object>> DeleteUser(string id);
    }
}
