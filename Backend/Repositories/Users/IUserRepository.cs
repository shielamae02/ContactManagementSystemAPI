using Backend.Entities;
using Backend.Models.Auths;

namespace Backend.Repositories.Users
{
    /// <summary>
    /// Provides methods for user operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Adds a new user to the system based on the provided user object
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>Id of the new user</returns>
        Task<int> AddUser(User newUser);

        /// <summary>
        /// Gets a user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User details</returns>
        Task<User?> GetUser(User user);

        /// <summary>
        /// Gets a user based on the provided user ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User details</returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// Updates an existing user in the system with the provided user information.
        /// </summary>
        /// <param name="updateUser"></param>
        /// <returns>A boolean indicating the success or failure of the update operation.</returns>
        Task<bool> UpdateUser(User updateUser);

        /// <summary>
        /// Deletes a user from the system based on the provided user ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A boolean indicating the success or failure of the delete operation.</returns>
        Task<bool> DeleteUser(int id);
    }
}
