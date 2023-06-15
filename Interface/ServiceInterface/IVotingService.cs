using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;

namespace voteApp.Interfaces
{
    public interface IVotingService
    {
        Task<BaseResponse<VotingDto>> RegisterVote(CreateVoteRequestModel model);
        Task<BaseResponse<VotingDto>> GetById(string id);
        Task<BaseResponse<ICollection<VotingDto>>> GetAll();
        Task<bool> DeleteVote(string id);
    }
}
