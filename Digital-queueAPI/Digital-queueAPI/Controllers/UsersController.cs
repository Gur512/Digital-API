using AutoMapper;
using Digital_queueAPI.BLL;
using Digital_queueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Digital_queueAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UsersController(UserService userService, IMapper mapper) {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id) {
            UserDTO? user = await _userService.GetUserByIdAsync(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers() {
            List<UserDTO> users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserDTO userDto) {
            User createdUser = await _userService.CreateUserAsync(userDto);
            UserDTO createdUserDto = _mapper.Map<UserDTO>(createdUser);

            return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserId }, createdUserDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDto) {
            bool exists = await _userService.UserExistsAsync(id);
            if (!exists) {
                return NotFound();
            }

            await _userService.UpdateUserAsync(id, userDto); 
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) {
            bool exists = await _userService.UserExistsAsync(id);
            if (!exists) {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
