using Digital_queueAPI.DAL;
using Digital_queueAPI.Models;

namespace Digital_queueAPI.BLL {
    public class QueueEntryService {
        private readonly QueueEntryRepository _repository;

        public QueueEntryService(QueueEntryRepository repository) {
            _repository = repository;
        }

        public async Task<List<QueueEntry>> GetAllEntriesAsync() {
            List<QueueEntry> entries = await _repository.GetAllAsync();
            return entries;
        }

        public async Task<QueueEntry?> GetEntryByIdAsync(int id) {
            QueueEntry? entry = await _repository.GetByIdAsync(id);
            return entry;
        }

        public async Task CreateEntryAsync(QueueEntry entry) {
            await _repository.AddAsync(entry);
        }

        public async Task UpdateEntryAsync(QueueEntry entry) {
            await _repository.UpdateAsync(entry);
        }

        public async Task DeleteEntryAsync(int id) {
            QueueEntry? entry = await _repository.GetByIdAsync(id);
            if (entry != null) {
                await _repository.DeleteAsync(entry);
            }
        }

        public async Task<bool> EntryExistsAsync(int id) {
            bool exists = await _repository.ExistsAsync(id);
            return exists;
        }
    }
}
