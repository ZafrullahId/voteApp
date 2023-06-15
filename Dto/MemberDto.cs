using VoteApp.Dto;
using VoteApp.Models.Entities;
using VoteApp.Models.Enums;

namespace VoteApp.Dto
{
    public class MemberDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Disability Disability { get; set; }
        public ICollection<RoleDto> Roles { get; set; } = new HashSet<RoleDto>();
        public AspirantDto AspirantDto { get; set; }
        public ElectoralChairmanDto ElectoralChairmanDto { get; set; }
        public string MemberName { get; set; }
        public int Plot { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ElectionDto> Elections { get; set; } = new HashSet<ElectionDto>();
        public ICollection<MemberDto> Members { get; set; } = new HashSet<MemberDto>();
        public ICollection<AssociationDto> Associations { get; set; } = new HashSet<AssociationDto>();
    }

    public class CreateMemberRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Disability Disability { get; set; }
    }

    public class UpdateMemberRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Disability Disability { get; set; }
    }
}
