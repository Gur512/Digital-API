using AutoMapper;
using Digital_queueAPI.DAL;
using Digital_queueAPI.Models;

namespace Digital_queueAPI.BLL {
    public class NotificationService {
        private readonly IMapper _mapper;
        private readonly NotificationRepository _repository;

        public NotificationService(NotificationRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<NotificationDTO>> GetAllNotificationsAsync() {
            List<Notification> notifications = await _repository.GetAllAsync();
            return _mapper.Map<List<NotificationDTO>>(notifications);
        }

        public async Task<NotificationDTO?> GetNotificationByIdAsync(int id) {
            Notification? notification = await _repository.GetByIdAsync(id);
            return _mapper.Map<NotificationDTO>(notification);
        }

        public async Task CreateNotificationAsync(NotificationDTO notificationDto) {
            Notification notification = _mapper.Map<Notification>(notificationDto);
            await _repository.AddAsync(notification);
        }

        public async Task UpdateNotificationAsync(int id, NotificationDTO notificationDto) {
            bool exists = await _repository.ExistsAsync(id);
            if (!exists) {
                throw new Exception("Notification not found.");
            }

            Notification notification = _mapper.Map<Notification>(notificationDto);
            notification.NotificationId = id;  

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
