namespace APCM.Models.Entities
{
    public class Collection
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public string Category { get; set; }
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public int ItemCount { get; set; }= 0;
        public ICollection<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

