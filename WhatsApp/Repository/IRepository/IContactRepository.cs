using WhatsApp.Models;

namespace WhatsApp.Services.IServices
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Task Save();
    }
}
