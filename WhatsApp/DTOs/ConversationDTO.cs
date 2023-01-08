using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsApp.DTOs
{
    public class ConversationDTO
    {
        [Required]
        public int Id { get; set; }
        public int MessageReplyId { get; set; }
        [ForeignKey("ContactId")]
        public ContactDTO Contact { get; set; }
        [Required]
        public string MessageType { get; set; } = string.Empty;
        [ForeignKey("MessageId")]
        public MessageDTO Message { get; set; }
        [Required]
        public string SessionId { get; set; } = string.Empty;
    }
}
