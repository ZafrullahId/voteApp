namespace VoteApp.Models.Entities
{
    public class Election : BaseEntity
    {
        public string ElectionName { get; set; }
        
        public int AssociationId { get; set; }
        public Association Association { get; set; }
       
    }
}
