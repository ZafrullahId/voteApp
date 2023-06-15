using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;

namespace voteApp.Interfaces.ServiceInterface
{
    public interface IRoleService
    {
        Task<BaseResponse<RoleDto>> CreateRole(CreateRoleRequestModel model);

        Task<BaseResponse<RoleDto>> GetById(string id);

        Task<BaseResponse<RoleDto>> GetByName(string name);

        Task<BaseResponse<ICollection<RoleDto>>> GetAllRole();

        Task<BaseResponse<RoleDto>> UpdateRole(string id, UpdateRoleRequestModel model);

        Task<bool> DeleteRole(string roleId);
    }
}
