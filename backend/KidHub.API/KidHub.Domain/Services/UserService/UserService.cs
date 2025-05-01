using AutoMapper;
using KidHub.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidHub.Data.Repositories.UserRepo;
using KidHub.Data.Entities;

namespace KidHub.Domain.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.Id = Guid.NewGuid(); // Optional if your DB handles this
            await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(user);
        }
        

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id); 
            return user == null ? null : _mapper.Map<UserDto>(user);
        }
    }
}
