// ===== GLOBAL VARIABLES =====
let isScrolled = false;
let lastScrollTop = 0;

// Mobile and Performance Optimizations
document.addEventListener('DOMContentLoaded', function() {
    // Initialize AOS with mobile-friendly settings
    AOS.init({
        duration: 800,
        easing: 'ease-in-out',
        once: true,
        offset: 50,
        disable: window.innerWidth < 768 // Disable on mobile for better performance
    });

    // Mobile-specific optimizations
    if (window.innerWidth <= 768) {
        // Reduce animation complexity on mobile
        document.body.classList.add('mobile-device');
        
        // Optimize touch interactions
        optimizeTouchInteractions();
        
        // Lazy load images on mobile
        lazyLoadImages();
    }

    // Performance optimizations
    optimizePerformance();
    
    // Initialize accessibility features
    initializeAccessibility();
    
    // Initialize smooth scrolling
    initializeSmoothScrolling();
    
    // Initialize project card interactions
    initializeProjectCards();
    
    // Initialize form validation
    initializeFormValidation();
});

// ===== NAVIGATION FUNCTIONALITY =====
function initializeNavigation() {
    const navbar = document.getElementById('mainNav');
    const navbarToggler = document.querySelector('.navbar-toggler');
    const navbarCollapse = document.querySelector('.navbar-collapse');
    
    if (!navbar) return;
    
    // Navbar scroll effect
    window.addEventListener('scroll', function() {
        const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
        
        if (scrollTop > 100) {
            if (!isScrolled) {
                navbar.classList.add('scrolled');
                isScrolled = true;
            }
        } else {
            if (isScrolled) {
                navbar.classList.remove('scrolled');
                isScrolled = false;
            }
        }
        
        // Hide navbar on scroll down, show on scroll up (mobile)
        if (window.innerWidth <= 768) {
            if (scrollTop > lastScrollTop && scrollTop > 200) {
                navbar.style.transform = 'translateY(-100%)';
            } else {
                navbar.style.transform = 'translateY(0)';
            }
        }
        
        lastScrollTop = scrollTop;
    });
    
    // Close mobile menu when clicking on a link
    const navLinks = document.querySelectorAll('.navbar-nav .nav-link');
    navLinks.forEach(link => {
        link.addEventListener('click', function() {
            if (navbarCollapse.classList.contains('show')) {
                navbarToggler.click();
            }
        });
    });
    
    // Add active state to current page
    highlightCurrentPage();
}

// Mobile touch optimizations
function optimizeTouchInteractions() {
    // Increase touch target sizes
    const buttons = document.querySelectorAll('.btn, .nav-link');
    buttons.forEach(btn => {
        btn.style.minHeight = '44px';
        btn.style.minWidth = '44px';
    });
    
    // Add touch feedback
    const touchElements = document.querySelectorAll('.project-card, .bonus-item, .btn');
    touchElements.forEach(element => {
        element.addEventListener('touchstart', function() {
            this.style.transform = 'scale(0.98)';
        });
        
        element.addEventListener('touchend', function() {
            this.style.transform = 'scale(1)';
        });
    });
}

// Lazy load images for better mobile performance
function lazyLoadImages() {
    const images = document.querySelectorAll('img[data-src]');
    
    const imageObserver = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const img = entry.target;
                img.src = img.dataset.src;
                img.classList.remove('lazy');
                imageObserver.unobserve(img);
            }
        });
    });
    
    images.forEach(img => imageObserver.observe(img));
}

// Performance optimizations
function optimizePerformance() {
    // Debounce scroll events
    let scrollTimeout;
    window.addEventListener('scroll', function() {
        if (scrollTimeout) {
            clearTimeout(scrollTimeout);
        }
        scrollTimeout = setTimeout(function() {
            // Handle scroll-based animations
            handleScrollAnimations();
        }, 16); // ~60fps
    });
    
    // Optimize resize events
    let resizeTimeout;
    window.addEventListener('resize', function() {
        if (resizeTimeout) {
            clearTimeout(resizeTimeout);
        }
        resizeTimeout = setTimeout(function() {
            handleResize();
        }, 250);
    });
}

