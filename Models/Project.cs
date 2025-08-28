using System.ComponentModel.DataAnnotations;

namespace GameDevPortfolio.Models;

public class Project
{
    public int Id { get; set; }
    
    [Required]
    public string Slug { get; set; } = string.Empty;
    
    [Required]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public string Tagline { get; set; } = string.Empty;
    
    [Required]
    public string Overview { get; set; } = string.Empty;
    
    public string GitHubUrl { get; set; }

    public string? YouTubeUrl { get; set; }

    
    public List<string> Technologies { get; set; } = new();
    
    public List<string> WhatIDid { get; set; } = new();
    
    public string? HeroVideoPath { get; set; }
    
    public string? GameplayDescription { get; set; }
    
    public string? Reflection { get; set; }
    
    public List<string> GalleryImagePaths { get; set; } = new();
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    
    public bool IsFeatured { get; set; } = false;
    
}


