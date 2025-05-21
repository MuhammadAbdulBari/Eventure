using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CreateEvent
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Enter Valid Event Name")]
        public string EventName { get; set; }

        [Required]
        public string EventType { get; set; }

        [Required]
        public DateTime EventDateTime { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Enter a valid Venue")]
        public string Venue { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Enter Valid Client Name")]
        public string ClientName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Enter Valid Client Contact Number")]
        public string ClientContact { get; set; }

        [Required]
        public long Budget { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string PaymentStatus { get; set; }
    }

  

   

}