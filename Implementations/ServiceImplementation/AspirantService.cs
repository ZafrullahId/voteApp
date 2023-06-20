using voteApp.Interfaces.ServiceInterface;
using VoteApp.Dto;
using VoteApp.Dto.ResponseModel;
using VoteApp.Models.Entities;
using VoteApp.Repositories.Interface;

namespace Voting.Implementations.ServiceImplementation
{
    public class AspirantService : IAspirantService
    {
        private readonly IAspirantRepository _aspirantRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPositionRepository _positionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AspirantService(IAspirantRepository aspirantRepository, IWebHostEnvironment webHostEnvironment, IPositionRepository positionRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _aspirantRepository = aspirantRepository;
            _webHostEnvironment = webHostEnvironment;
            _positionRepository = positionRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> DeleteAspirant(string id)
        {
            var aspirant = await _aspirantRepository.Get(id);
            if (aspirant == null)
            {
                return false;
            }

            aspirant.IsDeleted = true;
            _aspirantRepository.Update(aspirant);
            await _aspirantRepository.Save();
            return true;
        }

        public async Task<BaseResponse<ICollection<AspirantDto>>> GetAllAspirant()
        {
            var aspirants = await _aspirantRepository.GetAll();
            if (aspirants == null)
            {
                return new BaseResponse<ICollection<AspirantDto>>
                {
                    Status = false,
                    Message = "Aspirants not found",
                };
            }
            return new BaseResponse<ICollection<AspirantDto>>
            {
                Status = true,
                Message = "Retrieved successfully",
                Data = aspirants.Select(a => new AspirantDto
                {
                    Id = a.Id,
                    NickName = a.NickName,
                    FirstName = a.User.FirstName, 
                    LastName = a.User.LastName,
                    Email = a.User.Email,
                    Image = a.User.Image,
                    PhoneNumber = a.User.PhoneNumber,
                    PositionName = a.Position.PositionName,
                    Gender = a.User.Gender,
                    DateOfBirth = a.User.DateOfBirth,
                }).ToList(),
            };
        }

        public async Task<BaseResponse<AspirantDto>> GetById(string id)
        {
            var aspirant = await _aspirantRepository.Get(id);
            if (aspirant == null)
            {
                return new BaseResponse<AspirantDto>
                {
                    Status = false,
                    Message = "Aspirant not found",
                };
            }
            return new BaseResponse<AspirantDto>
            {
                Status = true,
                Message = "Retrieved successfully",
                Data = new AspirantDto
                {
                    NickName = aspirant.NickName,
                    FirstName = aspirant.User.FirstName,
                    LastName = aspirant.User.LastName,
                    Email = aspirant.User.Email,
                    Image = aspirant.User.Image,
                    PhoneNumber = aspirant.User.PhoneNumber,
                    PositionName = aspirant.Position.PositionName,
                    Gender = aspirant.User.Gender,
                    DateOfBirth = aspirant.User.DateOfBirth,
                }
            };
        }

        public async Task<BaseResponse<AspirantDto>> GetByName(string name)
        {
            var aspirant = await _aspirantRepository.Get(name);
            if (aspirant == null)
            {
                return new BaseResponse<AspirantDto>
                {
                    Status = false,
                    Message = "Aspirant not found",
                };
            }
            return new BaseResponse<AspirantDto>
            {
                Status = true,
                Message = "Retrieved successfully",
                Data = new AspirantDto
                {
                    NickName = aspirant.NickName,
                    FirstName = aspirant.User.FirstName,
                    LastName = aspirant.User.LastName,
                    Email = aspirant.User.Email,
                    Image = aspirant.User.Image,
                    PhoneNumber = aspirant.User.PhoneNumber,
                    PositionName = aspirant.Position.PositionName,
                    Gender = aspirant.User.Gender,
                    DateOfBirth = aspirant.User.DateOfBirth,
                }
            };
        }

        public async Task<BaseResponse<AspirantDto>> RegisterAspirant(CreateAspirantModelRequest model)
        {
            var aspirantExist = await _aspirantRepository.Exist(a => a.NickName == model.NickName);
            if (aspirantExist)
            {
                return new BaseResponse<AspirantDto>
                {
                    Status = false,
                    Message = "Registration not successful, aspirant already exist",
                };
            }

            var image = "";
            if (model.Image != null)
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                Directory.CreateDirectory(path);
                var imageType = model.Image.ContentType.Split('/')[1];
                image = $"{Guid.NewGuid()}.{imageType}";
                var fullPath = Path.Combine(path, imageType);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }

            var position = new Position
            {
                PositionName = model.PositionName,
                Eligible = model.Eligible,
            };

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Image = image,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                AddressId = model.AddressId,
                ElectoralChairman = model.ElectoralChairman,
                Member = model.Member,
                Disability = model.Disability,
            };

            /*var role = await _aspirantRepository.Get("Aspirant");

            var roleUsers = new RoleUser
            {
                Role = role,
                RoleId = model.RoleId,
                User = user,
                UserId = model.UserId,
            };*/

            var aspirant = new Aspirant
            {
                NickName = model.NickName,
                UserId = model.User.Id,
                User = model.User,
                PositionId = model.Position.PositionId,
                Position = model.Position,
            };

            await _aspirantRepository.Add(aspirant);          
            await _aspirantRepository.Save();

            return new BaseResponse<AspirantDto>
            {
                Status = true,
                Message = "Registered Successfully",
                Data = new AspirantDto
                {
                    NickName = aspirant.NickName,
                    FirstName = aspirant.User.FirstName,
                    LastName = aspirant.User.LastName,
                    Email = aspirant.User.Email,
                    Image = aspirant.User.Image,
                    PhoneNumber = aspirant.User.PhoneNumber,
                    Gender = aspirant.User.Gender,
                    PositionName = aspirant.Position.PositionName,
                    DateOfBirth = aspirant.User.DateOfBirth,
                }
            };
        }

        public async Task<BaseResponse<AspirantDto>> UpdateAspirant(string id, UpdateAspirantRequestModel model) // Error coming from IAspirantServic(UpdateAspirantModelRequest)
        {
            var aspirant = await _aspirantRepository.Get(id);
            if (aspirant == null)
            {
                return new BaseResponse<AspirantDto>
                {
                    Status = false,
                    Message = "Aspirant not found",
                };
            }
            aspirant.NickName = model.NickName;
            aspirant.User.FirstName = model.FirstName;
            aspirant.User.LastName = model.LastName;
            aspirant.User.Email = model.Email;
            aspirant.User.Image = model.Image;
            aspirant.User.PhoneNumber = model.PhoneNumber;
            aspirant.Position.PositionName = model.PositionName;
            aspirant.User.Gender = model.Gender;
            aspirant.User.DateOfBirth = model.DateOfBirth;

            aspirant.IsDeleted = true;
            _aspirantRepository.Update(aspirant);
            await _aspirantRepository.Save();

            return new BaseResponse<AspirantDto>
            {
                Status = true,
                Message = "Updated successfully",
                Data = new AspirantDto
                {
                    Id = aspirant.Id,
                    NickName = aspirant.NickName,
                    FirstName = aspirant.User.FirstName,
                    LastName = aspirant.User.LastName,
                    Email = aspirant.User.Email,
                    Image = aspirant.User.Image,
                    PhoneNumber = aspirant.User.PhoneNumber,
                    PositionName = aspirant.Position.PositionName,
                    Gender = aspirant.User.Gender,
                    DateOfBirth = aspirant.User.DateOfBirth,
                }
            };
        }
    }
}
