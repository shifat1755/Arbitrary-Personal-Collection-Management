using System.ComponentModel.DataAnnotations.Schema;

namespace APCM.Models.Entities
{
    public class CustomField
    {
        public Guid Id { get; set; }
        public Guid CollectionId { get; set; }

        [ForeignKey(nameof(CollectionId))]
        public Collection Collection { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}