using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;

namespace voteApp.Interfaces.ServiceInterface
{
    public interface IMemberService
    {
        Task<BaseResponse<MemberDto>> CreateMember(CreateMemeberRequestModel model);

        Task<BaseResponse<MemberDto>> GetById(string id);

        Task<BaseResponse<MemberDto>> GetByName(string id);

        Task<BaseResponse<ICollection<MemberDto>>> GetAllMember();

        Task<BaseResponse<MemberDto>> UpdateMember(string id, UpdateMemberRequestModel model);

        Task<bool> DeleteMember(string id);
    }
}
