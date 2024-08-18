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
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<Like> Likes { get; set; }= new List<Like>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public DateTime CreatedDate { get; set; }
    }
}
