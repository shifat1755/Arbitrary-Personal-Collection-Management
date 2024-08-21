namespace APCM.Models.Item
{
    public class AddItemViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CollectionId { get; set; }
        public string? Title { get; set; }
        public ICollection<CustomFieldValueViewModel> CustomFieldValues { get; set; } = new List<CustomFieldValueViewModel>();
        public List<string> Tags { get; set; } = new List<string>();
        public List<string> AllTags { get; set; }= new List<string>();
        public bool isEdit { get; set; } = false;

    }
    public class CustomFieldValueViewModel { 
        public Guid Id { get; set; }
        public string? FieldName { get; set; }
        public string? Value { get; set; }
        public string? Type { get; set; }
    }
}
