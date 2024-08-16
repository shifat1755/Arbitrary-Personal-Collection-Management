namespace APCM.Models.Entities
{
    public class HashTag
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public ICollection<Item> items { get; set; }=new List<Item>();
    }
}
