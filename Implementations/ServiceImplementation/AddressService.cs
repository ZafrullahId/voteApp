using static VoteApp.Dto.AddressDto;
using VoteApp.Dto.ResponseModel;
using VoteApp.Dto;
using VoteApp.Models.Entities;
using Voting.Repositories.Implementations;
using voteApp.Interfaces.ServiceInterface;
using VoteApp.Repositories.Interface;

namespace Voting.Implementations.ServiceImplementation
{
    public class AddressService : IAddress
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<bool> DeleteAddress(string id)
        {
            var address = await _addressRepository.Get(id);
            if (address == null)
            {
                return false;
            }
            address.IsDeleted = true;
            _addressRepository.Update(address);
            await _addressRepository.Save();
            return true;
        }

        public async Task<BaseResponse<ICollection<AddressDto>>> GetAllAddress()
        {
            var addresses = await _addressRepository.GetAll();
            if (addresses == null)
            {
                return new BaseResponse<ICollection<AddressDto>>
                {
                    Status = false,
                    Message = "Address not found"
                };
            }
            return new BaseResponse<ICollection<AddressDto>>
            {
                Status = true,
                Message = "Retrieved successful",
                Data = addresses.Select(a => new AddressDto
                {
                    Plot = a.Plot,
                    Street = a.Street,
                    State = a.State,
                    City = a.City,
                    Country = a.Country,
                }).ToList(),
            };
        }

        public async Task<BaseResponse<AddressDto>> GetById(string id)
        {
            var address = await _addressRepository.Get(id);
            if (address == null)
            {
                return new BaseResponse<AddressDto>
                {
                    Status = false,
                    Message = "Address not found",
                };
            }
            return new BaseResponse<AddressDto>
            {
                Status = true,
                Message = "Retrieved successful",
                Data = new AddressDto
                {
                    Plot = address.Plot,
                    Street = address.Street,
                    State = address.State,
                    City = address.City,
                    Country = address.Country,
                }
            };
        }

        public async Task<BaseResponse<AddressDto>> RegisterAddress(CreateAddressRequestModel model)
        {
            var addressExist = await _addressRepository.Exist(p => p.Country == model.Country);
            if (addressExist)
            {
                return new BaseResponse<AddressDto>
                {
                    Status = false,
                    Message = "Registration not successful, address already exist",
                };
            }

            var address = new Address
            {
                Plot = model.Plot,
                Street = model.Street,
                State = model.State,
                City = model.City,
                Country = model.Country,
            };
            await _addressRepository.Add(address);
            await _addressRepository.Save();

            return new BaseResponse<AddressDto>
            {
                Status = true,
                Message = "Registered Successfully",
                Data = new AddressDto
                {
                    Plot = address.Plot,
                    Street = address.Street,
                    State = address.State,
                    City = address.City,
                    Country = address.Country,
                }
            };
        }

        public async Task<BaseResponse<AddressDto>> UpdateAddress(string id, UpdateAddressRequestModel model)
        {
            var address = await _addressRepository.Get(id);
            if (address == null)
            {
                return new BaseResponse<AddressDto>
                {
                    Status = false,
                    Message = "Address not found",
                };
            }
            address.Plot = model.Plot;
            address.Street = model.Street;
            address.State = model.State;
            address.City = model.City;
            address.Country = model.Country;

            _addressRepository.Update(address);
            await _addressRepository.Save();

            return new BaseResponse<AddressDto>
            {
                Status = true,
                Message = "Updated successfully",
                Data = new AddressDto
                {
                    Plot = address.Plot,
                    Street = address.Street,
                    State = address.State,
                    City = address.City,
                    Country = address.Country,
                }
            };
        }
    }
}
