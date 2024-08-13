namespace APCM.Models.Entities
{
    public class CustomField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public ICollection<Item> Items { get; set; }=new List<Item>();
    }
}