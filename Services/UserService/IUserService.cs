using APCM.Models;
using APCM.Models.User;

namespace APCM.Services.UserService
{
    public interface IUserService
    {
        public Task<Response> DoSignUp(SignUpUserViewModel data);
        public Task<Response> UserExists(string email);
        public Task<Response> ValidateUser(string email, string password);

    }
}
