using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;

namespace voteApp.Interfaces.ServiceInterface
{
    public interface IAspirantService
    {
        Task<BaseResponse<AspirantDto>> RegisterAspirant(CreateAspirantModelRequest model);

        Task<BaseResponse<AspirantDto>> GetById(string id);

        Task<BaseResponse<AspirantDto>> GetByName(string name);

        Task<BaseResponse<ICollection<AspirantDto>>> GetAllAspirant();

        Task<BaseResponse<AspirantDto>> UpdateAspirant(string id, UpdateAspirantModelRequest model);

        Task<bool> DeleteAspirant(string id);
    }
}
