using AutoMapper;
using Digital_queueAPI.DAL;
using Digital_queueAPI.Models;

namespace Digital_queueAPI.BLL {
    public class UserService {
        private readonly UserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(UserRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync() {
            List<User> users = await _repository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(users); 
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id) {
            User? user = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user); 
        }

        public async Task<User> CreateUserAsync(UserDTO userdto) {
            User user = _mapper.Map<User>(userdto);
            await _repository.AddAsync(user);
            return user;
        }

        public async Task UpdateUserAsync(int id, UserDTO userDto) {
            User user = _mapper.Map<User>(userDto);
            user.UserId = id;
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
