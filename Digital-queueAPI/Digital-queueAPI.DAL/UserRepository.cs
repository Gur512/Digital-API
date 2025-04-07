using Digital_queueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Digital_queueAPI.DAL {
    public class UserRepository {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync() {
            List<User> users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetByIdAsync(int id) {
            User? user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task AddAsync(User user) {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user) {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user) {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id) {
            bool exists = await _context.Users.AnyAsync(u => u.UserId == id);
            return exists;
        }
    }
}
