namespace APCM.Models.Collection
{
    public class CreateCollectionViewModel
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public List<CustomFieldViewModel> CustomFields { get; set; } = new();
    }
    public class CustomFieldViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string? Value { get; set; }
    }
}
