using Microsoft.AspNetCore.Mvc;
using UsersTasksAPI.Models;
using UsersTasksAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UsersTasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserTask>>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<UserTask>> GetTaskByTitle(string title)
        {
            var task = await _taskRepository.GetTaskByTitle(title);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<UserTask>> AddNewTask(UserTask newTask)
        {
            var success = await _taskRepository.AddNewTask(newTask);
            if (!success)
                return BadRequest();

            return CreatedAtAction(nameof(GetTaskByTitle), new { title = newTask.Title }, newTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UserTask updatedTask)
        {
            var success = await _taskRepository.UpdateTask(id, updatedTask);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{title}")]
        public async Task<IActionResult> DeleteTaskByTitle(string title)
        {
            var success = await _taskRepository.DeleteTaskByTitle(title);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
