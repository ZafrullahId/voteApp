using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;

namespace voteApp.Interfaces.ServiceInterface
{
    public interface IAddress
    {
        Task<BaseResponse<AddressDto>> RegisterAddress(CreateAddressRequestModel model);

        Task<BaseResponse<AddressDto>> GetById(string id);

        Task<BaseResponse<ICollection<AddressDto>>> GetAllAddress();

        Task<BaseResponse<AddressDto>> UpdateAddress(string id, UpdateAddressRequestModel model);

        Task<bool> DeleteAddress(string id);
    }
}
