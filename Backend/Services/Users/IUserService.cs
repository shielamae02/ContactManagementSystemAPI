using Backend.Entities;
using Backend.Models.Auths;

namespace Backend.Services.Users
{
    public interface IUserService
    {
        Task<User> GetUser(User user);
        Task<int> GetUserId();
        Task<User> GetUserById(int id);
        //Task<User> AddUser(User newUser);
        Task<int> AddUser(User newUser);
        Task<bool> DeleteUser(int id);
        Task<User> UpdateUser(int id, UserRegisterDto updateUser);


    }
}
