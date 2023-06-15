using VoteApp.Models.Entities;

namespace VoteApp.Dto
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserDto> UserRoles { get; set; } = new HashSet<UserDto>();
    }

    public class CreateRoleRequestModel
    {
        public string Name { get; set; }
    }

    public class UpdateRoleRequestModel
    {
        public string Name { get; set; }
    }
}
