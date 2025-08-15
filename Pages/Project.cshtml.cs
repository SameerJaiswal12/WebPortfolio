using GameDevPortfolio.Data;
using GameDevPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameDevPortfolio.Pages;

public class ProjectModel : PageModel
{
    private readonly PortfolioDbContext _context;
    
    public ProjectModel(PortfolioDbContext context)
    {
        _context = context;
    }
    
    public Project? Project { get; set; }
    
    public async Task<IActionResult> OnGetAsync(string slug)
    {
        if (string.IsNullOrEmpty(slug))
        {
            return RedirectToPage("/Projects");
        }
        
        // Get project by slug
        Project = await _context.Projects
            .FirstOrDefaultAsync(p => p.Slug == slug);
        
        if (Project == null)
        {
            return Page();
        }
        
        return Page();
    }
}




