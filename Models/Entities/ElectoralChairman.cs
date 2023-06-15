namespace VoteApp.Models.Entities
{
    public class ElectoralChairman :BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
