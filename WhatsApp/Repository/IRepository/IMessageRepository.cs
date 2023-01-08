using WhatsApp.Models;

namespace WhatsApp.Services.IServices
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task Save();
    }
}
