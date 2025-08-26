using System.ComponentModel.DataAnnotations;

namespace BMassage.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public DateTime SlotDate { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string ClientName { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public string Comment { get; set; } = "";
    }
}