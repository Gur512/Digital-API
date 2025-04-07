using Digital_queueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Digital_queueAPI.DAL {
    public class QueueRepository {
        private readonly AppDbContext _context;

        public QueueRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<List<Queue>> GetAllAsync() {
            List<Queue> queues = await _context.Queues.ToListAsync();
            return queues;
        }

        public async Task<Queue?> GetByIdAsync(int id) {
            Queue? queue = await _context.Queues.FindAsync(id);
            return queue;
        }

        public async Task AddAsync(Queue queue) {
            await _context.Queues.AddAsync(queue);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Queue queue) {
            _context.Queues.Update(queue);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Queue queue) {
            _context.Queues.Remove(queue);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) {
            bool exists = await _context.Queues.AnyAsync(q => q.QueueId == id);
            return exists;
        }
    }
}
