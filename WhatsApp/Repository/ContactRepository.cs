using AutoMapper;
using WhatsApp.Context;
using WhatsApp.Models;
using WhatsApp.Services.IServices;

namespace WhatsApp.Services
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private readonly AppDbContext _db;


        public ContactRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }               
    }
}
