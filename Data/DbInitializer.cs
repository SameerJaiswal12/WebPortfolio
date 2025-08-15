using GameDevPortfolio.Models;

namespace GameDevPortfolio.Data;

public static class DbInitializer
{
    public static void Initialize(PortfolioDbContext context)
    {
        context.Database.EnsureCreated();

        // Check if data already exists
        if (context.Projects.Any())
        {
            return;
        }

        var projects = new Project[]
        {
            new Project
            {
                Slug = "cyberpunk-adventure",
                Title = "Cyberpunk Adventure",
                Tagline = "A neon-lit open-world RPG set in 2077",
                Overview = "Cyberpunk Adventure is an immersive open-world role-playing game that takes players to a dystopian future where corporations rule and technology has transformed society. Players navigate through a sprawling metropolis filled with neon lights, flying cars, and cybernetic enhancements.",
                Technologies = new List<string> { "Unity 2022.3 LTS", "C#", "Blender", "Substance Painter", "FMOD", "Git" },
                WhatIDid = new List<string> 
                { 
                    "Complete game design and concept development",
                    "3D modeling and texturing of all assets",
                    "Programming of core gameplay systems",
                    "Level design and world building",
                    "Sound design and music composition",
                    "UI/UX design and implementation"
                },
                HeroVideoPath = "/videos/cyberpunk-gameplay.mp4",
                GalleryImagePaths = new List<string> 
                { 
                    "/images/cyberpunk-1.jpg",
                    "/images/cyberpunk-2.jpg",
                    "/images/cyberpunk-3.jpg",
                    "/images/cyberpunk-4.jpg"
                },
                IsFeatured = true
            },
            new Project
            {
                Slug = "space-exploration",
                Title = "Space Exploration",
                Tagline = "Explore the vastness of space in this survival adventure",
                Overview = "Space Exploration is a first-person survival game where players must navigate through procedurally generated star systems, manage resources, upgrade their spacecraft, and discover ancient alien civilizations while avoiding cosmic threats.",
                Technologies = new List<string> { "Unreal Engine 5", "C++", "Maya", "ZBrush", "Wwise", "Perforce" },
                WhatIDid = new List<string> 
                { 
                    "Game engine setup and optimization",
                    "Procedural generation algorithms",
                    "3D character and ship modeling",
                    "Environmental art and lighting",
                    "Gameplay programming and mechanics",
                    "Audio implementation and mixing"
                },
                HeroVideoPath = "/videos/space-gameplay.mp4",
                GalleryImagePaths = new List<string> 
                { 
                    "/images/space-1.jpg",
                    "/images/space-2.jpg",
                    "/images/space-3.jpg"
                },
                IsFeatured = true
            },
            new Project
            {
                Slug = "medieval-fantasy",
                Title = "Medieval Fantasy",
                Tagline = "Epic fantasy RPG with magical combat and rich storytelling",
                Overview = "Medieval Fantasy is a story-driven role-playing game featuring a rich medieval world filled with magic, mythical creatures, and political intrigue. Players embark on an epic journey to save the realm from an ancient evil.",
                Technologies = new List<string> { "Unity 2022.3 LTS", "C#", "3ds Max", "Substance Designer", "Audiokinetic Wwise", "Git" },
                WhatIDid = new List<string> 
                { 
                    "World building and lore creation",
                    "Character design and animation",
                    "Combat system programming",
                    "Quest system implementation",
                    "Environmental storytelling",
                    "Particle effects and VFX"
                },
                HeroVideoPath = "/videos/medieval-gameplay.mp4",
                GalleryImagePaths = new List<string> 
                { 
                    "/images/medieval-1.jpg",
                    "/images/medieval-2.jpg",
                    "/images/medieval-3.jpg",
                    "/images/medieval-4.jpg",
                    "/images/medieval-5.jpg"
                },
                IsFeatured = false
            },
            new Project
            {
                Slug = "racing-simulator",
                Title = "Racing Simulator",
                Tagline = "High-fidelity racing simulation with realistic physics",
                Overview = "Racing Simulator delivers an authentic racing experience with realistic vehicle physics, detailed car models, and dynamic weather systems. Players can compete in various racing formats across multiple tracks and environments.",
                Technologies = new List<string> { "Unreal Engine 5", "C++", "Blender", "Substance Painter", "FMOD", "Git" },
                WhatIDid = new List<string> 
                { 
                    "Vehicle physics and handling",
                    "Track design and optimization",
                    "Car modeling and texturing",
                    "Weather system programming",
                    "AI opponent behavior",
                    "Multiplayer racing implementation"
                },
                HeroVideoPath = "/videos/racing-gameplay.mp4",
                GalleryImagePaths = new List<string> 
                { 
                    "/images/racing-1.jpg",
                    "/images/racing-2.jpg",
                    "/images/racing-3.jpg"
                },
                IsFeatured = false
            }
        };

        context.Projects.AddRange(projects);
        context.SaveChanges();
    }
}


