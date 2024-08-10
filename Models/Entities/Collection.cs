namespace APCM.Models.Entities
{
    public class Collection
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public ICollection<Item> Items { get; set; } = new List<Item>();

        public string? CustomInt1 { get; set; }
        public int? CustomInt1Val { get; set; }
        public string? CustomInt2 { get; set; }
        public int? CustomInt2Val { get; set; }
        public string? CustomInt3 { get; set; }
        public int? CustomInt3Val { get; set; }
        public int CustomIntFieldCount { get; set; } = 0;

        public string? CustomString1 { get; set; }
        public string? CustomString1Val { get; set; }
        public string? CustomString2 { get; set; }
        public string? CustomString2Val { get; set; }
        public string? CustomString3 { get; set; }
        public string? CustomString3Val { get; set; }
        public int CustomStringFieldCount { get; set; } = 0;


        public string? CustomMultileineText1 { get; set; }
        public string? CustomMultilineText1Val { get; set; }
        public string? CustomMultilineText2 { get; set; }
        public string? CustomMultilineText2Val { get; set; }
        public string? CustomMultilineText3 { get; set; }
        public string? CustomMultilineText3Val { get; set; }
        public int CustomMultilineTextFieldCount { get; set; }

        public string? CustomDateField1 { get; set; }
        public DateOnly? CustomDateField1Val { get; set; }
        public string? CustomDateField2 { get; set; }
        public DateOnly? CustomDateField2Val { get; set; }
        public string? CustomDataField3 { get; set; }
        public DateOnly? CustomDateField3Val { get; set; }
        public int CustomDateFieldCount { get; set; }=0;


        public String? CustomBoolField1 { get; set; }
        public bool CustomBoolField1Val { get; set; } = false;
        public String? CustomBoolField2 { get; set; }
        public bool CustomBoolField2Val { get; set; } = false;
        public string? CustomBoolField3 { get; set; }
        public bool CustomBoolField3Val { get; set; } = false;
        public int CustomBoolFieldCount { get; set; } = 0;

    }
}
