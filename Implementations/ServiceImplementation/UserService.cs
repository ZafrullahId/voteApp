using voteApp.Interfaces.ServiceInterface;
using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;
using VoteApp.Models.Enums;
using VoteApp.Repositories.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace Voting.Implementations.ServiceImplementation
{
    public class UserService : IUserService// Error From IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _userRepository.Get(id);// Error From IUserRepository(change int id to string id)
            if (user == null)
            {
                return false;
            }
            user.IsDeleted = true;
            await _userRepository.Update(user);
            await _userRepository.Save();
            return true;
        }

        public async Task<BaseResponse<ICollection<UserDto>>> GetAllUser()
        {
            var user = await _userRepository.GetAll();
            if (user == null)
            {
                return new BaseResponse<ICollection<UserDto>>
                {
                    Status = false,
                    Message = "User not found",
                };
            }

            return new BaseResponse<ICollection<UserDto>>
            {
                Status = true,
                Message = "Retrieved successful",
                Data = user.Select(u => new UserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Gender = u.Gender,
                    DateOfBirth = u.DateOfBirth,
                }).ToList(),
            };
        }

        public async Task<BaseResponse<UserDto>> GetById(string id)
        {
            var user = await _userRepository.Get(id);// Error From IUserRepository(change int id to string id)
            if(user == null)
            {
                return new BaseResponse<UserDto>
                {
                    Status = false,
                    Message = "User not found",
                };
            }

            return new BaseResponse<UserDto>
            {
                Status = true,
                Message = "Retrieved successful",
                Data = new UserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Image = user.Image,
                    PhoneNumber = user.PhoneNumber,
                    Gender = user.Gender,
                    DateOfBirth = user.DateOfBirth,
                }
            };
        }

        public async Task<BaseResponse<UserDto>> GetByName(string name)
        {
            var user = await _userRepository.Get(name);// Error From IUserRepository(change int id to string id)
            if(user == null)
            {
                return new BaseResponse<UserDto>
                {
                    Status = false,
                    Message = "User not found",
                };
            }

            return new BaseResponse<UserDto>
            {
                Status = true,
                Message = "Retrieved successful",
                Data = new UserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Image = user.Image,
                    PhoneNumber = user.PhoneNumber,
                    Gender = user.Gender,
                    DateOfBirth = user.DateOfBirth,
                }
            };
        }

        public async Task<BaseResponse<UserDto>> LogIn(LoginUserRequestModel model)// Error From IUserService
        {
            var user = await _userRepository.Get(u => u.Email == model.Email && u.Password == model.Password);
            if (user == null)
            {
                return new BaseResponse<UserDto>
                {
                    Status = false,
                    Message = "User not found",
                };
            }

            return new BaseResponse<UserDto>
            {
                Status = true,
                Message = "Login successful",
                Data = new UserDto
                {
                    Email = user.Email,
                }
            };
        }

        public Task<BaseResponse<UserDto>> RegisterUser(CreateUserRequestModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<UserDto>> UpdateUser(string id, UpdateUserRequestModel model)
        {
            var user = await _userRepository.Get(id);// Error From IUserRepository(change int id to string id)
            if(user == null)
            {
                return new BaseResponse<UserDto>
                {
                    Status = false,
                    Message = "User not found",
                };
            }

            user.FirstName = user.FirstName;
            user.LastName = user.LastName;
            user.Email = user.Email;
            user.Image = user.Image;
            user.PhoneNumber = user.PhoneNumber;
            user.Gender = user.Gender;
            user.DateOfBirth = user.DateOfBirth;

            user.IsDeleted = true;
            await _userRepository.Update(user);
            await _userRepository.Save();

            return new BaseResponse<UserDto>
            {
                Status = true,
                Message = "Updated successful",
                Data = new UserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Image = user.Image,
                    PhoneNumber = user.PhoneNumber,
                    Gender = user.Gender,
                    DateOfBirth = user.DateOfBirth,
                }
            };
        }
    }
}
