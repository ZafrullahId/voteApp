using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;

namespace voteApp.Interfaces.ServiceInterface
{
    public interface IUserService
    {
        Task<BaseResponse<UserDto>> RegisterUser(CreateUserRequestModel model);

        Task<BaseResponse<UserDto>> GetById(string id);

        Task<BaseResponse<UserDto>> GetByName(string name);

        Task<BaseResponse<ICollection<UserDto>>> GetAllUser();

        Task<BaseResponse<UserDto>> UpdateUser(string id, UpdateUserRequestModel model);
        Task<BaseResponse<UserDto>> LogIn(string email, string password)

        Task<bool> DeleteUser(string id);
    }
}
