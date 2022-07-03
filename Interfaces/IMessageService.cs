using ProjetoBase.Models;

namespace ProjetoBase.Interfaces
{
    public interface IMessageService
    {
        Task<bool> AddAsync(Message messages);

        Task<List<Message>> ListAsync(int page, int dataPag);

        Task<Message?> GetAsync(Guid Id);

        bool Remove(Message message);
    }
}