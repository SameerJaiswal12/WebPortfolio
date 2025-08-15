using GameDevPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GameDevPortfolio.Pages;

public class ContactModel : PageModel
{
    [BindProperty]
    public ContactForm ContactForm { get; set; } = new();
    
    public bool MessageSent { get; set; } = false;
    
    public void OnGet()
    {
        // Initialize empty form
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        // In a real application, you would:
        // 1. Send an email notification
        // 2. Store the message in a database
        // 3. Send a confirmation email to the user
        
        // For now, we'll just simulate success
        MessageSent = true;
        
        // Clear the form
        ContactForm = new ContactForm();
        
        // Redirect to prevent form resubmission
        return RedirectToPage("", new { messageSent = true });
    }
}




