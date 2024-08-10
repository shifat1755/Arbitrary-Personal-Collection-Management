namespace APCM.Models.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Data { get; set; }
        public int ItemId {  get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
