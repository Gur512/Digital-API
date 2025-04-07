using Digital_queueAPI.BLL;
using Digital_queueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Digital_queueAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase {
        private readonly QueueService _queueService;

        public QueueController(QueueService queueService) {
            _queueService = queueService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Queue>> GetById(int id) {
            Queue? queue = await _queueService.GetQueueByIdAsync(id);
            if (queue == null) {
                return NotFound();
            }
            return Ok(queue);
        }

        [HttpGet]
        public async Task<ActionResult<List<Queue>>> GetAll() {
            List<Queue> queues = await _queueService.GetAllQueuesAsync();
            return Ok(queues);
        }

        [HttpPost]
        public async Task<ActionResult<Queue>> Create(Queue queue) {
            await _queueService.CreateQueueAsync(queue);
            return CreatedAtAction(nameof(GetById), new { id = queue.QueueId }, queue);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Queue queue) {
            if (id != queue.QueueId) {
                return BadRequest("Queue ID mismatch.");
            }

            bool exists = await _queueService.QueueExistsAsync(id);
            if (!exists) {
                return NotFound();
            }

            await _queueService.UpdateQueueAsync(queue);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            Queue? queue = await _queueService.GetQueueByIdAsync(id);
            if (queue == null) {
                return NotFound();
            }

            await _queueService.DeleteQueueAsync(id);
            return NoContent();
        }
    }
}
