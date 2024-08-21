using System.ComponentModel.DataAnnotations;

namespace APCM.Models.Entities
{
    public class Tag
    {
        [Key]
        public string Name { get; set; }
        public ICollection<Item> items { get; set; }=new List<Item>();
    }
}
