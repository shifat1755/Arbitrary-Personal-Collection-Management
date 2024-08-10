namespace APCM.Models.User
{
    public class SignUpUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DOB { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }


    }
}
