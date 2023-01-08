using System.ComponentModel.DataAnnotations;

namespace WhatsApp.DTOs
{
    public class ContactDTO
    {
        public string Id { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
    }
}
