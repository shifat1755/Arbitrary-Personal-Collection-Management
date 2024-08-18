using System.ComponentModel.DataAnnotations.Schema;

namespace APCM.Models.Entities
{
    public class Like
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public Item Item { get; set; }
        public Guid UserId { get; set; }
    }
}
