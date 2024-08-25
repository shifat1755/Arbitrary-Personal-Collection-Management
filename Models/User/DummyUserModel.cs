using APCM.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace APCM.Models.User
{
    public class DummyUserModel
    {
        public Guid Id { get; set; }
        public string? ProfileImage { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; } = false;
        public string Role { get; set; } = "User";
        public DateOnly DOB { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<DCollection>? Collections = new List<DCollection>();
    }
    public class DCollection
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public string Category { get; set; }
        public ICollection<DItem>? Items { get; set; } = new List<DItem>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class DItem
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CollectionId { get; set; }
        public string? Title { get; set; }
        public ICollection<DTag>? Tags { get; set; } = new List<DTag>();
        public ICollection<DComment>? Comments { get; set; } = new List<DComment>();
        public DateTime CreatedDate { get; set; }
    }
    public class DTag
    {
        public string Name { get; set; }

        public ICollection<DItem>? items { get; set; } = new List<DItem>();
    }
    public class DComment
    {
        public Guid Id { get; set; }
        public string? Data { get; set; }
        public Guid ItemId { get; set; }
        public Guid UserId { get; set; }
        public string firstName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
