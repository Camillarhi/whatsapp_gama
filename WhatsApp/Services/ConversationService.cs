using WhatsApp.Context;
using WhatsApp.DTOs;
using WhatsApp.Models;
using WhatsApp.Services.IServices;

namespace WhatsApp.Services
{
    public class ConversationService
    {
        private readonly ContactService _contactService;
        private readonly IContactRepository _contactRepository;
        private readonly IConversationRepository _conversationRepository;
        private readonly MessageService _messageService;
        private readonly AppDbContext _context;
        private readonly ILogger<Conversation> _logger;

        public ConversationService(ContactService contactService,
                                   IContactRepository contactRepository,
                                   IConversationRepository conversationRepository,
                                   MessageService messageService,
                                   AppDbContext context,
                                   ILogger<Conversation> logger)
        {
            _contactService = contactService;
            _contactRepository = contactRepository;
            _conversationRepository = conversationRepository;
            _messageService = messageService;
            _context = context;
            _logger = logger;
        }

        public async Task<Conversation> SaveConversation(ConversationDTO request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                request.Message.ContactId = request.Contact.Id;

                var contactExist = await _contactRepository.Get(a => a.Phone == request.Contact.Phone);
                if (contactExist == null)
                {
                    await _contactService.CreateContact(request.Contact);
                }

                var message = await _messageService.CreateMessage(request.Message);

                Conversation conversation = new()
                {
                    Id = request.Id,
                    MessageReplyId = request.MessageReplyId,
                    ContactId = request.Contact.Id,
                    MessageType = request.MessageType,
                    MessageId = message.Id,
                    SessionId = request.SessionId
                };

                await _conversationRepository.Add(conversation);
                await _conversationRepository.Save();

                transaction.Commit();

                return conversation;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return default;
            }
        }
    }
}
