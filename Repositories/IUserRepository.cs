using System.Collections.Generic;
using System.Threading.Tasks;
using UsersTasksAPI.Models;

namespace UsersTasksAPI.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<bool> AddNewUser(User newUser);
        Task<bool> UpdateUser(User updatedUser);
        Task<bool> DeleteUserById(int id);
    }
}
