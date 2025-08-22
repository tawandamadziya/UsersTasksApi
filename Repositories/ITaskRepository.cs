using System.Collections.Generic;
using System.Threading.Tasks;
using UsersTasksAPI.Models;

namespace UsersTasksAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<List<UserTask>> GetAllTasks();
        Task<UserTask> GetTaskByTitle(string title);
        Task<bool> AddNewTask(UserTask task);
        Task<bool> UpdateTask(int id, UserTask updatedTask);
        Task<bool> DeleteTaskByTitle(string title);
    }
}
