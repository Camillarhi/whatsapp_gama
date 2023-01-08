using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhatsApp.DTOs;
using WhatsApp.Services.IServices;

namespace WhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _db;
        private readonly IMapper _mapper;

        public ContactController(IContactRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _db.GetAll();
            var result = _mapper.Map<List<ContactDTO>>(contacts);

            return Ok(result);
        }

        [HttpGet("get/{Id}", Name = "GetContact")]
        public async Task<IActionResult> GetContact(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return BadRequest("Your request is invlaid");

            var contact = await _db.Get(x => x.Id == Id);
            var result = _mapper.Map<ContactDTO>(contact);

            return Ok(result);
        }
    }
}
