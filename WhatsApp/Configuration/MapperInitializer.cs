using AutoMapper;
using WhatsApp.DTOs;
using WhatsApp.Models;

namespace WhatsApp.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Conversation, ConversationDTO>().ReverseMap();
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<Message, MessageDTO>().ReverseMap();
            CreateMap<Message, ViewMessageDTO>().ReverseMap();
        }
    }
}
