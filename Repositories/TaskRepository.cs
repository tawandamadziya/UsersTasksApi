using Microsoft.EntityFrameworkCore;
using UsersTasksAPI.Models;

namespace UsersTasksAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserTask>> GetAllTasks()
        {
            return await _context.UserTasks.ToListAsync();
        }

        public async Task<UserTask> GetTaskByTitle(string title)
        {
            return await _context.UserTasks.FirstOrDefaultAsync(t => t.Title == title);
        }

        public async Task<bool> AddNewTask(UserTask task)
        {
            _context.UserTasks.Add(task);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateTask(int id, UserTask updatedTask)
        {
            var existingTask = await _context.UserTasks.FindAsync(id);
            if (existingTask == null)
                return false;

            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.Assignee = updatedTask.Assignee;
            existingTask.DueDate = updatedTask.DueDate;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTaskByTitle(string title)
        {
            var task = await _context.UserTasks.FirstOrDefaultAsync(t => t.Title == title);
            if (task == null)
                return false;

            _context.UserTasks.Remove(task);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
