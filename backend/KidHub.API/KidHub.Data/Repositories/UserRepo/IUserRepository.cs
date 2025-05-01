using KidHub.Data.Entities;
using KidHub.Data.Repositories.MainRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Data.Repositories.UserRepo
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        // Define user-specific methods here
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByEmailAndPasswordAsync(string email, string password);
    }
}
