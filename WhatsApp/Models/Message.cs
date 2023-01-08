using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsApp.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Body { get; set; } = string.Empty;
        public string Header { get; set; } = string.Empty;
        [Required]
        [ForeignKey(nameof(Contact))]
        public string ContactId { get; set; }=string.Empty;
        public Contact Contact { get; set; }
    }
}
