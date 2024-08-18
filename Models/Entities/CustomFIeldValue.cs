using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APCM.Models.Entities
{
    public class CustomFieldValue
    {
        public Guid Id { get; set; }
        public string? FieldName { get; set; }
        public string? Value { get; set; }
        public string? Type { get; set; }
        public Guid? ItemId { get; set; }
       
        [ForeignKey(nameof(ItemId))]
        public Item? Item { get; set; }
    }
}
