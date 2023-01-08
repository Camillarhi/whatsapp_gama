using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WhatsApp.Models;

namespace WhatsApp.DTOs
{
    public class MessageDTO
    {
        [Required]
        public string Body { get; set; } = string.Empty;
        public string Header { get; set; } = string.Empty;
        [JsonIgnore]
        [ForeignKey(nameof(Contact))]
        public string ContactId { get; set; } = string.Empty;
    }

    public class ViewMessageDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Body { get; set; } = string.Empty;
        public string Header { get; set; } = string.Empty;

        [ForeignKey(nameof(Contact))]
        public ContactDTO Contact { get; set; }

    }
}
