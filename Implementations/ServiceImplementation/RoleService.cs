using voteApp.Interfaces.ServiceInterface;
using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;

namespace Voting.Implementations.ServiceImplementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse<RoleDto>> CreateRole(CreateRoleRequestModel model)
        {
            var roleExist = await _roleRepository.Exist(r => r.Name == model.Name);
            if (roleExist)
            {
                return new BaseResponse<RoleDto>
                {
                    Status = false,
                    Message = "Role not found",
                };
            }

            var role = new Role
            {
                Name = model.Name,
            };

            await _roleRepository.Add(role);
            await _roleRepository.Save();

            return new BaseResponse<RoleDto>
            {
                Status = true,
                Message = "Created successful",
                Data = new RoleDto
                {
                    Name = model.Name,
                }
            };
        }

        public async Task<bool> DeleteRole(string roleId)
        {
            var role = await _roleRepository.Get(roleId);// Error From Role Repository(change int id to string Id)
            if (role == null)
            {
                return false;
            }
            role.IsDeleted = true;
            await _roleRepository.Update(role);
            await _roleRepository.Save();
            return true;
        }

        public async Task<BaseResponse<ICollection<RoleDto>>> GetAllRole()
        {
            var role = await _roleRepository.GetAll();
            if (role == null)
            {
                return new BaseResponse<ICollection<RoleDto>>
                {
                    Status = false,
                    Message = "Role not found",
                };
            }
            return new BaseResponse<ICollection<RoleDto>>
            {
                Status = true,
                Message = "Retrieved successful",
                Data = role.Select(r => new RoleDto
                {
                    Name = r.Name,
                }).ToList(),
            };
        }

        public async Task<BaseResponse<RoleDto>> GetById(string id)
        {
            var role = await _roleRepository.Get(id);// Error From Role Repository(change int id to string Id)
            if (role == null)
            {
                return new BaseResponse<RoleDto>
                {
                    Status = false,
                    Message = "Role not found",
                };
            }
            return new BaseResponse<RoleDto>
            {
                Status = true,
                Message = "Retrieved successful",
                Data = new RoleDto
                {
                    Name = role.Name,
                }
            };
        }

        public async Task<BaseResponse<RoleDto>> GetByName(string name)
        {
            var role = await _roleRepository.Get(name);//Error From Role Repository
            if (role == null)
            {
                return new BaseResponse<RoleDto>
                {
                    Status = false,
                    Message = "Role not found",
                };
            }
            return new BaseResponse<RoleDto>
            {
                Status = true,
                Message = "Retrieved successful",
                Data = new RoleDto
                {
                    Name = role.Name,
                }
            };
        }

        public async Task<BaseResponse<RoleDto>> UpdateRole(string id, UpdateRoleRequestModel model)
        {
            var role = await _roleRepository.Get(id);//Error From Role Repository(change int id to string Id)
            if (role == null)
            {
                return new BaseResponse<RoleDto>
                {
                    Status = false,
                    Message = "Role not found",
                };
            }
            role.Name = model.Name;

            role.IsDeleted = true;
            await _roleRepository.Update(role);
            await _roleRepository.Save();

            return new BaseResponse<RoleDto>
            {
                Status = true,
                Message = "Updated successful",
                Data = new RoleDto
                {
                    Name = role.Name,
                }
            };
        }
    }
}
