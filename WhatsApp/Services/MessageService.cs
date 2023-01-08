using AutoMapper;
using WhatsApp.DTOs;
using WhatsApp.Models;
using WhatsApp.Services.IServices;

namespace WhatsApp.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<Message> CreateMessage(MessageDTO request)
        {
            var message = _mapper.Map<Message>(request);
            await _messageRepository.Add(message);
            await _messageRepository.Save();

            return message;
        }
    }
}
