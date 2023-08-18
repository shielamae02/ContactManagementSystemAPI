using Backend.Entities;
using Backend.Models.Auths;

namespace Backend.Services.Users
{
    /// <summary>
    /// Provides methods to manage user information within the system.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets a user from the system based on the provided user object.
        /// </summary>
        /// <param name="user">The user object used for retrieval.</param>
        /// <returns>User's information if found, otherwise null.</returns>
        Task<User> GetUser(User user);

        /// <summary>
        /// Gets the ID of the currently authenticated user.
        /// </summary>
        /// <returns>User's ID.</returns>
        Task<int> GetUserId();


        /// <summary>
        /// Gets a user based on the provided user ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>User information if found, otherwise null.</returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// Adds a new user to the system based on the provided user object.
        /// </summary>
        /// <param name="newUser">The new user object to add.</param>
        /// <returns>User ID of the added user.</returns>
        Task<int> AddUser(User newUser);

        /// <summary>
        /// Deletes a user from the system based on the provided user ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        Task<bool> DeleteUser(int id);

        /// <summary>
        /// Updates an existing user in the system with the provided user ID and information.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="updateUser">The updated user information.</param>
        /// <returns>User information if update is successful, otherwise null.</returns>
        Task<User> UpdateUser(int id, UpdateUserDto updateUser);
    }
}
