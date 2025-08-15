using GameDevPortfolio.Data;
using GameDevPortfolio.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameDevPortfolio.Pages;

public class ProjectsModel : PageModel
{
    private readonly PortfolioDbContext _context;
    
    public ProjectsModel(PortfolioDbContext context)
    {
        _context = context;
    }
    
    public List<Project> Projects { get; set; } = new();
    
    public async Task OnGetAsync()
    {
        // Get all projects ordered by creation date
        Projects = await _context.Projects
            .OrderByDescending(p => p.CreatedDate)
            .ToListAsync();
    }
}




