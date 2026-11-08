using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SPM.Tourism.Api.Data;
using SPM.Tourism.Api.DTOs;
using SPM.Tourism.Api.Models;
namespace SPM.Tourism.Api.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            // Check whether the email is already registered
            bool emailExists = await _context.Users.AnyAsync(
                user => user.Email == request.Email);

            if (emailExists)
            {
                return false;
            }

            // Create a new user
            User newUser = new User
            {
                Email = request.Email
            };

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();

            newUser.PasswordHash = passwordHasher.HashPassword(
                newUser, request.Password);

            // Save the user
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<User?> LoginAsync(LoginRequest request)
        {
            // Find the user by email
            User? user = await _context.Users.FirstOrDefaultAsync(
                user => user.Email == request.Email);

            if (user == null)
            {
                return null;
            }

            // Verify the password hash
            var passwordHasher = new PasswordHasher<User>();

            var result = passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }
            // Return the authenticated user
            return user;
        }
    }
}