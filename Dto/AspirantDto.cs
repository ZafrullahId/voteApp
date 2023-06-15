using VoteApp.Dto;
using VoteApp.Models.Entities;
using VoteApp.Models.Enums;

namespace VoteApp.Dto
{
    public class AspirantDto
    {
        public string Id { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Disability Disability { get; set; }
        public string MemberName { get; set; }
        public int Plot { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PositionName { get; set; }
        public ICollection<RoleDto> Roles { get; set; } = new HashSet<RoleDto>();
    }
    public class CreateAspirantRequestModel
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Disability Disability { get; set; }
    }
    public class UpdateAspirantRequestModel
    {
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
