using ProjetoBase.Models;

namespace ProjetoBase.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> AddAsync(Category categorys);

        Task<List<Category>> ListAsync(int page = 1, int dataPag = 10);

        Task<Category?> GetAsync(Guid Id);

        bool Remove(Category category);
    }
}