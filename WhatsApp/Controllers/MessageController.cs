using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhatsApp.DTOs;
using WhatsApp.Services.IServices;

namespace WhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _db;
        private readonly IMapper _mapper;

        public MessageController(IMessageRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _db.GetAll(null, new List<string> { "Contact" });
            var result = _mapper.Map<List<ViewMessageDTO>>(messages);

            return Ok(result);
        }

        [HttpGet("get/{Id:int}", Name = "GetMessage")]
        public async Task<IActionResult> GetMessage(int Id)
        {
            if (Id < 1 || Id == null) return BadRequest("Your request is invlaid");

            var message = await _db.Get(x => x.Id == Id, new List<string> { "Contact" });
            var result = _mapper.Map<ViewMessageDTO>(message);

            return Ok(result);
        }
    }
}
