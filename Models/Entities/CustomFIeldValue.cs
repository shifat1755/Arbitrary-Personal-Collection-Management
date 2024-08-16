using System.ComponentModel.DataAnnotations.Schema;

namespace APCM.Models.Entities
{
    public class CustomFIeldValue
    {
        public Guid Id { get; set; }
        public Guid CustomFieldId { get; set; }
        public string Value { get; set; }

        [ForeignKey(nameof(CustomFieldId))]
        public CustomField CustomField { get; set; }
    }
}
