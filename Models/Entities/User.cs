namespace APCM.Models.Entities
{
    public class User
    {
        
        public Guid Id { get; set; }
        public string? ProfileImage {  get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; } = false;
        public string Role { get; set; } = "User";
        public string? Password { get; set; }
        public DateOnly DOB { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;

        public ICollection<Collection>Collections=new List<Collection>();
    }
}
