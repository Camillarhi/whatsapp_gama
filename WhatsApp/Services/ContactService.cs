using AutoMapper;
using WhatsApp.DTOs;
using WhatsApp.Models;
using WhatsApp.Services.IServices;

namespace WhatsApp.Services
{
    public class ContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<Contact> CreateContact(ContactDTO request)
        {
            var contact = _mapper.Map<Contact>(request);
            await _contactRepository.Add(contact);
            await _contactRepository.Save();

            return contact;
        }
    }
}
