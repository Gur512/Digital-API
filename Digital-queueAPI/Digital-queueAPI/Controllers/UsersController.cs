using Digital_queueAPI.BLL;
using Digital_queueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Digital_queueAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly UserService _userService;

        public UsersController(UserService userService) {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id) {
            User? user = await _userService.GetUserByIdAsync(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers() {
            List<User> users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user) {
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user) {
            if (id != user.UserId) {
                return BadRequest("User ID mismatch.");
            }

            bool exists = await _userService.UserExistsAsync(id);
            if (!exists) {
                return NotFound();
            }

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) {
            User? user = await _userService.GetUserByIdAsync(id);
            if (user == null) {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
