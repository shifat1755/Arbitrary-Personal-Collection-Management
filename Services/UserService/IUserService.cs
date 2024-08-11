using APCM.Models;
using APCM.Models.User;

namespace APCM.Services.UserService
{
    public interface IUserService
    {
        public Task<Response> DoSignUp(SignUpUserViewModel data);
        public Task<Response> UserExists(string email);
        public Task<Response> LoginUser(string email, string password);
        //public Task<Response> EditProfile(SignUpUserViewModel data);
        //public Task<Response> DeleteUser(string email, string password);
    }
}
