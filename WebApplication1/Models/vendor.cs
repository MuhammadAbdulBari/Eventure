using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class vendor
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Contact person is required.")]
        [StringLength(100, ErrorMessage = "Enter Valid Name")]
        public string Contact_Person { get; set; }


        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Enter Valid Contact number")]
        public long  Number { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Service type is required.")]
        [StringLength(50, ErrorMessage = "Enter Valid Service type")]
        public string Service_Type { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(100, ErrorMessage = "Enter Valid Company Name")]
        public string Company_Name { get; set; }


        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Enter Valid Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
    }
}
