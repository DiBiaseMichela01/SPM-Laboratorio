using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SPM.Tourism.Api.DTOs;
using SPM.Tourism.Api.Data;
using SPM.Tourism.Api.Services;
using SPM.Tourism.Api.Models;
namespace SPM.Tourism.Api.Tests
{
    public class AuthServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task RegisterAsync_ValidUser_StoresHashedPassword()
        {
            using var connection = new SqliteConnection("Data Source=:memory:");
            RegisterRequest request = new RegisterRequest
            {
                Email = "test@example.com",
                Password = "Password123",
                ConfirmPassword = "Password123"
            };
            connection.Open();
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite(connection);
            using var context = new ApplicationDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();
            AuthService authService = new AuthService(context);
            bool response = await authService.RegisterAsync(request);
            Assert.That(response, Is.True);
            User? user = await context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            Assert.That(user, Is.Not.Null);
            Assert.That(user!.PasswordHash, Is.Not.Empty);
            Assert.That(user.PasswordHash, Is.Not.EqualTo(request.Password));
        }


        [Test]
        public async Task RegisterAsync_DuplicateEmail_ReturnsFalse()
        {
            // Arrange
            using var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite(connection);

            using var context = new ApplicationDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var authService = new AuthService(context);

            var request = new RegisterRequest
            {
                Email = "duplicate@example.com",
                Password = "Password123!",
                ConfirmPassword = "Password123!"
            };

            // Act
            bool firstRegistration = await authService.RegisterAsync(request);
            bool secondRegistration = await authService.RegisterAsync(request);

            // Assert
            Assert.That(firstRegistration, Is.True);
            Assert.That(secondRegistration, Is.False);
            Assert.That(await context.Users.CountAsync(), Is.EqualTo(1));
        }

        [Test]
        public async Task LoginAsync_ValidAndInvalidPassword_ReturnsExpectedResults()
        {
            // Arrange
            using var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite(connection);

            using var context = new ApplicationDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            var authService = new AuthService(context);

            var registration = new RegisterRequest
            {
                Email = "login-test@example.com",
                Password = "CorrectPassword123!",
                ConfirmPassword = "CorrectPassword123!"
            };

            bool registered = await authService.RegisterAsync(registration);

            // Act
            User? validUser = await authService.LoginAsync(
                new LoginRequest
                {
                    Email = "login-test@example.com",
                    Password = "CorrectPassword123!"
                });

            User? invalidUser = await authService.LoginAsync(
                new LoginRequest
                {
                    Email = "login-test@example.com",
                    Password = "WrongPassword123!"
                });

            // Assert
            Assert.That(registered, Is.True);
            Assert.That(validUser, Is.Not.Null);
            Assert.That(invalidUser, Is.Null);
        }

    }
}
