using System.ComponentModel.DataAnnotations;

namespace GameDevPortfolio.Models;

public class ContactForm
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Message is required")]
    [StringLength(1000, ErrorMessage = "Message cannot be longer than 1000 characters")]
    public string Message { get; set; } = string.Empty;
}


