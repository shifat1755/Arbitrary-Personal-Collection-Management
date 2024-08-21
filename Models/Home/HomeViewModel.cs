using APCM.Models.Entities;

namespace APCM.Models.Home
{
    public class HomeViewModel
    {
        public List<Entities.Collection> RecentCollections { get; set; }
        public List<Entities.Collection> LargestCollections { get; set; }
        public List<Tag> hashTags { get; set; }
    }
}
