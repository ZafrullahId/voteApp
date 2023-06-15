using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;

namespace voteApp.Interfaces.ServiceInterface
{
    public interface IElectionService
    {
        Task<BaseResponse<ElectionDto>> RegisterElection(CreateElectionRequestModel model);

        Task<BaseResponse<ElectionDto>> GetById(string id);

        Task<BaseResponse<ElectionDto>> GetByName(string name);

        Task<BaseResponse<ICollection<ElectionDto>>> GetAllElection();

        Task<BaseResponse<ElectionDto>> UpdateElection(string id, UpdateElectionRequestModel model);

        Task<bool> DeleteElection(string id);
    }
}
