using KidHub.Data.Entities;
using KidHub.Domain.Services.UserService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using KidHub.Domain.Dtos.IdentityDtos;

namespace KidHub.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Register a new user
        public async Task<ApplicationUser> RegisterAsync(CreateUserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                // If registration is successful, return the created user
                return user;
            }

            throw new Exception("Failed to register user.");
        }

        // Login a user
        public async Task<ApplicationUser> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                throw new Exception("Invalid login attempt.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);

            if (result.Succeeded)
            {
                return user; // Return the user if login is successful
            }

            throw new Exception("Invalid login attempt.");
        }

        // Get a user by email
        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
