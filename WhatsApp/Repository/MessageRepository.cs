using AutoMapper;
using WhatsApp.Context;
using WhatsApp.DTOs;
using WhatsApp.Models;
using WhatsApp.Services.IServices;

namespace WhatsApp.Services
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public MessageRepository(AppDbContext db,
                              IMapper mapper) : base(db)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }     
    }
}
