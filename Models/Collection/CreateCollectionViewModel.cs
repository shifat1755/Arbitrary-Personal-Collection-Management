namespace APCM.Models.Collection
{
    public class CreateCollectionViewModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public string? Category { get; set; }

        public string? CustomInt1 { get; set; }
        public int? CustomInt1Val { get; set; }
        public string? CustomInt2 { get; set; }
        public int? CustomInt2Val { get; set; }
        public string? CustomInt3 { get; set; }
        public int? CustomInt3Val { get; set; }
        public int CustomIntFieldCount  { get; set; }

        public string? CustomString1 { get; set; }
        public string? CustomString1Val { get; set; }
        public string? CustomString2 { get; set; }
        public string? CustomString2Val { get; set; }
        public string? CustomString3 { get; set; }
        public string? CustomString3Val { get; set; }
        public int CustomStringFieldCount { get; set; }


        public string? MultileineText1 { get; set; }
        public string? MultilineText1Val { get; set; }
        public string? MultilineText2 { get; set; }
        public string? MultilineText2Val { get; set; }
        public string? MultilineText3 { get; set; }
        public string? MultilineText3Val { get; set; }
        public int CustomMultilineTextFieldCount {  get; set; }

        public string? DateField1 { get; set; }
        public DateOnly? DateField1Val { get; set; }
        public string? DateField2 { get; set; }
        public DateOnly? DateField2Val { get; set; }
        public string? DataField3 { get; set; }
        public DateOnly? DateField3Val { get; set; }
        public int CustomDateFieldCount {  get; set; }

        public String? BoolField1 { get; set; }
        public bool BoolField1Val { get; set; }
        public String? BoolField2 { get; set; }
        public bool BoolField2Val { get; set; }
        public string? BoolField3 { get; set; }
        public bool BoolField3Val { get; set; }
        public int CustomBoolFieldCount { get; set; }

    }
}
