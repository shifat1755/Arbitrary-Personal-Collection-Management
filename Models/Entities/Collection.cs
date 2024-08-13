namespace APCM.Models.Entities
{
    public class Collection
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public ICollection<CustomField> CustomFields { get; set; } = new List<CustomField>();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