// Handle scroll animations efficiently
function handleScrollAnimations() {
    const elements = document.querySelectorAll('[data-aos]');
    elements.forEach(element => {
        const rect = element.getBoundingClientRect();
        const isVisible = rect.top < window.innerHeight && rect.bottom > 0;
        
        if (isVisible && !element.classList.contains('aos-animate')) {
            element.classList.add('aos-animate');
        }
    });
}

// Handle resize events
function handleResize() {
    // Adjust layout for different screen sizes
    if (window.innerWidth <= 768) {
        document.body.classList.add('mobile-device');
    } else {
        document.body.classList.remove('mobile-device');
    }
    
    // Recalculate video box heights
    adjustVideoBoxes();
}

// Adjust video boxes for different screen sizes
function adjustVideoBoxes() {
    const videoBoxes = document.querySelectorAll('.video-box, .video-placeholder');
    const isMobile = window.innerWidth <= 768;
    const isSmallMobile = window.innerWidth <= 480;
    
    videoBoxes.forEach(box => {
        if (isSmallMobile) {
            box.style.height = '200px';
        } else if (isMobile) {
            box.style.height = '250px';
        } else {
            box.style.height = '400px';
        }
    });
}

// Initialize smooth scrolling
function initializeSmoothScrolling() {
    const links = document.querySelectorAll('a[href^="#"]');
    links.forEach(link => {
        link.addEventListener('click', function(e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                const offsetTop = target.offsetTop - 80; // Account for fixed navbar
                window.scrollTo({
                    top: offsetTop,
                    behavior: 'smooth'
                });
            }
        });
    });
}

// Initialize project card interactions
function initializeProjectCards() {
    const projectCards = document.querySelectorAll('.project-card');
    projectCards.forEach(card => {
        // Add hover effects only on devices that support hover
        if (window.matchMedia('(hover: hover)').matches) {
            card.addEventListener('mouseenter', function() {
                this.style.transform = 'translateY(-5px)';
            });
            
            card.addEventListener('mouseleave', function() {
                this.style.transform = 'translateY(0)';
            });
        }
        
        // Add click effects for mobile
        card.addEventListener('click', function() {
            if (window.innerWidth <= 768) {
                this.style.transform = 'scale(0.98)';
                setTimeout(() => {
                    this.style.transform = 'scale(1)';
                }, 150);
            }
        });
    });
}

// Initialize form validation
function initializeFormValidation() {
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', function(e) {
            if (!validateForm(this)) {
                e.preventDefault();
            }
        });
        
        // Real-time validation
        const inputs = form.querySelectorAll('input, textarea');
        inputs.forEach(input => {
            input.addEventListener('blur', function() {
                validateField(this);
            });
        });
    });
}

// Form validation logic
function validateForm(form) {
    let isValid = true;
    const inputs = form.querySelectorAll('input[required], textarea[required]');
    
    inputs.forEach(input => {
        if (!validateField(input)) {
            isValid = false;
        }
    });
    
    return isValid;
}

// Field validation
function validateField(field) {
    const value = field.value.trim();
    const isValid = value.length > 0;
    
    if (isValid) {
        field.classList.remove('is-invalid');
        field.classList.add('is-valid');
    } else {
        field.classList.remove('is-valid');
        field.classList.add('is-invalid');
    }
    
    return isValid;
}

// Initialize accessibility features
function initializeAccessibility() {
    // Add skip to content link
    addSkipToContent();
    
    // Add keyboard navigation
    addKeyboardNavigation();
    
    // Add ARIA labels
    addAriaLabels();
}

// Add skip to content link
function addSkipToContent() {
    const skipLink = document.createElement('a');
    skipLink.href = '#main-content';
    skipLink.textContent = 'Skip to main content';
    skipLink.className = 'skip-link sr-only sr-only-focusable';
    skipLink.style.cssText = `
        position: absolute;
        top: -40px;
        left: 6px;
        z-index: 1000;
        padding: 8px 16px;
        background: #007bff;
        color: white;
        text-decoration: none;
        border-radius: 4px;
        transition: top 0.3s;
    `;
    
    skipLink.addEventListener('focus', function() {
        this.style.top = '6px';
    });
    
    skipLink.addEventListener('blur', function() {
        this.style.top = '-40px';
    });
    
    document.body.insertBefore(skipLink, document.body.firstChild);
}

