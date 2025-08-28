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
                Slug = "haunt-inn",
                Title = "Haunt-Inn",
                Tagline = "3D FPS Horror Shooter with Third-Person Exploration",
                Overview = "Haunt-Inn is a two-part horror shooter game where the player starts in a third-person perspective, explores a mysterious environment, and then transitions into a fast-paced first-person monster shooter. The game takes place around and inside a haunted inn, blending atmospheric tension with action combat.",
                Technologies = new List<string> { "Unity", "C#", "Maya", "Substance Painter", "Audacity", "Photoshop" },
                WhatIDid = new List<string> 
                {
                    "Created the environment, player hands, and weapon models in Maya",
                    "Applied cel-shading and stylized textures using Substance Painter",
                    "Rigged, skinned, and animated the models (player, door, gun, etc.)",
                    "Coded gameplay logic including enemy spawns, bullet system, health, and UI prompts",
                    "Designed and implemented full UI (reload prompts, health, game over, restart)",
                    "Added sound effects, background ambience, and player feedback",
                    "Integrated two scenes and built the full game flow from exploration to combat",
                    "Picked enemy and foliage assets from Unity Asset Store and customized as needed"
                },
                YouTubeUrl = "https://www.youtube.com/embed/kmj39OConnc?si=h9YZWMF6jKdTljoK",
                GitHubUrl = "https://github.com/SameerJaiswal12/Haunt-Inn",
                GameplayDescription = "Players begin in a dark, forested area in front of the inn. Upon interacting with the entrance, the perspective switches to FPS mode. Inside, monsters spawn through two different gates at increasing speeds. Players must shoot them using an 11-bullet-limited gun that requires timely reloading. Three enemy types are present, including a rare and powerful one with higher health.",
                Reflection = "This project was my most complete and complex 3D experience. It pushed me to integrate everything I had learned — from modeling and animation to coding and polish — into a single immersive prototype.",
                GalleryImagePaths = new List<string> 
                {
                    "/images/haunt-inn-1.jpg",
                    "/images/haunt-inn-2.jpg",
                    "/images/haunt-inn-3.jpg",
                    "/images/haunt-inn-4.jpg"
                },
                IsFeatured = true
            },
            new Project
            {
                Slug = "clash-zone",
                Title = "Clash Zone",
                Tagline = "2D Fighting Game with Unique Character Mechanics",
                Overview = "Clash Zone is a local 2D fighting game featuring two uniquely designed characters with different combat styles, health mechanics, and visual feedback. The game was made to experiment with traditional fighting mechanics and layered UI systems.",
                Technologies = new List<string> { "Unity", "C#", "Adobe Animate", "Photoshop" },
                WhatIDid = new List<string> 
                {
                    "Designed both characters with distinct playstyles and balanced abilities",
                    "Created all character animations in Adobe Animate (idle, attack, jump, block, dash)",
                    "Developed all game logic using Unity: collision, health, shield regen, and hit detection",
                    "Designed full UI (health bars, shield bars, damage indicators, match flow)",
                    "Created combat VFX like flashes and floating damage numbers",
                    "Designed the arena stage and implemented camera tracking"
                },
                YouTubeUrl = "https://www.youtube.com/embed/WHHSv1xJacI?si=fyc74H9Tv99wDx05",
                GitHubUrl = "https://github.com/SameerJaiswal12/Clash-Zone",
                GameplayDescription = "Two players fight in a 1v1 match using punch, kick, projectile, or dash attacks. Player 1 is a heavy striker with powerful attacks and a projectile, while Player 2 is more agile with fast punches and a dash ability. Each player has both health and a regenerating shield system. The game features visual indicators like screen flashes and floating damage text to provide satisfying combat feedback.",
                Reflection = "This game was a fun dive into animation and responsive gameplay. I learned how visual polish and game feel matter just as much as core mechanics — especially in fighting games.",
                GalleryImagePaths = new List<string> 
                {
                    "/images/clash-zone-1.jpg",
                    "/images/clash-zone-2.jpg",
                    "/images/clash-zone-3.jpg"
                },
                IsFeatured = true
            },
            new Project
            {
                Slug = "claras-journey",
                Title = "Clara's Journey",
                Tagline = "2D Endless Runner with Double-Jump Mechanics",
                Overview = "Clara's Journey is a 2D endless runner platformer that follows Clara and her dog across a colorful world filled with obstacles. Inspired by Flappy Bird, the game uses a double-jump system and progressively harder challenges as the game continues.",
                Technologies = new List<string> { "Unity Visual Scripting", "Photoshop","Aseprite" },
                WhatIDid = new List<string> 
                {
                    "Designed and animated Clara and the dog using 2D sprite animation.",
                    "Built dynamic obstacle spawning and movement logic in Unity using Unity Visual Scripting(Graphs).",
                    "Created UI for score tracking and game over state.",
                    "Composed and implemented background music and SFX",
                    "Designed the game loop and difficulty ramping system",
                    "Created all visual assets including background and environment elements"
                },
                YouTubeUrl = "https://www.youtube.com/embed/P2NMmRLgu6Q?si=NtUjIUDPWbwqTDBp",
                GitHubUrl = "",
                GameplayDescription = "The player jumps to avoid incoming stacker obstacles while continuously moving forward. Clara can perform multiple jumps mid-air, allowing recovery from near-misses. The goal is to survive as long as possible while accumulating points based on distance covered.",
                Reflection = "This project helped me understand tight jump controls and endless game design. It also gave me hands-on experience with polish and visual clarity in fast-paced games.",
                GalleryImagePaths = new List<string> 
                {
                    "/images/claras-journey-1.jpg",
                    "/images/claras-journey-2.jpg",
                    "/images/claras-journey-3.jpg"
                },
                IsFeatured = true
            },
            new Project
            {
                Slug = "crater-shooter",
                Title = "Crater Shooter",
                Tagline = "2D Space Arcade Shooter with Progressive Difficulty",
                Overview = "Crater Shooter is a classic-style top-down 2D arcade shooter where the player controls a spaceship shooting meteors falling from above. The game is score-based and becomes more difficult as it progresses.",
                Technologies = new List<string> { "Unity", "C#", "Audacity", "Photoshop" },
                WhatIDid = new List<string> 
                {
                    "Designed the spaceship, meteors, background, and all UI elements",
                    "Implemented shooting, scoring, and health systems using Unity",
                    "Handled bullet instantiation and enemy collision",
                    "Added shooting sound effects and looping background music",
                    "Created the game loop and challenge curve"
                },
                YouTubeUrl = "https://www.youtube.com/embed/4nrw5i3YOwM?si=d8cLRIGQcoX8x_aq",
                GitHubUrl = "https://github.com/SameerJaiswal12/Crater-Shooter",
                GameplayDescription = "The player moves horizontally and shoots bullets upward to destroy falling meteors and asteroids. Each asteroid has 1 HP and rewards 1 point. The spawn rate of meteors increases over time. When an asteroid touches the player, health is lost. The game ends when health reaches zero.",
                Reflection = "One of my early projects that taught me game feel and audio feedback. It helped me grasp object pooling, collision, and UI under pressure.",
                GalleryImagePaths = new List<string> 
                {
                    "/images/crater-shooter-1.jpg",
                    "/images/crater-shooter-2.jpg"
                },
                IsFeatured = false
            },
            new Project
            {
                Slug = "neon-ball",
                Title = "Neon Ball",
                Tagline = "3D Obstacle Avoidance Game with Glowing Aesthetics",
                Overview = "Neon Ball is a minimalist 3D game where the player controls a glowing ball that rolls forward and must avoid neon-colored obstacles until reaching the finish line.",
                Technologies = new List<string> { "Unity Visual Scripting", "Photoshop" },
                WhatIDid = new List<string> 
                {
                    "Designed the level layout and obstacles using custom neon-themed assets",
                    "Built all movement, obstacle detection, restart/win logic using Unity's Visual Scripting system",
                    "Created lighting and post-processing for the glowing theme",
                    "Handled UI prompts and start/end screens"
                },
                YouTubeUrl = "https://www.youtube.com/embed/X6rqFFEAxrs?si=3oSSrljRF1Dv_PMH",
                 GitHubUrl = "",
                GameplayDescription = "The player must time their movements to dodge walls and blocks. Touching an obstacle restarts the game. If the finish line is reached, the game restarts for replay. The game has a single level and uses a glowing neon art style to keep the visuals clean yet engaging.",
                Reflection = "This was my first time using visual scripting instead of code, which helped me understand logic flow and system design from a different perspective.",
                GalleryImagePaths = new List<string> 
                {
                    "/images/neon-ball-1.jpg",
                    "/images/neon-ball-2.jpg"
                },
                IsFeatured = false
            }
        };

        context.Projects.AddRange(projects);
        context.SaveChanges();
    }
}


