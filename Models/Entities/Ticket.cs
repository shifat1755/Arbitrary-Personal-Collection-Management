namespace APCM.Models.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Summary { get; set; }
        public string? CollectionName {  get; set; }
        public string Priority { get; set; }
        public string UserEmail { get; set; }
        public Guid UserID { get; set; }
        public DateTime CreateDate { get; set; }
        
    }
}
