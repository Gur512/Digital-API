using AutoMapper;
using Digital_queueAPI.DAL;
using Digital_queueAPI.Models;

namespace Digital_queueAPI.BLL {
    public class QueueService {
        private readonly QueueRepository _repository;
        private readonly IMapper _mapper;

        public QueueService(QueueRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<QueueDTO>> GetAllQueuesAsync() {
            List<Queue> queues = await _repository.GetAllAsync();
            return _mapper.Map<List<QueueDTO>>(queues);
        }

        public async Task<QueueDTO?> GetQueueByIdAsync(int id) {
            Queue? queue = await _repository.GetByIdAsync(id);
            return _mapper.Map<QueueDTO>(queue);
        }

        public async Task<Queue> CreateQueueAsync(QueueDTO queueDto) {
            Queue queue = _mapper.Map<Queue>(queueDto);
            await _repository.AddAsync(queue);
            return queue;
        }

        public async Task UpdateQueueAsync(int id, QueueDTO queueDto) {
            Queue queue = _mapper.Map<Queue>(queueDto);
            queue.QueueId = id;
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
