using APCM.Models.Entities;

namespace APCM.Models.Collection
{
    public class CollectionDetailsViewModel
    {
        public Entities.Collection Collection { get; set; }
        public ICollection<Entities.Item> Items { get; set; }=new List<Entities.Item>();
    }
}
