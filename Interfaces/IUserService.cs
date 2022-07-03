using ProjetoBase.Models;

namespace ProjetoBase.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(User users);

        Task<List<User>> ListAsync(int page, int dataPag);

        Task<User?> GetAsync(Guid id);

        bool Remove(User user);
    }
}