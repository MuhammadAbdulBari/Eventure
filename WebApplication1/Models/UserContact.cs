using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserContact
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Enter Valid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Enter Valid Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Enter Valid Contact number")]
        public long Number { get; set; }

        [Required(ErrorMessage = "Budget is required.")]
       
        public long Budget { get; set; }


        [Required(ErrorMessage = "Message is required.")]
        [StringLength(300)]
        public string Message { get; set; }



    }
}
