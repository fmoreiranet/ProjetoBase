using ProjetoBase.Data;
using ProjetoBase.Interfaces;
using ProjetoBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoBase.Services
{
    public class UserService : IUserService
    {
        protected EntityContext _context;

        public UserService(EntityContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(User newUser)
        {
            try
            {
                var isUserAdd = _context.Users.Where(u => u.Email == newUser.Email).FirstOrDefault();
                if (isUserAdd != null)
                {
                    throw new Exception("Usuario já cadastrado!");
                }

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Erro ao cadastrar o usuário.", ex);
            }
        }

        public async Task<User?> GetAsync(Guid Id)
        {
            try
            {
                return await _context.Users.Where(u => u.Id == Id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o usuário.", ex);
            }
        }

        public Task<List<User>> ListAsync(int page, int dataPage)
        {
            try
            {
                var contUser = _context.Users.Count();
                var totalPags = (int)Math.Ceiling((decimal)contUser / dataPage);
                var result = _context.Users.Skip((page - 1) * dataPage).Take(dataPage).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os usuário.", ex);
            }
        }

        public User? Login(string usuario, string senha)
        {
            try
            {
                var result = _context.Users.Where(u => u.Email == usuario && u.Pass == senha && u.Ativo == true).FirstOrDefault();
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Usuario não localizado.");
            }

        }

        public bool Remove(User user)
        {
            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao removero o usuário", ex);
            }
        }
    }
}