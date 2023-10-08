using Types.Models.User;

namespace Interfaces
{
    public interface IUserService
    {
        Task<User[]> GetUsersAsync();

        Task<User> GetUserByIdAsync(int userId);

    }
}
