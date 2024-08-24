namespace APCM.Models.User
{
    public class EditUserViewModel
    {
        public Guid Id { get; set; }
        public string? ProfileImage { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateOnly DOB { get; set; }
    }
}
