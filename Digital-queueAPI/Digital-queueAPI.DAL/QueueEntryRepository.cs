using Digital_queueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Digital_queueAPI.DAL {
    public class QueueEntryRepository {
        private readonly AppDbContext _context;

        public QueueEntryRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<List<QueueEntry>> GetAllAsync() {
            List<QueueEntry> entries = await _context.QueueEntries.ToListAsync();
            return entries;
        }

        public async Task<QueueEntry?> GetByIdAsync(int id) {
            QueueEntry? entry = await _context.QueueEntries.FindAsync(id);
            return entry;
        }

        public async Task AddAsync(QueueEntry entry) {
            await _context.QueueEntries.AddAsync(entry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(QueueEntry entry) {
            _context.QueueEntries.Update(entry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(QueueEntry entry) {
            _context.QueueEntries.Remove(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) {
            bool exists = await _context.QueueEntries.AnyAsync(qe => qe.EntryId == id);
            return exists;
        }
    }
}
