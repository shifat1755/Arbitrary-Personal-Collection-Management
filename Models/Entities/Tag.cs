namespace APCM.Models.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> items { get; set; }=new List<Item>();
    }
}
