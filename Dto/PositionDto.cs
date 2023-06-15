using VoteApp.Models.Entities;
using VoteApp.Models.Enums;

namespace VoteApp.Dto
{
    public class PositionDto
    {
        public string Id { get; set; }
        public string PositionName { get; set; }
        public Eligibility Eligible { get; set; }
        public ICollection<AspirantDto> Aspirants { get; set; } = new HashSet<AspirantDto>();
    }

    public class CreatePositionRequestModel
    {
        public string PositionName { get; set; }
        public Eligibility Eligible { get; set; }
    }

    public class UpdatePositionRequestModel
    {
        public string PositionName { get; set; }
        public Eligibility Eligible { get; set; }
    }
}
