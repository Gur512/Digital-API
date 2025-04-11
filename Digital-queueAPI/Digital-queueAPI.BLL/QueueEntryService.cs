using AutoMapper;
using Digital_queueAPI.DAL;
using Digital_queueAPI.Models;

namespace Digital_queueAPI.BLL {
    public class QueueEntryService {
        private readonly QueueEntryRepository _repository;
        private readonly IMapper _mapper;

        public QueueEntryService(QueueEntryRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<QueueEntry>> GetAllEntriesAsync() {
            return await _repository.GetAllAsync();
        }

        public async Task<QueueEntry?> GetEntryByIdAsync(int id) {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<QueueEntry> CreateEntryAsync(QueueEntryDTO dto) {
            QueueEntry entry = _mapper.Map<QueueEntry>(dto);
            await _repository.AddAsync(entry);
            return entry;
        }

        public async Task UpdateEntryAsync(int id, QueueEntryDTO dto) {
            QueueEntry entryToUpdate = _mapper.Map<QueueEntry>(dto);
            entryToUpdate.EntryId = id; 
            await _repository.UpdateAsync(entryToUpdate);
        }

        public async Task DeleteEntryAsync(int id) {
            QueueEntry? entry = await _repository.GetByIdAsync(id);
            if (entry != null) {
                await _repository.DeleteAsync(entry);
            }
        }

        public async Task<bool> EntryExistsAsync(int id) {
            return await _repository.ExistsAsync(id);
        }
    }
}
