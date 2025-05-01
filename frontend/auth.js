import config from './config.js';
import { apiService } from './api.js';

class AuthService {
    constructor() {
        this.tokenKey = config.auth.tokenKey;
        this.refreshTokenKey = config.auth.refreshTokenKey;
    }

    // Check if user is authenticated
    isAuthenticated() {
        return !!localStorage.getItem(this.tokenKey);
    }

    // Get current user token
    getToken() {
        return localStorage.getItem(this.tokenKey);
    }

    // Login user
    async login(credentials) {
        try {
            const response = await apiService.login(credentials);
            this.setTokens(response);
            return response;
        } catch (error) {
            console.error('Login failed:', error);
            throw error;
        }
    }

    // Register new user
    async register(userData) {
        try {
            const response = await apiService.register(userData);
            this.setTokens(response);
            return response;
        } catch (error) {
            console.error('Registration failed:', error);
            throw error;
        }
    }

    // Logout user
    async logout() {
        try {
            await apiService.logout();
            this.clearTokens();
        } catch (error) {
            console.error('Logout failed:', error);
            throw error;
        }
    }

    // Set authentication tokens
    setTokens({ token, refreshToken }) {
        localStorage.setItem(this.tokenKey, token);
        localStorage.setItem(this.refreshTokenKey, refreshToken);
    }

    // Clear authentication tokens
    clearTokens() {
        localStorage.removeItem(this.tokenKey);
        localStorage.removeItem(this.refreshTokenKey);
    }

    // Refresh token
    async refreshToken() {
        const refreshToken = localStorage.getItem(this.refreshTokenKey);
        if (!refreshToken) {
            throw new Error('No refresh token available');
        }

        try {
            const response = await apiService.request('/auth/refresh', {
                method: 'POST',
                body: JSON.stringify({ refreshToken })
            });
            this.setTokens(response);
            return response;
        } catch (error) {
            console.error('Token refresh failed:', error);
            this.clearTokens();
            throw error;
        }
    }
}

export const authService = new AuthService();

document.addEventListener('DOMContentLoaded', () => {
    // Password visibility toggle
    const togglePasswordBtns = document.querySelectorAll('.toggle-password');
    
    togglePasswordBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            const input = btn.previousElementSibling;
            const type = input.getAttribute('type') === 'password' ? 'text' : 'password';
            input.setAttribute('type', type);
            btn.classList.toggle('fa-eye');
            btn.classList.toggle('fa-eye-slash');
        });
    });

    // Form validation and submission
    const loginForm = document.getElementById('login-form');
    const signupForm = document.getElementById('signup-form');

    if (loginForm) {
        loginForm.addEventListener('submit', handleLogin);
    }

    if (signupForm) {
        signupForm.addEventListener('submit', handleSignup);
    }

    function handleLogin(e) {
        e.preventDefault();
        
        const email = document.getElementById('email').value;
        const password = document.getElementById('password').value;
        const remember = document.getElementById('remember').checked;

        // Basic validation
        if (!email || !password) {
            showError(currentLang === 'en' ? 'Please fill in all fields' : 'الرجاء ملء جميع الحقول');
            return;
        }

        // Here you would typically make an API call to your backend
        // For now, we'll simulate a successful login
        const user = {
            email,
            name: 'John Doe', // This would come from your backend
            education: 'University',
            phone: '+1234567890'
        };

        // Store user data in localStorage
        localStorage.setItem('user', JSON.stringify(user));
        if (remember) {
            localStorage.setItem('rememberMe', 'true');
        }

        // Redirect to profile page
        window.location.href = 'profile.html';
    }

    function handleSignup(e) {
        e.preventDefault();
        
        const fullname = document.getElementById('fullname').value;
        const email = document.getElementById('email').value;
        const password = document.getElementById('password').value;
        const confirmPassword = document.getElementById('confirm-password').value;
        const phone = document.getElementById('phone').value;
        const education = document.getElementById('education').value;
        const terms = document.getElementById('terms').checked;

        // Validation
        if (!fullname || !email || !password || !confirmPassword || !phone || !education) {
            showError(currentLang === 'en' ? 'Please fill in all fields' : 'الرجاء ملء جميع الحقول');
            return;
        }

        if (password !== confirmPassword) {
            showError(currentLang === 'en' ? 'Passwords do not match' : 'كلمات المرور غير متطابقة');
            return;
        }

        if (!terms) {
            showError(currentLang === 'en' ? 'Please agree to the terms and conditions' : 'الرجاء الموافقة على الشروط والأحكام');
            return;
        }

        // Here you would typically make an API call to your backend
        // For now, we'll simulate a successful signup
        const user = {
            name: fullname,
            email,
            phone,
            education
        };

        // Store user data in localStorage
        localStorage.setItem('user', JSON.stringify(user));

        // Redirect to profile page
        window.location.href = 'profile.html';
    }

    function showError(message) {
        // Create error message element
        const errorDiv = document.createElement('div');
        errorDiv.className = 'error-message';
        errorDiv.textContent = message;

        // Add styles
        const style = document.createElement('style');
        style.textContent = `
            .error-message {
                background-color: #ffebee;
                color: #c62828;
                padding: 1rem;
                border-radius: 8px;
                margin-bottom: 1rem;
                text-align: center;
            }
        `;
        document.head.appendChild(style);

        // Insert error message
        const form = document.querySelector('.auth-form');
        form.insertBefore(errorDiv, form.firstChild);

        // Remove error message after 3 seconds
        setTimeout(() => {
            errorDiv.remove();
        }, 3000);
    }

    // Check if user is logged in
    function checkAuth() {
        const user = localStorage.getItem('user');
        if (!user && window.location.pathname.includes('profile.html')) {
            window.location.href = 'login.html';
        }
    }

    // Run auth check
    checkAuth();
}); 