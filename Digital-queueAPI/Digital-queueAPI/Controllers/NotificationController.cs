using AutoMapper;
using Digital_queueAPI.BLL;
using Digital_queueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Digital_queueAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService, IMapper mapper) {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationDTO>> GetById(int id) {
            NotificationDTO? notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null) {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpGet]
        public async Task<ActionResult<List<NotificationDTO>>> GetAll() {
            List<NotificationDTO> notifications = await _notificationService.GetAllNotificationsAsync();
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<ActionResult<NotificationDTO>> Create([FromBody] NotificationDTO notificationDto) {
            await _notificationService.CreateNotificationAsync(notificationDto);
            return CreatedAtAction(nameof(GetById), new { id = notificationDto.UserId }, notificationDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NotificationDTO notificationDto) {
            try {
                await _notificationService.UpdateNotificationAsync(id, notificationDto);
            }
            catch (Exception) {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            bool exists = await _notificationService.NotificationExistsAsync(id);
            if (!exists) {
                return NotFound();
            }

            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }
    }
}
