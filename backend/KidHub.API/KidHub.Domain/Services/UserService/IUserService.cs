using KidHub.Data.Entities;
using System.Threading.Tasks;
using KidHub.Domain.Dtos.IdentityDtos;

namespace KidHub.Domain.Services.UserService
{
    public interface IUserService
    {
        Task<ApplicationUser> RegisterAsync(RegisterDto dto);
        Task<ApplicationUser> LoginAsync(LoginDto dto);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
    }
}
