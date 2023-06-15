using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;

namespace voteApp.Interfaces.ServiceInterface
{
    public interface IPositionInterface
    {
        Task<BaseResponse<PositionDto>> RegisterPosition(CreatePositionRequestModel model);

        Task<BaseResponse<PositionDto>> GetById(string id);

        Task<BaseResponse<PositionDto>> GetBYName(string name);

        Task<BaseResponse<ICollection<PositionDto>>> GetAllPosition();

        Task<BaseResponse<PositionDto>> UpdatePosition(string id, UpdatePositionRequestModel model);

        Task<bool> DeletePosition(string id);
    }
}
