using ProjetoBase.Models;

namespace ProjetoBase.Interfaces
{
    public interface IMessageService
    {
        Task<bool> AddAsync(Message messages);

        Task<List<Message>> ListAsync(int page = 1, int dataPag = 10);

        Task<Message?> GetAsync(Guid Id);

        bool Remove(Message message);
    }
}