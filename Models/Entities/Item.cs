using System.ComponentModel.DataAnnotations.Schema;

namespace APCM.Models.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public Guid UserId {  get; set; }
        public Guid CollectionId { get; set; }

        [ForeignKey(nameof(CollectionId))]
        public Collection Collection { get; set; }
        public string? Title { get; set; }
        public ICollection<CustomFieldValue>CustomFieldValues { get; set; }=new List<CustomFieldValue>();
        public ICollection<HashTag> HashTags { get; set; } = new List<HashTag>();
        public DateTime CreatedDate { get; set; }
    }
}
