using KidHub.Data.Data;
using KidHub.Data.Entities;
using KidHub.Data.Repositories.MainRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Data.Repositories.UserRepo
{
   public class UserRepository : Repository<User, Guid>, IUserRepository
    {

        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<User?> GetByEmailAndPasswordAsync(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
            return Task.FromResult(user);
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            return Task.FromResult(user);
        }
    }
}
