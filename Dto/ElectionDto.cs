using VoteApp.Dto;

namespace VoteApp.Dto
{
    public class ElectionDto
    {
        public string Id { get; set; }
        public string ElectionName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ElectionDto> Elections { get; set; } = new HashSet<ElectionDto>();
        public ICollection<MemberDto> Members { get; set; } = new HashSet<MemberDto>();
    }

    public class CreateElectionRequestModel
    {
        public string ElectionName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateElectionRequestModel
    {
        public string ElectionName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
