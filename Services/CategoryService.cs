using ProjetoBase.Data;
using ProjetoBase.Interfaces;
using ProjetoBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoBase.Services
{
    public class CategoryService : ICategoryService
    {
        protected EntityContext _context;

        public CategoryService(EntityContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Category newCategory)
        {
            try
            {
                _context.Categories.Add(newCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Erro ao cadastrar a categoria.", ex);
            }
        }

        public async Task<Category?> GetAsync(Guid id)
        {
            try
            {
                return await _context.Categories.Where(u => u.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar a categoria.", ex);
            }
        }

        public Task<List<Category>> ListAsync(int page, int dataPage)
        {
            try
            {
                var contCategory = _context.Categories.Count();
                var totalPags = (int)Math.Ceiling((decimal)contCategory / dataPage);
                return _context.Categories.Skip((page - 1) * dataPage).Take(dataPage).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar a categoria.", ex);
            }
        }

        public bool Remove(Category category)
        {
            try
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao removero a categoria.", ex);
            }
        }
    }
}