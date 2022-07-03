using ProjetoBase.Data;
using ProjetoBase.Interfaces;
using ProjetoBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoBase.Services
{
    public class MessageService : IMessageService
    {
        protected EntityContext _context;

        public MessageService(EntityContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Message newMessage)
        {
            try
            {
                _context.Messages.Add(newMessage);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Erro ao cadastrar a mensagem.", ex);
            }
        }

        public async Task<Message?> GetAsync(Guid Id)
        {
            try
            {
                return await _context.Messages.Where(u => u.Id == Id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar a mensagem.", ex);
            }
        }

        public Task<List<Message>> ListAsync(int page, int dataPage)
        {
            try
            {
                var contMessage = _context.Messages.Count();
                var totalPags = (int)Math.Ceiling((decimal)contMessage / dataPage);
                return _context.Messages.Skip((page - 1) * dataPage).Take(dataPage).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar as mensagens.", ex);
            }
        }

        public bool Remove(Message message)
        {
            try
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover a mensagem.", ex);
            }
        }
    }
}