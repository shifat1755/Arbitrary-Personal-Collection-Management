using APCM.Models.Entities;

namespace APCM.Models.Collection
{
    public class CollectionDetailsViewModel
    {
        public Entities.Collection Collection { get; set; }
        public ICollection<Item> Items { get; set; }=new List<Item>();
    }
}
