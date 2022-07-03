using ProjetoBase.Models;

namespace ProjetoBase.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> AddAsync(Category categorys);

        Task<List<Category>> ListAsync(int page, int dataPag);

        Task<Category?> GetAsync(Guid Id);

        bool Remove(Category category);
    }
}