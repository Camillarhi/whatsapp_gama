using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhatsApp.DTOs;
using WhatsApp.Models;
using WhatsApp.Services;
using WhatsApp.Services.IServices;

namespace WhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationRepository _db;
        private readonly ConversationService _conversationService;
        private readonly IMapper _mapper;
        private readonly ILogger<Conversation> _logger;

        public ConversationController(IConversationRepository db,
                                      ConversationService conversationService,
                                      IMapper mapper,
                                      ILogger<Conversation> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
            _conversationService = conversationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] ConversationDTO model)
        {

            if (!ModelState.IsValid)
            {
                _logger.LogError($"invalid post request from {nameof(CreateMessage)}");
                return BadRequest(ModelState);
            }

            var conversation = await _conversationService.SaveConversation(model);
            if (conversation == null)
            {
                _logger.LogError($"This error occurred: {conversation}");
                return BadRequest();
            }

            return CreatedAtRoute("GetConversation", new { id = conversation.Id }, conversation);
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetConversations()
        {
            var conversations = await _db.GetAll(null, new List<string> { "Contact", "Message" });
            var result = _mapper.Map<List<ConversationDTO>>(conversations);

            return Ok(result);
        }

        [HttpGet("get/{Id:int}", Name = "GetConversation")]
        public async Task<IActionResult> GetConversation(int Id)
        {
            if (Id < 1 || Id == null) return BadRequest("Your request is invlaid");

            var conversation = await _db.Get(x => x.Id == Id, new List<string> { "Contact", "Message" });
            var result = _mapper.Map<ConversationDTO>(conversation);

            return Ok(result);
        }

    }
}
