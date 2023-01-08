using WhatsApp.Models;

namespace WhatsApp.Services.IServices
{
    public interface IConversationRepository:IGenericRepository<Conversation>
    {
        Task Save();
    }
}
