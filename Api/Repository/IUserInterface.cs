using Api.Models;

namespace Api.Repository
{
    public interface IUserInterface
    {
        // CRUD
        Task<bool> CreateAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);   
    }
}
