using Digital_queueAPI.DAL;
using Digital_queueAPI.Models;

namespace Digital_queueAPI.BLL {
    public class NotificationService {
        private readonly NotificationRepository _repository;

        public NotificationService(NotificationRepository repository) {
            _repository = repository;
        }

        public async Task<List<Notification>> GetAllNotificationsAsync() {
            List<Notification> notifications = await _repository.GetAllAsync();
            return notifications;
        }

        public async Task<Notification?> GetNotificationByIdAsync(int id) {
            Notification? notification = await _repository.GetByIdAsync(id);
            return notification;
        }

        public async Task CreateNotificationAsync(Notification notification) {
            await _repository.AddAsync(notification);
        }

        public async Task UpdateNotificationAsync(Notification notification) {
            await _repository.UpdateAsync(notification);
        }

        public async Task DeleteNotificationAsync(int id) {
            Notification? notification = await _repository.GetByIdAsync(id);
            if (notification != null) {
                await _repository.DeleteAsync(notification);
            }
        }

        public async Task<bool> NotificationExistsAsync(int id) {
            bool exists = await _repository.ExistsAsync(id);
            return exists;
        }
    }
}
