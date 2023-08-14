using Backend.Entities;
using Backend.Models.Auths;

namespace Backend.Services.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Gets a user from the system based on the provided user object.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User's information</returns>
        Task<User> GetUser(User user);

        /// <summary>
        /// Gets a user's ID 
        /// </summary>
        /// <returns>User Id</returns>
        Task<int> GetUserId();


        /// <summary>
        /// Gets a user based on the provided user ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User information</returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// Adds a new user to the system based on the provided user object
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>User Id</returns>
        Task<int> AddUser(User newUser);

        /// <summary>
        /// Deletes a user from the system based on the provided user ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A boolean indicating the success or failure of the delete operation.</returns>
        Task<bool> DeleteUser(int id);

        /// <summary>
        /// Updates an existing user in the system with the provided user id and information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUser"></param>
        /// <returns>User information</returns>
        Task<User> UpdateUser(int id, UserRegisterDto updateUser);


    }
}
