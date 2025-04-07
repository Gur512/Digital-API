using Digital_queueAPI.BLL;
using Digital_queueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Digital_queueAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class QueueEntryController : ControllerBase {
        private readonly QueueEntryService _entryService;

        public QueueEntryController(QueueEntryService entryService) {
            _entryService = entryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QueueEntry>> GetById(int id) {
            QueueEntry? entry = await _entryService.GetEntryByIdAsync(id);
            if (entry == null) {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpGet]
        public async Task<ActionResult<List<QueueEntry>>> GetAll() {
            List<QueueEntry> entries = await _entryService.GetAllEntriesAsync();
            return Ok(entries);
        }

        [HttpPost]
        public async Task<ActionResult<QueueEntry>> Create(QueueEntry entry) {
            await _entryService.CreateEntryAsync(entry);
            return CreatedAtAction(nameof(GetById), new { id = entry.EntryId }, entry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, QueueEntry entry) {
            if (id != entry.EntryId) {
                return BadRequest("Entry ID mismatch.");
            }

            bool exists = await _entryService.EntryExistsAsync(id);
            if (!exists) {
                return NotFound();
            }

            await _entryService.UpdateEntryAsync(entry);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            QueueEntry? entry = await _entryService.GetEntryByIdAsync(id);
            if (entry == null) {
                return NotFound();
            }

            await _entryService.DeleteEntryAsync(id);
            return NoContent();
        }
    }
}
