using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsApp.Models
{
    public class Conversation
    {
        [Required]
        public int Id { get; set; }
        public int MessageReplyId { get; set; }
        [Required]
        [ForeignKey("Contact")]
        public string ContactId { get; set; } = string.Empty;
        public Contact Contact { get; set; }
        [Required]
        public string MessageType { get; set; } = string.Empty;
        [Required]
        [ForeignKey("Message")]
        public int MessageId { get; set; }
        public Message Message { get; set; }
        [Required]
        public string SessionId { get; set; } = string.Empty;
    }
}
