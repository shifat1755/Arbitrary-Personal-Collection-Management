namespace APCM.Models.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public int CollectionId { get; set; }
        public string? Title { get; set; }
        public string? Topic { get; set; }
        public string? Description { get; set; }
        public ICollection<HashTag> HashTags { get; set; } = new List<HashTag>();
        public DateTime CreatedDate { get; set; }
    }
}
