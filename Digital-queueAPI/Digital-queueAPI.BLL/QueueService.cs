using Digital_queueAPI.DAL;
using Digital_queueAPI.Models;

namespace Digital_queueAPI.BLL {
    public class QueueService {
        private readonly QueueRepository _repository;

        public QueueService(QueueRepository repository) {
            _repository = repository;
        }

        public async Task<List<Queue>> GetAllQueuesAsync() {
            List<Queue> queues = await _repository.GetAllAsync();
            return queues;
        }

        public async Task<Queue?> GetQueueByIdAsync(int id) {
            Queue? queue = await _repository.GetByIdAsync(id);
            return queue;
        }

        public async Task CreateQueueAsync(Queue queue) {
            await _repository.AddAsync(queue);
        }

        public async Task UpdateQueueAsync(Queue queue) {
            await _repository.UpdateAsync(queue);
        }

        public async Task DeleteQueueAsync(int id) {
            Queue? queue = await _repository.GetByIdAsync(id);
            if (queue != null) {
                await _repository.DeleteAsync(queue);
            }
        }

        public async Task<bool> QueueExistsAsync(int id) {
            bool exists = await _repository.ExistsAsync(id);
            return exists;
        }
    }
}
