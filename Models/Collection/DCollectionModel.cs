using APCM.Models.Entities;

namespace APCM.Models.Collection
{
    public class DCollectionModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public string Category { get; set; }
        public ICollection<DItem>? Items { get; set; } = new List<DItem>();
    }

    public class DItem
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CollectionId { get; set; }
        public string? Title { get; set; }
    }
}
