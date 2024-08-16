﻿using APCM.Models;
using APCM.Models.User;

namespace APCM.Services.UserService
{
    public interface IUserService
    {
        public Task<Response<object>> DoSignUp(SignUpUserViewModel data);
        public Task<Response<object>> UserExists(string email);
        public Task<Response<object>> LoginUser(string email, string password);
        public Task<Response<object>> LogoutUser();
        //public Task<Response> EditProfile(SignUpUserViewModel data);
        //public Task<Response> DeleteUser(string email, string password);
    }
}
