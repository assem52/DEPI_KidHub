using KidHub.Domain.Dtos;
using KidHub.Data.Entities;
using System.Threading.Tasks;

namespace KidHub.Domain.Services.UserService
{
    public interface IUserService
    {
        Task<ApplicationUser> RegisterAsync(CreateUserDto dto);
        Task<ApplicationUser> LoginAsync(LoginDto dto);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
    }
}
