using System.ComponentModel.DataAnnotations;
namespace Krontec.Data.Entity
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(100)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number format")]
        [Required(ErrorMessage = "Phone Number is required")]
        public string? PhoneNumber { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
    }
}


