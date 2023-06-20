using VoteApp.Dto.ResponseModel;
using VoteApp.Dto;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;
using voteApp.Interfaces.ServiceInterface;

namespace Voting.Implementations.ServiceImplementation
{
    public class AssociationService : IAssociationService
    {
        private readonly IAssociationRepository _associationRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AssociationService(IAssociationRepository associationRepository, IWebHostEnvironment webHostEnvironment)
        {
            _associationRepository = associationRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> DeleteAssociation(string id)
        {
            var association = await _associationRepository.Get(id);
            if (association == null)
            {
                return false;
            }
            association.IsDeleted = true;
            _associationRepository.Update(association);
            await _associationRepository.Save();
            return true;
        }

        public Task<bool> DeleteAssociations(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<AssociationDto>> Get(string id)
        {
            var association = await _associationRepository.Get(id);
            if (association == null)
            {
                return new BaseResponse<AssociationDto>
                {
                    Status = false,
                    Message = "Association not found",
                };
            }

            return new BaseResponse<AssociationDto>
            {
                Status = true,
                Message = "Retrieved successful",
                Data = new AssociationDto
                {
                    Name = association.Name,
                    Description = association.Description,
                }
            };
        }

        public async Task<BaseResponse<ICollection<AssociationDto>>> GetAll()
        {
            var associations = await _associationRepository.GetAll();
            if (associations == null)
            {
                return new BaseResponse<ICollection<AssociationDto>>
                {
                    Status = false,
                    Message = "Associations not found",
                };
            }

            return new BaseResponse<ICollection<AssociationDto>>
            {
                Status = true,
                Message = "Retrieved successful",
                Data = associations.Select(a => new AssociationDto
                {
                    Name = a.Name,
                    Description = a.Description,
                }).ToList(),
            };
        }

        public async Task<BaseResponse<AssociationDto>> GetByName(string name)
        {
            var association = await _associationRepository.Get(name);
            if (association == null)
            {
                return new BaseResponse<AssociationDto>
                {
                    Status = false,
                    Message = "Association not found",
                };
            }
            return new BaseResponse<AssociationDto>
            {
                Status = true,
                Message = "Retrieved successful",
                Data = new AssociationDto
                {
                    Name = association.Name,
                    Description = association.Description,
                }
            };
        }

        public async Task<BaseResponse<AssociationDto>> RegisterAssociation(CreateAssociationRequestModel model)
        {
            var associationExist = await _associationRepository.Exist(a => a.Name == model.Name);
            if (associationExist)
            {
                return new BaseResponse<AssociationDto>
                {
                    Status = false,
                    Message = "Registration not successful, association already exist",
                };
            }

            var association = new Association
            {
                Name = model.Name,
                Description = model.Description,
            };

            return new BaseResponse<AssociationDto>
            {
                Status = true,
                Message = "Registered successfully",
                Data = new AssociationDto
                {
                    Name = model.Name,
                    Description = model.Description,
                }
            };
        }

        public async Task<BaseResponse<AssociationDto>> UpdateAssociation(string id, CreateAssociationRequestModel model)
        {
            var association = await _associationRepository.Get(id);
            if (association == null)
            {
                return new BaseResponse<AssociationDto>
                {
                    Status = false,
                    Message = "Association not found",
                };
            }
            association.Name = model.Name;
            association.Description = model.Description;

            association.IsDeleted = true;
            _associationRepository.Update(association);
            await _associationRepository.Save();

            return new BaseResponse<AssociationDto>
            {
                Status = true,
                Message = "Updated successfully",
                Data = new AssociationDto
                {
                    Name = model.Name,
                    Description = model.Description,
                }
            };
        }
    }
}
