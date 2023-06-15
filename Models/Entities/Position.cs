using VoteApp.Models.Enums;

namespace VoteApp.Models.Entities
{
    public class Position : BaseEntity
    {
        public string PositionName { get; set; }
        public Eligibility Eligible { get; set; }
        public ICollection<Aspirant> Aspirants { get; set; }= new HashSet<Aspirant>();  
    }
}
