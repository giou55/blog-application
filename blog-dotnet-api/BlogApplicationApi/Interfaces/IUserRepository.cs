using Types.Models;

namespace Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAll();

        Task<User> GetUserById(int userId);

        Task<User> AddUser(User toCreate);

        Task<User> UpdateUser(int userId, string name, string email);

        Task DeleteUser(int userId);
    }
}
