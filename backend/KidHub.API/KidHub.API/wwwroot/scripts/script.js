document.addEventListener('DOMContentLoaded', () => {
    console.log('DOM loaded'); // Debug log

    // Theme Toggle
    const themeToggle = document.getElementById('theme-toggle');
    const body = document.body;
    
    // Check for saved theme preference
    const savedTheme = localStorage.getItem('theme');
    if (savedTheme) {
        body.setAttribute('data-theme', savedTheme);
        updateThemeIcon(savedTheme);
    }

    themeToggle.addEventListener('click', () => {
        const currentTheme = body.getAttribute('data-theme');
        const newTheme = currentTheme === 'dark' ? 'light' : 'dark';
        body.setAttribute('data-theme', newTheme);
        localStorage.setItem('theme', newTheme);
        updateThemeIcon(newTheme);
    });

    function updateThemeIcon(theme) {
        const icon = themeToggle.querySelector('i');
        icon.className = theme === 'dark' ? 'fas fa-sun' : 'fas fa-moon';
    }

    // Language Toggle Functionality
    const langButtons = document.querySelectorAll('.lang-btn');
    console.log('Language buttons found:', langButtons.length);

    function switchLanguage(lang) {
        console.log('Switching to language:', lang);
        
        // Update HTML direction and language with smooth transition
        document.documentElement.style.transition = 'all 0.3s ease';
        document.documentElement.dir = lang === 'ar' ? 'rtl' : 'ltr';
        document.documentElement.lang = lang;
        
        // Add transition class to all language elements
        document.querySelectorAll('[data-lang]').forEach(element => {
            element.style.transition = 'opacity 0.3s ease, transform 0.3s ease';
        });
        
        // Hide current language elements with fade out
        document.querySelectorAll(`[data-lang="${lang === 'ar' ? 'en' : 'ar'}"]`).forEach(element => {
            element.style.opacity = '0';
            element.style.transform = 'translateY(-10px)';
            setTimeout(() => {
                element.style.display = 'none';
            }, 300);
        });
        
        // Show new language elements with fade in
        document.querySelectorAll(`[data-lang="${lang}"]`).forEach(element => {
            element.style.display = '';
            setTimeout(() => {
                element.style.opacity = '1';
                element.style.transform = 'translateY(0)';
            }, 50);
        });
        
        // Update active state of buttons with smooth transition
        langButtons.forEach(button => {
            if (button.getAttribute('data-lang') === (lang === 'ar' ? 'en' : 'ar')) {
                button.classList.add('active');
            } else {
                button.classList.remove('active');
            }
        });
        
        // Save language preference
        localStorage.setItem('language', lang);
    }

    // Add click event listeners with debounce
    let timeout;
    langButtons.forEach(button => {
        button.addEventListener('click', function() {
            clearTimeout(timeout);
            timeout = setTimeout(() => {
                const lang = this.getAttribute('data-lang') === 'ar' ? 'en' : 'ar';
                switchLanguage(lang);
            }, 100);
        });
    });

    // Set initial language
    const savedLang = localStorage.getItem('language') || 'en';
    switchLanguage(savedLang);

    // Mobile Menu Toggle
    const hamburger = document.querySelector('.hamburger');
    const navLinks = document.querySelector('.nav-links');

    if (hamburger && navLinks) {
        hamburger.addEventListener('click', () => {
            navLinks.classList.toggle('active');
            hamburger.classList.toggle('active');
        });
    }

    // Form Validation
    const signupForm = document.getElementById('signup-form');
    
    if (signupForm) {
        signupForm.addEventListener('submit', (e) => {
            e.preventDefault();
            
            const name = document.getElementById('name');
            const email = document.getElementById('email');
            const password = document.getElementById('password');
            
            let isValid = true;
            
            // Name validation
            if (name.value.trim() === '') {
                showError(name, savedLang === 'en' ? 'Name is required' : 'الاسم مطلوب');
                isValid = false;
            } else {
                removeError(name);
            }
            
            // Email validation
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailRegex.test(email.value)) {
                showError(email, savedLang === 'en' ? 'Please enter a valid email' : 'يرجى إدخال بريد إلكتروني صحيح');
                isValid = false;
            } else {
                removeError(email);
            }
            
            // Password validation
            if (password.value.length < 6) {
                showError(password, savedLang === 'en' ? 'Password must be at least 6 characters' : 'يجب أن تكون كلمة المرور 6 أحرف على الأقل');
                isValid = false;
            } else {
                removeError(password);
            }
            
            if (isValid) {
                // Here you would typically send the form data to your server
                alert(savedLang === 'en' ? 'Form submitted successfully!' : 'تم إرسال النموذج بنجاح!');
                signupForm.reset();
            }
        });
    }

    function showError(input, message) {
        const formGroup = input.parentElement;
        const errorMessage = formGroup.querySelector('.error-message') || document.createElement('div');
        errorMessage.className = 'error-message';
        errorMessage.textContent = message;
        if (!formGroup.querySelector('.error-message')) {
            formGroup.appendChild(errorMessage);
        }
        input.classList.add('error');
    }

    function removeError(input) {
        const formGroup = input.parentElement;
        const errorMessage = formGroup.querySelector('.error-message');
        if (errorMessage) {
            errorMessage.remove();
        }
        input.classList.remove('error');
    }

    // Feature Card Animations
    const featureCards = document.querySelectorAll('.feature-card');
    
    const observerOptions = {
        threshold: 0.1
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, observerOptions);

    featureCards.forEach(card => {
        card.style.opacity = '0';
        card.style.transform = 'translateY(20px)';
        card.style.transition = 'opacity 0.5s ease, transform 0.5s ease';
        observer.observe(card);
    });

    // Smooth Scrolling
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth'
                });
                // Close mobile menu if open
                navLinks.classList.remove('active');
                hamburger.classList.remove('active');
            }
        });
    });

    // Make logo clickable
    const logo = document.querySelector('.logo h1');
    if (logo) {
        logo.style.cursor = 'pointer';
        logo.addEventListener('click', function() {
            window.location.href = 'index.html';
        });
    }

    // Back to Top Button
    const backToTopButton = document.querySelector('.back-to-top');
    
    window.addEventListener('scroll', () => {
        if (window.pageYOffset > 300) {
            backToTopButton.classList.add('visible');
        } else {
            backToTopButton.classList.remove('visible');
        }
    });

    backToTopButton.addEventListener('click', () => {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    });

    // Loading Overlay
    const loadingOverlay = document.querySelector('.loading-overlay');
    
    // Show loading overlay
    function showLoading() {
        loadingOverlay.style.display = 'flex';
        setTimeout(() => {
            loadingOverlay.style.opacity = '1';
        }, 10);
    }

    // Hide loading overlay
    function hideLoading() {
        loadingOverlay.style.opacity = '0';
        setTimeout(() => {
            loadingOverlay.style.display = 'none';
        }, 300);
    }

    // Simulate loading (remove this in production)
    showLoading();
    setTimeout(hideLoading, 1000);
}); 