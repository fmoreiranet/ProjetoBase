using ProjetoBase.Models;

namespace ProjetoBase.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(User users);

        Task<List<User>> ListAsync(int page = 1, int dataPag = 10);

        Task<User?> GetAsync(Guid Id);

        bool Remove(User user);
    }
}