using Digital_queueAPI.BLL;
using Digital_queueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Digital_queueAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService) {
            _notificationService = notificationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetById(int id) {
            Notification? notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null) {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpGet]
        public async Task<ActionResult<List<Notification>>> GetAll() {
            List<Notification> notifications = await _notificationService.GetAllNotificationsAsync();
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<ActionResult<Notification>> Create(Notification notification) {
            await _notificationService.CreateNotificationAsync(notification);
            return CreatedAtAction(nameof(GetById), new { id = notification.NotificationId }, notification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Notification notification) {
            if (id != notification.NotificationId) {
                return BadRequest("Notification ID mismatch.");
            }

            bool exists = await _notificationService.NotificationExistsAsync(id);
            if (!exists) {
                return NotFound();
            }

            await _notificationService.UpdateNotificationAsync(notification);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            Notification? notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null) {
                return NotFound();
            }

            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }
    }
}
