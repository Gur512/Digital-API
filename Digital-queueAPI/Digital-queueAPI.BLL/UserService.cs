using Digital_queueAPI.DAL;
using Digital_queueAPI.Models;

namespace Digital_queueAPI.BLL {
    public class UserService {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository) {
            _repository = repository;
        }

        public async Task<List<User>> GetAllUsersAsync() {
            List<User> users = await _repository.GetAllAsync();
            return users;
        }

        public async Task<User?> GetUserByIdAsync(int id) {
            User? user = await _repository.GetByIdAsync(id);
            return user;
        }

        public async Task CreateUserAsync(User user) {
            await _repository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user) {
            await _repository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id) {
            User? user = await _repository.GetByIdAsync(id);
            if (user != null) {
                await _repository.DeleteAsync(user);
            }
        }

        public async Task<bool> UserExistsAsync(int id) {
            bool exists = await _repository.ExistsAsync(id);
            return exists;
        }
    }
}
