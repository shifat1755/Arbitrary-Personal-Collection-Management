namespace APCM.Models.Admin
{
    public class AdminViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DOB { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
