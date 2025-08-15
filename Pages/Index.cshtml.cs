using GameDevPortfolio.Data;
using GameDevPortfolio.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameDevPortfolio.Pages;

public class IndexModel : PageModel
{
    private readonly PortfolioDbContext _context;
    
    public IndexModel(PortfolioDbContext context)
    {
        _context = context;
    }
    
    public List<Project> FeaturedProjects { get; set; } = new();
    
    public async Task OnGetAsync()
    {
        // Get featured projects for the home page
        FeaturedProjects = await _context.Projects
            .Where(p => p.IsFeatured)
            .OrderByDescending(p => p.CreatedDate)
            .Take(6)
            .ToListAsync();
    }
}


