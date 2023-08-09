using Backend.Entities;
using Backend.Models.Auths;

namespace Backend.Repositories.Users
{
    public interface IUserRepository
    {
        Task<int> AddUser(User newUser);
        Task<User?> GetUser(User user);
        Task<User> GetUserById(int id);
        Task<bool> UpdateUser(User updateUser);
        Task<bool> DeleteUser(int id);

        //Task<bool> GetUserDetails(UserRegisterDto request);
    }
}
