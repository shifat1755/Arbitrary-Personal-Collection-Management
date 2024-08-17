using System.ComponentModel.DataAnnotations.Schema;

namespace APCM.Models.Entities
{
    public class CustomFieldValue
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public Item Item { get; set; }
        public Guid CustomFieldId { get; set; }
        public string Value { get; set; }

        [ForeignKey(nameof(CustomFieldId))]
        public CustomField CustomField { get; set; }
    }
}
