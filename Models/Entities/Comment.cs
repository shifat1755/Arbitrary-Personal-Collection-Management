using System.ComponentModel.DataAnnotations.Schema;

namespace APCM.Models.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string? Data { get; set; }
        public Guid ItemId {  get; set; }
        public Guid UserId { get; set; }
        public string firstName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
