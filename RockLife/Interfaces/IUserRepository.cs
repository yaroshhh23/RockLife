using System.Collections.Generic;
using RockLife.Classes;

namespace RockLife.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserByIdAsync(int id);
        Task<List<User>> FindUsersByLoginAsync(string login);
    }
}