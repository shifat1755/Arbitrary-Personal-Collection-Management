namespace APCM.Models.JiraTicket
{
    public class CreateTicketViewModel
    {
        public string? Summary { get; set; }
        public string PrevUrl {  get; set; }
        public string? CollectionName { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public string? UserEmail { get; set; }
        public Guid? UserID { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