// Add keyboard navigation
function addKeyboardNavigation() {
    // Handle keyboard navigation for project cards
    const projectCards = document.querySelectorAll('.project-card');
    projectCards.forEach(card => {
        card.setAttribute('tabindex', '0');
        card.setAttribute('role', 'button');
        
        card.addEventListener('keydown', function(e) {
            if (e.key === 'Enter' || e.key === ' ') {
                e.preventDefault();
                const link = this.querySelector('a');
                if (link) {
                    link.click();
                }
            }
        });
    });
}

// Add ARIA labels
function addAriaLabels() {
    // Add ARIA labels to navigation
    const navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(link => {
        const text = link.textContent;
        link.setAttribute('aria-label', `Navigate to ${text} page`);
    });
    
    // Add ARIA labels to buttons
    const buttons = document.querySelectorAll('.btn');
    buttons.forEach(button => {
        if (!button.getAttribute('aria-label')) {
            button.setAttribute('aria-label', button.textContent.trim());
        }
    });
}

// Handle mobile-specific video controls
function initializeMobileVideoControls() {
    const videos = document.querySelectorAll('video');
    videos.forEach(video => {
        // Add touch-friendly controls for mobile
        if (window.innerWidth <= 768) {
            video.addEventListener('touchstart', function() {
                if (this.paused) {
                    this.play();
                } else {
                    this.pause();
                }
            });
        }
        
        // Optimize video loading
        video.addEventListener('loadstart', function() {
            this.style.opacity = '0.7';
        });
        
        video.addEventListener('canplay', function() {
            this.style.opacity = '1';
        });
    });
}

// Initialize mobile video controls
document.addEventListener('DOMContentLoaded', function() {
    initializeMobileVideoControls();
});

// Handle orientation change on mobile
window.addEventListener('orientationchange', function() {
    setTimeout(function() {
        // Recalculate layouts after orientation change
        handleResize();
        
        // Reinitialize AOS
        AOS.refresh();
    }, 500);
});

// Performance monitoring
if ('performance' in window) {
    window.addEventListener('load', function() {
        setTimeout(function() {
            const perfData = performance.getEntriesByType('navigation')[0];
            console.log('Page Load Time:', perfData.loadEventEnd - perfData.loadEventStart, 'ms');
        }, 0);
    });
}

// ===== UTILITY FUNCTIONS =====
function highlightCurrentPage() {
    const currentPath = window.location.pathname;
    const navLinks = document.querySelectorAll('.navbar-nav .nav-link');
    
    navLinks.forEach(link => {
        const linkPath = link.getAttribute('href');
        if (linkPath === currentPath || 
            (currentPath === '/' && linkPath === '/') ||
            (currentPath !== '/' && currentPath.startsWith(linkPath) && linkPath !== '/')) {
            link.classList.add('active');
        }
    });
}

function debounce(func, wait) {
    let timeout;
    return function executedFunction(...args) {
        const later = () => {
            clearTimeout(timeout);
            func(...args);
        };
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
    };
}

function throttle(func, limit) {
    let inThrottle;
    return function() {
        const args = arguments;
        const context = this;
        if (!inThrottle) {
            func.apply(context, args);
            inThrottle = true;
            setTimeout(() => inThrottle = false, limit);
        }
    };
}

// ===== PERFORMANCE OPTIMIZATION =====
// Throttle scroll events
const throttledScrollHandler = throttle(function() {
    // Handle scroll events efficiently
}, 16); // ~60fps

window.addEventListener('scroll', throttledScrollHandler);

// ===== ACCESSIBILITY IMPROVEMENTS =====
// The original initializeAccessibility function is now called within the new DOMContentLoaded listener.

// ===== ERROR HANDLING =====
window.addEventListener('error', function(e) {
    console.error('JavaScript error:', e.error);
    // You could send this to an error tracking service
});

// ===== RESIZE HANDLER =====
// The original debounce resize handler is now called within the new DOMContentLoaded listener.

// ===== INITIALIZE ACCESSIBILITY =====
// The original initializeAccessibility function is now called within the new DOMContentLoaded listener.





