# Game Developer Portfolio Website

A professional, production-ready game developer portfolio website built with **ASP.NET Core 8.0** and **Razor Pages**. Features a dark cinematic design with smooth animations, responsive layout, and modern web technologies.

## 🎮 Features

### Design & UI
- **Dark Cinematic Theme** - Professional dark design with neon blue/purple/orange accents
- **Smooth Animations** - GSAP, AOS, and custom CSS animations for engaging user experience
- **Responsive Design** - Optimized for desktop, tablet, and mobile devices
- **Modern UI Components** - Bootstrap 5, custom cards, and interactive elements

### Content & Pages
- **Hero Section** - Full-screen background video with compelling headline and CTA buttons
- **Projects Showcase** - Grid layout with hover effects and project details
- **Individual Project Pages** - Detailed project information with image galleries
- **About Me** - Professional bio, skills visualization, and experience timeline
- **Contact Form** - Server-side validated contact form with social media links

### Technical Features
- **Entity Framework Core** - Database management with seed data
- **Razor Pages** - Clean separation of concerns and maintainable code
- **Modern JavaScript** - ES6+ features, performance optimization, and accessibility
- **SEO Optimized** - Meta tags, semantic HTML, and structured content

## 🚀 Technology Stack

- **Backend**: ASP.NET Core 8.0, C#, Entity Framework Core
- **Frontend**: Razor Pages, Bootstrap 5, CSS3, JavaScript (ES6+)
- **Database**: In-Memory Database (EF Core)
- **Libraries**: AOS (Animate On Scroll), GSAP, FontAwesome
- **Development**: Visual Studio 2022, .NET 8.0 SDK

## 📋 Prerequisites

- **.NET 8.0 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Visual Studio 2022** (Community, Professional, or Enterprise) - [Download here](https://visualstudio.microsoft.com/downloads/)
- **Git** - For version control

## 🛠️ Installation & Setup

### 1. Clone the Repository
```bash
git clone <repository-url>
cd GameDevPortfolio
```

### 2. Open in Visual Studio
- Open `GameDevPortfolio.sln` in Visual Studio 2022
- Wait for NuGet packages to restore

### 3. Build and Run
- Press `F5` or click "Start Debugging"
- The website will open in your default browser at `https://localhost:5001`

### 4. Alternative: Command Line
```bash
dotnet restore
dotnet build
dotnet run
```

## 📁 Project Structure

```
GameDevPortfolio/
├── Data/                          # Entity Framework and data models
│   ├── PortfolioDbContext.cs     # Database context
│   └── DbInitializer.cs         # Seed data initialization
├── Models/                        # C# model classes
│   ├── Project.cs                # Project entity model
│   └── ContactForm.cs            # Contact form model
├── Pages/                         # Razor Pages
│   ├── Index.cshtml              # Home page
│   ├── Projects.cshtml           # Projects listing
│   ├── Project.cshtml            # Individual project view
│   ├── About.cshtml              # About page
│   ├── Contact.cshtml            # Contact page
│   └── Shared/                   # Shared layouts and components
│       └── _Layout.cshtml        # Main layout template
├── wwwroot/                       # Static assets
│   ├── css/                      # Stylesheets
│   │   └── site.css              # Main CSS file
│   ├── js/                       # JavaScript files
│   │   └── site.js               # Main JS file
│   ├── images/                    # Image assets
│   └── videos/                    # Video assets
├── Program.cs                     # Application entry point
├── GameDevPortfolio.csproj       # Project file
└── README.md                      # This file
```

## 🎨 Customization

### Colors and Theme
The website uses CSS custom properties for easy theming. Edit `wwwroot/css/site.css`:

```css
:root {
    --primary-color: #00d4ff;      /* Main accent color */
    --secondary-color: #ff6b35;    /* Secondary accent */
    --accent-color: #8a2be2;      /* Purple accent */
    --dark-bg: #0a0a0a;           /* Background color */
    --card-bg: #1a1a1a;           /* Card background */
}
```

### Content Updates
- **Projects**: Edit `Data/DbInitializer.cs` to modify project data
- **About Me**: Update content in `Pages/About.cshtml`
- **Contact Info**: Modify social links and contact details in `Pages/Contact.cshtml`

### Images and Videos
- Place project images in `wwwroot/images/`
- Add gameplay videos in `wwwroot/videos/`
- Update image paths in the database seed data

## 📱 Responsive Design

The website is fully responsive with breakpoints:
- **Desktop**: 1200px and above
- **Tablet**: 768px - 1199px
- **Mobile**: Below 768px

## ♿ Accessibility Features

- Semantic HTML structure
- ARIA labels and roles
- Keyboard navigation support
- Screen reader compatibility
- Skip to main content link
- High contrast color scheme

## 🔧 Configuration

### Database
Currently uses in-memory database for development. To switch to SQL Server:

1. Update connection string in `Program.cs`
2. Run Entity Framework migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Environment Variables
Create `appsettings.Development.json` for development-specific settings:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GameDevPortfolio;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

## 🚀 Deployment

### Azure App Service
1. Right-click project in Visual Studio
2. Select "Publish"
3. Choose "Azure App Service"
4. Configure your Azure account and app service

### IIS
1. Build the project: `dotnet publish -c Release`
2. Copy published files to IIS web directory
3. Configure application pool for .NET Core

### Docker
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GameDevPortfolio.csproj", "./"]
RUN dotnet restore "GameDevPortfolio.csproj"
COPY . .
RUN dotnet build "GameDevPortfolio.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameDevPortfolio.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameDevPortfolio.dll"]
```

## 🧪 Testing

Run the application and test:
- All pages load correctly
- Navigation works on all devices
- Contact form validation
- Responsive design on different screen sizes
- Animations and interactions

## 📈 Performance Optimization

- Lazy loading for images
- Minified CSS and JavaScript
- Optimized images and videos
- Efficient database queries
- CDN for external libraries

## 🔒 Security

- Input validation and sanitization
- CSRF protection
- Secure headers
- HTTPS enforcement in production

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🆘 Support

For support and questions:
- Create an issue in the repository
- Contact: your.email@example.com
- Documentation: Check the inline code comments

## 🔄 Updates and Maintenance

### Regular Maintenance
- Update .NET Core version
- Update NuGet packages
- Review and update content
- Test on new browsers and devices

### Future Enhancements
- Blog system for development updates
- Portfolio filtering and search
- Dark/light theme toggle
- Multi-language support
- Analytics integration

---

**Built with ❤️ using ASP.NET Core 8.0**

*Last updated: December 2024*




