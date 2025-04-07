using Digital_queueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Digital_queueAPI.DAL {
    public class NotificationRepository {
        private readonly AppDbContext _context;

        public NotificationRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<List<Notification>> GetAllAsync() {
            List<Notification> notifications = await _context.Notifications.ToListAsync();
            return notifications;
        }

        public async Task<Notification?> GetByIdAsync(int id) {
            Notification? notification = await _context.Notifications.FindAsync(id);
            return notification;
        }

        public async Task AddAsync(Notification notification) {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Notification notification) {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Notification notification) {
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) {
            bool exists = await _context.Notifications.AnyAsync(n => n.NotificationId == id);
            return exists;
        }
    }
}
