using AutoMapper;
using WhatsApp.Context;
using WhatsApp.DTOs;
using WhatsApp.Models;
using WhatsApp.Services.IServices;

namespace WhatsApp.Services
{
    public class ConversationRepository : GenericRepository<Conversation>, IConversationRepository
    {
        private readonly AppDbContext _db;
        private readonly ContactService _contactService;
        private readonly IContactRepository _contactRepository;
        private readonly MessageService _messageService;
        public ConversationRepository(AppDbContext db,
                                   ContactService contactService,
                                   IContactRepository contactRepository,
                                   MessageService messageService) : base(db)
        {
            _db = db;
            _contactService = contactService;
            _contactRepository = contactRepository;
            _messageService = messageService;
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
