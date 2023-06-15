using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;

namespace voteApp.Interfaces.ServiceInterface
{
    public interface IResultService
    {
        Task<BaseResponse<ResultDto>> RegisterResult(CreateResultRequestModel model);

        Task<BaseResponse<ResultDto>> GetById(string id);

        Task<BaseResponse<ICollection<ResultDto>>>GetAllResult();

        Task<BaseResponse<ResultDto>> UpdateById(string id, UpdateResultRequestModel model);

        Task<bool> DeleteById(string id);
    }
}
