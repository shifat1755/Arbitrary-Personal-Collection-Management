using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APCM.Models.Entities
{
    public class Tag
    {
        [Key]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Item> items { get; set; }=new List<Item>();
    }
}
