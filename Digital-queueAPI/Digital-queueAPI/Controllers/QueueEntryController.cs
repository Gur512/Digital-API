using AutoMapper;
using Digital_queueAPI.BLL;
using Digital_queueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Digital_queueAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class QueueEntryController : ControllerBase {
        private readonly QueueEntryService _entryService;
        private readonly IMapper _mapper;

        public QueueEntryController(QueueEntryService entryService, IMapper mapper) {
            _entryService = entryService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QueueEntryDTO>> GetById(int id) {
            QueueEntry? entry = await _entryService.GetEntryByIdAsync(id);
            if (entry == null) {
                return NotFound();
            }
            QueueEntryDTO dto = _mapper.Map<QueueEntryDTO>(entry);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<QueueEntryDTO>>> GetAll() {
            List<QueueEntry> entries = await _entryService.GetAllEntriesAsync();
            List<QueueEntryDTO> dtos = _mapper.Map<List<QueueEntryDTO>>(entries);
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<QueueEntryDTO>> Create([FromBody] QueueEntryDTO dto) {
            QueueEntry createdEntry = await _entryService.CreateEntryAsync(dto);
            QueueEntryDTO createdDto = _mapper.Map<QueueEntryDTO>(createdEntry);
            return CreatedAtAction(nameof(GetById), new { id = createdEntry.EntryId }, createdDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] QueueEntryDTO dto) {
            bool exists = await _entryService.EntryExistsAsync(id);
            if (!exists) {
                return NotFound();
            }

            await _entryService.UpdateEntryAsync(id, dto);
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
