using Microsoft.AspNetCore.Mvc;
using UsersTasksAPI.Models;
using UsersTasksAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UsersTasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddNewUser(User newUser)
        {
            var success = await _userRepository.AddNewUser(newUser);
            if (!success)
                return BadRequest();

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserID }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserById(int id, User updatedUser)
        {
            updatedUser.UserID = id;
            var success = await _userRepository.UpdateUser(updatedUser);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var success = await _userRepository.DeleteUserById(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
