import config from './config.js';
import { loadingIndicator, errorHandler, storageHelper } from './utils.js';

class ApiService {
    constructor() {
        this.baseUrl = config.api.baseUrl;
        this.cache = new Map();
    }

    // Helper method for making API requests
    async request(endpoint, options = {}) {
        const url = `${this.baseUrl}${endpoint}`;
        const token = storageHelper.getItem(config.auth.tokenKey);
        
        const headers = {
            'Content-Type': 'application/json',
            ...(token && { 'Authorization': `Bearer ${token}` }),
            ...options.headers
        };

        loadingIndicator.show();

        try {
            const response = await fetch(url, {
                ...options,
                headers
            });

            if (!response.ok) {
                const error = await response.json();
                throw new Error(error.message || `HTTP error! status: ${response.status}`);
            }

            const data = await response.json();
            return data;
        } catch (error) {
            errorHandler.handleApiError(error);
            throw error;
        } finally {
            loadingIndicator.hide();
        }
    }

    // Authentication methods
    async login(credentials) {
        try {
            const response = await this.request(config.api.endpoints.auth.login, {
                method: 'POST',
                body: JSON.stringify(credentials)
            });
            return response;
        } catch (error) {
            throw new Error('Login failed. Please check your credentials.');
        }
    }

    async register(userData) {
        try {
            const response = await this.request(config.api.endpoints.auth.register, {
                method: 'POST',
                body: JSON.stringify(userData)
            });
            return response;
        } catch (error) {
            throw new Error('Registration failed. Please try again.');
        }
    }

    async logout() {
        try {
            await this.request(config.api.endpoints.auth.logout, {
                method: 'POST'
            });
        } catch (error) {
            console.error('Logout failed:', error);
        }
    }

    // Course methods with caching
    async getCourses(filters = {}) {
        const cacheKey = `courses-${JSON.stringify(filters)}`;
        
        if (this.cache.has(cacheKey)) {
            return this.cache.get(cacheKey);
        }

        try {
            const queryParams = new URLSearchParams(filters);
            const courses = await this.request(`${config.api.endpoints.courses.getAll}?${queryParams}`);
            this.cache.set(cacheKey, courses);
            return courses;
        } catch (error) {
            throw new Error('Failed to fetch courses. Please try again later.');
        }
    }

    async getFeaturedCourses() {
        const cacheKey = 'featured-courses';
        
        if (this.cache.has(cacheKey)) {
            return this.cache.get(cacheKey);
        }

        try {
            const courses = await this.request(config.api.endpoints.courses.getFeatured);
            this.cache.set(cacheKey, courses);
            return courses;
        } catch (error) {
            throw new Error('Failed to fetch featured courses.');
        }
    }

    async getRecommendedCourses() {
        const cacheKey = 'recommended-courses';
        
        if (this.cache.has(cacheKey)) {
            return this.cache.get(cacheKey);
        }

        try {
            const courses = await this.request(config.api.endpoints.courses.getRecommended);
            this.cache.set(cacheKey, courses);
            return courses;
        } catch (error) {
            throw new Error('Failed to fetch recommended courses.');
        }
    }

    async enrollInCourse(courseId) {
        try {
            const response = await this.request(config.api.endpoints.courses.enroll, {
                method: 'POST',
                body: JSON.stringify({ courseId })
            });
            return response;
        } catch (error) {
            throw new Error('Failed to enroll in course. Please try again.');
        }
    }

    // User methods
    async getUserProfile() {
        try {
            return await this.request(config.api.endpoints.user.profile);
        } catch (error) {
            throw new Error('Failed to fetch user profile.');
        }
    }

    async getEnrolledCourses() {
        try {
            return await this.request(config.api.endpoints.user.enrolledCourses);
        } catch (error) {
            throw new Error('Failed to fetch enrolled courses.');
        }
    }

    async updateProfile(profileData) {
        try {
            return await this.request(config.api.endpoints.user.updateProfile, {
                method: 'PUT',
                body: JSON.stringify(profileData)
            });
        } catch (error) {
            throw new Error('Failed to update profile. Please try again.');
        }
    }

    // Clear cache
    clearCache() {
        this.cache.clear();
    }
}

export const apiService = new ApiService(); 