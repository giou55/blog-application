using Interfaces;
using Types.Models;

namespace Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User toCreate)
        {
            _context.User.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteUser(id userId)
        {
            var user = _context.User
                .FirstOrDefault(p => p.Id == userId);

            if (user is null) return;

            _context.User.Remove(user);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.User.FirstOrDefaultAsync(p => p.Id == userId);
        }

        public async Task<User> UpdateUser(int userId, string name, string email)
        {
            var user = await _context.User.FirstOrDefaultAsync(p => p.Id == userId);
            user.Name = name;
            user.Email = email;

            await _context.SaveChangesAsync();
        }
    }
}
