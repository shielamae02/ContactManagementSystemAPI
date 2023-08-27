using Backend.Data;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.Users
{
    /// <summary>
    /// Repository for managing user data.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
            

        /// <inheritdoc/>
        public async Task<int> AddUser(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser.Id;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteUser(int id)
        {
            var db = _context.Users;
            var user = db.FirstOrDefault(c => c.Id == id);
            if (user is null)
            {
                return false;
            }

            db.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc/>
        public async Task<User?> GetUser(User user)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.EmailAddress == user.EmailAddress);
        }


        /// <inheritdoc/>
        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            return user!;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateUser(User updatedUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == updatedUser.Id);
            if (user is null)
            {
                throw new Exception("Error!");
                return false;
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.UserName = updatedUser.UserName;
            user.UpdatedAt = updatedUser.UpdatedAt;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
