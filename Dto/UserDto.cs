using VoteApp.Models.Entities;
using VoteApp.Models.Enums;

namespace VoteApp.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
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
        public ICollection<AssociationDto> Associations { get; set; } = new HashSet<AssociationDto>();

    }

    public class LoginUserRequestModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class UpdateUserRequestModel
    {     
        public string Email { get; set; }
    }
}
