using AutoMapper;
using Digital_queueAPI.BLL;
using Digital_queueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Digital_queueAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase {
        private readonly QueueService _queueService;
        private readonly IMapper _mapper;

        public QueueController(QueueService queueService, IMapper mapper) {
            _queueService = queueService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QueueDTO>> GetById(int id) {
            QueueDTO? queue = await _queueService.GetQueueByIdAsync(id);
            if (queue == null) {
                return NotFound();
            }
            return Ok(queue);
        }

        [HttpGet]
        public async Task<ActionResult<List<QueueDTO>>> GetAll() {
            List<QueueDTO> queues = await _queueService.GetAllQueuesAsync();
            return Ok(queues);
        }

        [HttpPost]
        public async Task<ActionResult<QueueDTO>> Create([FromBody] QueueDTO queueDto) {
            Queue createdQueue = await _queueService.CreateQueueAsync(queueDto);
            QueueDTO createdQueueDto = _mapper.Map<QueueDTO>(createdQueue);
            return CreatedAtAction(nameof(GetById), new { id = createdQueue.QueueId }, createdQueueDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] QueueDTO queueDto) {
            bool exists = await _queueService.QueueExistsAsync(id);
            if (!exists) {
                return NotFound();
            }

            await _queueService.UpdateQueueAsync(id, queueDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            QueueDTO? queue = await _queueService.GetQueueByIdAsync(id);
            if (queue == null) {
                return NotFound();
            }

            await _queueService.DeleteQueueAsync(id);
            return NoContent();
        }
    }
}
