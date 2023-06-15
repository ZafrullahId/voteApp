using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;

namespace voteApp.Interfaces.ServiceInterface
{
    public interface IAssociationService
    {
        Task<BaseResponse<AssociationDto>> RegisterAssociation(CreateAssociationRequestModel model);

        Task<BaseResponse<AssociationDto>> Get(string id);

        Task<BaseResponse<AssociationDto>> GetByName(string name);

        Task<BaseResponse<ICollection<AssociationDto>>> GetAll();

        Task<BaseResponse<AssociationDto>> UpdateAssociation(string id, CreateAssociationRequestModel model);

        Task<bool> DeleteAssociation(string id);
        Task<bool> DeleteAssociations(string id);
    }
}
